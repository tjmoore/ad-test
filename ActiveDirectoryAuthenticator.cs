using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;

namespace AdTest
{
    public class UserDetail
    {
        /// <summary>
        /// ID of user if available in end system, or otherwise the username as ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Username. Typically User Principal Name or similar
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Email, which may be different from username
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Full name of user
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// First name of user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Given name of user
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Middle name of user
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Surname of user
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Description value for the account if relevant
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Account name if relevant (e.g. SAM account)
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Distinguished Name if relevant (e.g. DN on auth systems using a DN concept)
        /// </summary>
        public string DistinguishedName { get; set; }

        /// <summary>
        /// Count of bad logon attempts if available
        /// </summary>
        public int BadLogonCount { get; set; }


        /// <summary>
        /// Full property list, as string keys and values
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }
    }

    public class User
    {
        /// <summary>
        /// ID of user if available in end system, or otherwise the username as ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Username. Typically User Principal Name or similar
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Email, which may be different from username
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Full name of user
        /// </summary>
        public string FullName { get; set; }
    }

    /// <summary>
    /// Implements Active Directory authentication
    /// </summary>
    public class ActiveDirectoryAuthenticator
    {
        private const uint E_USERNAME_OR_PASSWORD_INVALID = 0x8007052E;

        /// <summary>
        /// Authenticate user by username and password
        /// </summary>
        /// <param name="username">username or user principle name (domain\username or email format)</param>
        /// <param name="password">password</param>
        /// <param name="domain">optional domain</param>
        /// <param name="container">optional container string</param>
        /// <returns>Authenticated user details or null if not authenticated</returns>
        /// <exception cref="UnableToAuthenticateException">Thrown if there is an error authenticating</exception>
        public Task<UserDetail> Authenticate(string username, string password, string domain = null, string container = null)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain, container))
                    {
                        // validate the credentials
                        bool isValid = context.ValidateCredentials(username, password);
                        if (isValid == false)
                            return null;

                        // get user and dump details
                        UserPrincipal foundUser = FindUser(context, username);
                        if (foundUser != null)
                        {
                            string userPrincipalName = foundUser.UserPrincipalName.Trim();

                            if (string.IsNullOrEmpty(userPrincipalName))
                            {
                                throw new UnableToAuthenticateException("User has no User Principal Name");
                            }

                            var authenticatedUser = new UserDetail
                            {
                                // Use Guid for Id if available, otherwise email address
                                Id = foundUser.Guid.HasValue ? foundUser.Guid.ToString() : userPrincipalName.ToLower(),
                                Username = userPrincipalName,
                                Email = string.IsNullOrEmpty(foundUser.EmailAddress) == false ? foundUser.EmailAddress : userPrincipalName,
                                FullName = foundUser.DisplayName,
                                Name = foundUser.Name,
                                GivenName = foundUser.GivenName,
                                MiddleName = foundUser.MiddleName,
                                Surname = foundUser.Surname,
                                Description = foundUser.Description,
                                AccountName = foundUser.SamAccountName,
                                DistinguishedName = foundUser.DistinguishedName,
                                BadLogonCount = foundUser.BadLogonCount
                            };

                            // Populate underlying properties
                            if (foundUser.GetUnderlyingObject() is DirectoryEntry de && de.Properties.Count > 0)
                            {
                                authenticatedUser.Properties = new Dictionary<string, string>();
                                IDictionaryEnumerator ide = de.Properties.GetEnumerator();
                                ide.Reset();
                                while (ide.MoveNext())
                                {
                                    PropertyValueCollection property = ide.Entry.Value as PropertyValueCollection;
                                    authenticatedUser.Properties.Add(property.PropertyName.ToString(), property.Value.ToString());
                                }
                            }

                            return authenticatedUser;
                        }
                    }
                }
                catch (COMException ex)
                {
                    // Sometimes ValidateCredentials doesn't just return false for invalid credentials, it throws a COMException!
                    if ((uint)ex.ErrorCode == E_USERNAME_OR_PASSWORD_INVALID)
                    {
                        return null;
                    }

                    // Something else
                    throw new UnableToAuthenticateException(ex.Message, ex);
                }
                catch (PrincipalServerDownException ex)
                {
                    throw new UnableToAuthenticateException(ex.Message, ex);
                }
                catch (UnableToAuthenticateException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new UnableToAuthenticateException(ex.Message, ex);
                }

                return null;
            });
        }

        public Task<List<User>> GetUsers(string domain = null, string container = null)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain, container))
                    {
                        var upList = GetUsers(context);

                        IEnumerable<User> users = from u in upList
                                                  let userPrincipalName = u.UserPrincipalName?.Trim().ToLower()
                                                  orderby u.DisplayName
                                                  select new User
                                                  {
                                                      Id = u.Guid.HasValue ? u.Guid.ToString() : userPrincipalName.ToLower(),
                                                      Username = userPrincipalName,
                                                      FullName = u.DisplayName,
                                                      Email = string.IsNullOrEmpty(u.EmailAddress) == false ? u.EmailAddress : userPrincipalName
                                                  };

                        return users.ToList();
                    }
                }
                catch (Exception)
                {
                }

                return null;
            });
        }

        private static UserPrincipal FindUser(PrincipalContext context, string username)
        {
            // Find by UPN
            var up = new UserPrincipal(context) { UserPrincipalName = username };

            var search = new PrincipalSearcher(up);
            if (search.FindOne() is UserPrincipal foundUser)
                return foundUser;

            // Find by SAM
            up = new UserPrincipal(context) { SamAccountName = username };

            search = new PrincipalSearcher(up);
            foundUser = search.FindOne() as UserPrincipal;
            if (foundUser != null)
                return foundUser;

            return null;
        }

        private static IEnumerable<UserPrincipal> GetUsers(PrincipalContext context)
        {
            var up = new UserPrincipal(context);
            var search = new PrincipalSearcher(up);
            var users = from p in search.FindAll()
                        let u = p as UserPrincipal
                        where u != null && u.UserPrincipalName != null
                        select u;

            if (users != null && users.Any())
                return users;


            return null;
        }
    }

    public class UnableToAuthenticateException : Exception
    {
        public UnableToAuthenticateException(string message, Exception innerException = null) : base(message, innerException) { }
    }
}
