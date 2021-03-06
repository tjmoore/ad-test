﻿namespace AdTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAuthenticate = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAdDomain = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.labelStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAdContainer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.buttonGetUsers = new System.Windows.Forms.Button();
            this.cbWithProperties = new System.Windows.Forms.CheckBox();
            this.cbSsl = new System.Windows.Forms.CheckBox();
            this.cbNegotiate = new System.Windows.Forms.CheckBox();
            this.cbSimpleBind = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(91, 13);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(365, 20);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.TextBoxUsername_TextChanged);
            this.textBoxUsername.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxUsername_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(91, 41);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(365, 20);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.TextBoxPassword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // buttonAuthenticate
            // 
            this.buttonAuthenticate.Location = new System.Drawing.Point(545, 16);
            this.buttonAuthenticate.Name = "buttonAuthenticate";
            this.buttonAuthenticate.Size = new System.Drawing.Size(93, 23);
            this.buttonAuthenticate.TabIndex = 4;
            this.buttonAuthenticate.Text = "&Authenticate";
            this.buttonAuthenticate.UseVisualStyleBackColor = true;
            this.buttonAuthenticate.Click += new System.EventHandler(this.ButtonAuthenticate_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxOutput.Location = new System.Drawing.Point(3, 3);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(445, 343);
            this.textBoxOutput.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "AD Domain:";
            // 
            // textBoxAdDomain
            // 
            this.textBoxAdDomain.Location = new System.Drawing.Point(91, 69);
            this.textBoxAdDomain.Name = "textBoxAdDomain";
            this.textBoxAdDomain.Size = new System.Drawing.Size(364, 20);
            this.textBoxAdDomain.TabIndex = 3;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // pictureBoxStatus
            // 
            this.pictureBoxStatus.Location = new System.Drawing.Point(440, 127);
            this.pictureBoxStatus.Name = "pictureBoxStatus";
            this.pictureBoxStatus.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxStatus.TabIndex = 7;
            this.pictureBoxStatus.TabStop = false;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "test_unknown.ico");
            this.imageList.Images.SetKeyName(1, "test_success.ico");
            this.imageList.Images.SetKeyName(2, "test_error.ico");
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 130);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(41, 13);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "[status]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "AD Container:";
            // 
            // textBoxAdContainer
            // 
            this.textBoxAdContainer.Location = new System.Drawing.Point(91, 97);
            this.textBoxAdContainer.Name = "textBoxAdContainer";
            this.textBoxAdContainer.Size = new System.Drawing.Size(364, 20);
            this.textBoxAdContainer.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "(optional)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(462, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "(optional)";
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(454, 3);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(445, 342);
            this.listBoxUsers.TabIndex = 13;
            // 
            // buttonGetUsers
            // 
            this.buttonGetUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetUsers.Location = new System.Drawing.Point(822, 120);
            this.buttonGetUsers.Name = "buttonGetUsers";
            this.buttonGetUsers.Size = new System.Drawing.Size(92, 23);
            this.buttonGetUsers.TabIndex = 14;
            this.buttonGetUsers.Text = "Get &Users";
            this.buttonGetUsers.UseVisualStyleBackColor = true;
            this.buttonGetUsers.Click += new System.EventHandler(this.ButtonGetUsers_Click);
            // 
            // cbWithProperties
            // 
            this.cbWithProperties.AutoSize = true;
            this.cbWithProperties.Location = new System.Drawing.Point(545, 56);
            this.cbWithProperties.Name = "cbWithProperties";
            this.cbWithProperties.Size = new System.Drawing.Size(193, 17);
            this.cbWithProperties.TabIndex = 15;
            this.cbWithProperties.Text = "Include full user properties in output";
            this.cbWithProperties.UseVisualStyleBackColor = true;
            // 
            // cbSsl
            // 
            this.cbSsl.AutoSize = true;
            this.cbSsl.Location = new System.Drawing.Point(644, 20);
            this.cbSsl.Name = "cbSsl";
            this.cbSsl.Size = new System.Drawing.Size(46, 17);
            this.cbSsl.TabIndex = 16;
            this.cbSsl.Text = "SSL";
            this.cbSsl.UseVisualStyleBackColor = true;
            // 
            // cbNegotiate
            // 
            this.cbNegotiate.AutoSize = true;
            this.cbNegotiate.Location = new System.Drawing.Point(696, 20);
            this.cbNegotiate.Name = "cbNegotiate";
            this.cbNegotiate.Size = new System.Drawing.Size(72, 17);
            this.cbNegotiate.TabIndex = 17;
            this.cbNegotiate.Text = "Negotiate";
            this.cbNegotiate.UseVisualStyleBackColor = true;
            // 
            // cbSimpleBind
            // 
            this.cbSimpleBind.AutoSize = true;
            this.cbSimpleBind.Location = new System.Drawing.Point(774, 20);
            this.cbSimpleBind.Name = "cbSimpleBind";
            this.cbSimpleBind.Size = new System.Drawing.Size(81, 17);
            this.cbSimpleBind.TabIndex = 18;
            this.cbSimpleBind.Text = "Simple Bind";
            this.cbSimpleBind.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxOutput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxUsers, 1, 0);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 149);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(902, 349);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonAuthenticate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 510);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cbSimpleBind);
            this.Controls.Add(this.cbNegotiate);
            this.Controls.Add(this.cbSsl);
            this.Controls.Add(this.cbWithProperties);
            this.Controls.Add(this.buttonGetUsers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAdContainer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.pictureBoxStatus);
            this.Controls.Add(this.textBoxAdDomain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAuthenticate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUsername);
            this.MinimumSize = new System.Drawing.Size(565, 349);
            this.Name = "Form1";
            this.Text = "Active Directory Test";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAuthenticate;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAdDomain;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.PictureBox pictureBoxStatus;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAdContainer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonGetUsers;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.CheckBox cbWithProperties;
        private System.Windows.Forms.CheckBox cbSimpleBind;
        private System.Windows.Forms.CheckBox cbNegotiate;
        private System.Windows.Forms.CheckBox cbSsl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

