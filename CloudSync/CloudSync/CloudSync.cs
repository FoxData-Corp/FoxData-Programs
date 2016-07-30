﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Shell;

namespace CloudSync
{
    public partial class CloudSync : Form
    {
        public CloudSync()
        {
            InitializeComponent();

            string finalizedUsername;

            string finalizedPassword;

            this.Width = 500;

            this.Height = 300;

            this.BackColor = Color.FromArgb(255, 255, 255);

            this.Text = "FoxData Cloud Sync";

            this.MaximizeBox = false;

            this.MinimizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            Label usernLabel = new Label();

            usernLabel.Text = "Username:";

            usernLabel.Location = new Point(5, 20);

            Label passcLabel = new Label();

            passcLabel.Text = "Password:";

            passcLabel.Location = new Point(5, 50);

            TextBox usernameField = new TextBox();

            usernameField.Width = 100;

            usernameField.Location = new Point(120, 20);

            TextBox passwordField = new TextBox();

            passwordField.Width = 100;

            passwordField.PasswordChar = '•';

            passwordField.Location = new Point(120, 50);

            Button submitButton = new Button();

            submitButton.Text = "Submit";

            submitButton.Location = new Point(5, 80);

            submitButton.Click += (sender, e) =>
            {
                usernameField.ReadOnly = true;

                passwordField.ReadOnly = true;

                submitButton.Enabled = false;

                usernLabel.ForeColor = Color.LightGray;

                passcLabel.ForeColor = Color.LightGray;

                cloudCore main = new cloudCore();

                string sucessfail = main.login(usernameField.Text, passwordField.Text);

                if (sucessfail == "fail" || sucessfail == "false")
                {
                    MessageBox.Show("Failed to login");
                }
                else if (sucessfail == "true")
                {
                    finalizedPassword = passwordField.Text;

                    finalizedUsername = usernameField.Text;

                    this.Controls.Remove(usernLabel);

                    this.Controls.Remove(passcLabel);

                    this.Controls.Remove(usernameField);

                    this.Controls.Remove(passwordField);

                    this.Controls.Remove(submitButton);

                    Label desc = new Label();

                    desc.Text = "Choose action";

                    desc.Location = new Point(2, 20);

                    this.Controls.Add(desc);

                    BackgroundWorker syncProcess = new BackgroundWorker();

                    syncProcess.WorkerReportsProgress = true;

                    syncProcess.WorkerSupportsCancellation = true;


                }
                else
                {
                    MessageBox.Show("Invalid Data Response");
                }

                usernameField.ReadOnly = false;

                passwordField.ReadOnly = false;

                submitButton.Enabled = true;

                usernLabel.ForeColor = Color.Black;

                passcLabel.ForeColor = Color.Black;
            };

            this.Controls.Add(usernLabel);

            this.Controls.Add(passcLabel);

            this.Controls.Add(usernameField);

            this.Controls.Add(passwordField);

            this.Controls.Add(submitButton);
        }
    }
}
