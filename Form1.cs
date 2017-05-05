using System;
using System.DirectoryServices.AccountManagement;
using System.Windows.Forms;

namespace AdTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EnableButtons();
        }


        private void buttonAuthenticate_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
            string username = textBoxUsername.Text.Trim();
            string domain = textBoxAdDomain.Text.Trim();

            if (domain.Length == 0)
                domain = null;

            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
                {
                    // validate the credentials
                    bool isValid = context.ValidateCredentials(username, textBoxPassword.Text);
                    string validText = isValid ? "Valid" : "Invalid";
                    textBoxOutput.AppendText($"{validText}{Environment.NewLine}");

                    // get user and dump details
                    UserPrincipal foundUser = FindUser(context, username);
                    if (foundUser != null)
                    {
                        textBoxOutput.AppendText($"Guid: {foundUser.Guid}{Environment.NewLine}");
                        textBoxOutput.AppendText($"Name: {foundUser.Name}{Environment.NewLine}");
                        textBoxOutput.AppendText($"GivenName: {foundUser.GivenName}{Environment.NewLine}");
                        textBoxOutput.AppendText($"MiddleName: {foundUser.MiddleName}{Environment.NewLine}");
                        textBoxOutput.AppendText($"Surname: {foundUser.Surname}{Environment.NewLine}");
                        textBoxOutput.AppendText($"DisplayName: {foundUser.DisplayName}{Environment.NewLine}");
                        textBoxOutput.AppendText($"DistinguishedName: {foundUser.DistinguishedName}{Environment.NewLine}");
                        textBoxOutput.AppendText($"EmailAddress: {foundUser.EmailAddress}{Environment.NewLine}");
                        textBoxOutput.AppendText($"SamAccountName: {foundUser.SamAccountName}{Environment.NewLine}");
                        textBoxOutput.AppendText($"UserPrincipalName: {foundUser.UserPrincipalName}{Environment.NewLine}");
                        textBoxOutput.AppendText($"BadLogonCount: {foundUser.BadLogonCount}{Environment.NewLine}");
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxOutput.AppendText($"{ex.Message} (username: {textBoxUsername.Text}, domain: {domain})");
            }
        }

        private UserPrincipal FindUser(PrincipalContext context, string username)
        {
            // Find by UPN
            var up = new UserPrincipal(context) { UserPrincipalName = username };

            var search = new PrincipalSearcher(up);
            var foundUser = search.FindOne() as UserPrincipal;
            if (foundUser != null)
                return foundUser;

            // Find by SAM
            up = new UserPrincipal(context) { SamAccountName = username };

            search = new PrincipalSearcher(up);
            foundUser = search.FindOne() as UserPrincipal;
            if (foundUser != null)
                return foundUser;

            return null;
        }

        private void EnableButtons()
        {
            buttonAuthenticate.Enabled = (textBoxUsername.Text.Length > 0 && textBoxPassword.Text.Length > 0);
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
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

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
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
    }
}
