using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EnableButtons();
            pictureBoxStatus.Image = imageList.Images[0];
            labelStatus.Text = "";
        }


        private async void ButtonAuthenticate_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string domain = textBoxAdDomain.Text.Trim();
            string container = textBoxAdContainer.Text.Trim();

            if (domain.Length == 0)
                domain = null;

            if (container.Length == 0)
                container = null;

            ContextOptions? options = null;
            if (cbSsl.Checked)
                options = ContextOptions.SecureSocketLayer;

            if (cbSimpleBind.Checked)
                options = options == null ? ContextOptions.SimpleBind : options | ContextOptions.SimpleBind;

            if (cbNegotiate.Checked)
                options = options == null ? ContextOptions.Negotiate : options | ContextOptions.Negotiate;


            buttonAuthenticate.Enabled = false;
            labelStatus.Text = "Authenticating...";

            UserDetail authenticatedUser = null;
            var auth = new ActiveDirectoryAuthenticator();
            authenticatedUser = await AuthenticateUser(username, password, domain, container, options, authenticatedUser, auth);

            bool valid = authenticatedUser != null;

            if (valid == false && string.IsNullOrEmpty(domain) == false)
            {
                // Get DC based on domain if specified
                textBoxOutput.AppendText($"Failed to validate.{Environment.NewLine}Retrying by resolving Domain Controller for domain: {domain}...{Environment.NewLine}");
                string server = await auth.GetDomainController(username, password, domain);

                if (string.IsNullOrEmpty(server) == false)
                {                    
                    textBoxOutput.AppendText($"Domain Controller server: {server}{Environment.NewLine}");

                    // Retry, specifying server as domain
                    authenticatedUser = await AuthenticateUser(username, password, server, container, options, authenticatedUser, auth);
                    valid = authenticatedUser != null;
                }
                else
                {
                    textBoxOutput.AppendText($"Unable to resolve Domain Controller{Environment.NewLine}");
                }
            }

            string validText = valid ? "User credentials are valid" : "User credentials are not valid or failed to validate";
            pictureBoxStatus.Image = valid ? imageList.Images[1] : imageList.Images[2];
            textBoxOutput.AppendText($"{Environment.NewLine}{validText}");

            if (valid)
            {
                textBoxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}");
                if (string.IsNullOrEmpty(authenticatedUser.DomainController) == false)
                {
                    textBoxOutput.AppendText($"Domain Controller from validated context: {authenticatedUser.DomainController}{Environment.NewLine}");
                }

                textBoxOutput.AppendText($"{Environment.NewLine}");
                textBoxOutput.AppendText($"Id: {authenticatedUser.Id}{Environment.NewLine}");
                textBoxOutput.AppendText($"Username: {authenticatedUser.Username}{Environment.NewLine}");
                textBoxOutput.AppendText($"Name: {authenticatedUser.Name}{Environment.NewLine}");
                textBoxOutput.AppendText($"GivenName: {authenticatedUser.GivenName}{Environment.NewLine}");
                textBoxOutput.AppendText($"MiddleName: {authenticatedUser.MiddleName}{Environment.NewLine}");
                textBoxOutput.AppendText($"Surname: {authenticatedUser.Surname}{Environment.NewLine}");
                textBoxOutput.AppendText($"FullName: {authenticatedUser.FullName}{Environment.NewLine}");
                textBoxOutput.AppendText($"DistinguishedName: {authenticatedUser.DistinguishedName}{Environment.NewLine}");
                textBoxOutput.AppendText($"EmailAddress: {authenticatedUser.Email}{Environment.NewLine}");
                textBoxOutput.AppendText($"AccountName: {authenticatedUser.AccountName}{Environment.NewLine}");
                textBoxOutput.AppendText($"BadLogonCount: {authenticatedUser.BadLogonCount}{Environment.NewLine}");

                if (authenticatedUser.Properties != null)
                {
                    textBoxOutput.AppendText($"{Environment.NewLine}Properties...{Environment.NewLine}{Environment.NewLine}");
                    foreach (KeyValuePair<string, string> kv in authenticatedUser.Properties)
                    {
                        textBoxOutput.AppendText($"{kv.Key}: {kv.Value}{Environment.NewLine}");
                    }
                }
            }

            labelStatus.Text = "";
            buttonAuthenticate.Enabled = true;
        }

        private async Task<UserDetail> AuthenticateUser(string username, string password, string domain, string container, ContextOptions? options, UserDetail authenticatedUser, ActiveDirectoryAuthenticator auth)
        {
            try
            {
                // validate the credentials
                return await auth.Authenticate(username, password, domain, container, cbWithProperties.Checked, options);
            }
            catch (UnableToAuthenticateException ex)
            {
                textBoxOutput.AppendText($"{ex.Message} (username: {textBoxUsername.Text}, domain: {domain}){Environment.NewLine}");
                return null;
            }
        }

        private void EnableButtons()
        {
            buttonAuthenticate.Enabled = (textBoxUsername.Text.Length > 0 && textBoxPassword.Text.Length > 0);
        }

        private void TextBoxUsername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUsername.Text.Length == 0)
            {
                errorProvider.SetError(textBoxUsername, "Username missing");                
            }
            else
            {
                errorProvider.SetError(textBoxUsername, "");
            }
            EnableButtons();
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Length == 0)
            {
                errorProvider.SetError(textBoxPassword, "Password missing");
            }
            else
            {
                errorProvider.SetError(textBoxPassword, "");
            }
            EnableButtons();
        }

        /// <summary>
        /// Returns MailAddress from given string, or null if not valid as email
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        private MailAddress GetEmail(string test)
        {
            if (string.IsNullOrEmpty(test))
                return null;

            try
            {
                return new MailAddress(test);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        private void TextBoxUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string username = textBoxUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
                return;

            if (GetEmail(username) == null)
            {
                // username doesn't validate as email, try to break into domain\user
                string[] parts = username.Split('\\');
                if (parts == null || parts.Length > 2)
                {
                    errorProvider.SetError(textBoxUsername, "Username does not validate as valid format");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(textBoxUsername, "");
                }

                if (parts.Length == 2)
                {
                    textBoxUsername.Text = parts[1];
                    textBoxAdDomain.Text = parts[0];
                }
            }
            else
            {
                errorProvider.SetError(textBoxUsername, "");
            }
        }

        private async void ButtonGetUsers_Click(object sender, EventArgs e)
        {
            string domain = textBoxAdDomain.Text.Trim();
            string container = textBoxAdContainer.Text.Trim();

            if (domain.Length == 0)
            {
                domain = null;
            }

            if (container.Length == 0)
            {
                container = null;
            }

            buttonGetUsers.Enabled = false;
            listBoxUsers.Items.Clear();

            var auth = new ActiveDirectoryAuthenticator();
            IEnumerable<User> users = await auth.GetUsers(domain, container);

            listBoxUsers.DisplayMember = "FullName";
            listBoxUsers.Items.AddRange(users.ToArray());

            buttonGetUsers.Enabled = true;
        }
    }
}
