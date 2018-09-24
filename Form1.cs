using System;
using System.DirectoryServices.AccountManagement;
using System.Net.Mail;
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


        private async void buttonAuthenticate_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
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

            buttonAuthenticate.Enabled = false;
            labelStatus.Text = "Authenticating...";

            try
            {
                // validate the credentials
                var auth = new ActiveDirectoryAuthenticator();
                AuthenticatedUser authenticatedUser = await auth.Authenticate(username, password, domain, container);

                bool valid = authenticatedUser != null;
                string validText = valid ? "User credentials are valid" : "User credentials are not valid";
                pictureBoxStatus.Image = valid ? imageList.Images[1] : imageList.Images[2];
                textBoxOutput.AppendText($"{validText}");

                if (valid)
                {
                    textBoxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}");
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
                }                
            }
            catch (UnableToAuthenticateException ex)
            {
                textBoxOutput.AppendText($"{ex.Message} (username: {textBoxUsername.Text}, domain: {domain})");
                pictureBoxStatus.Image = imageList.Images[0];
            }

            labelStatus.Text = "";
            buttonAuthenticate.Enabled = true;
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

        private void textBoxUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
    }
}
