using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsManageUsers
{
    public partial class FrnUser : Form
    {
        public FrnUser()
        {
            InitializeComponent();

            this.Clear();

            this.cmdCreate.Click += (o,e) => this.CreateUser();

            this.cmdClose.Click += (o,e) => this.Close();

            this.txtLogin.Click += (o, e) => { if (!string.IsNullOrEmpty(this.txtLogin.Text)) Clipboard.SetText(this.txtLogin.Text); };
            this.txtPassword.Click += (o, e) => { if (!string.IsNullOrEmpty(this.txtPassword.Text)) Clipboard.SetText(this.txtPassword.Text); };

            this.cmdNew.Click += (o, e) => this.Clear();
        }

        private void Clear()
        {
            this.txtFirstname.Text = string.Empty;
            this.txtLastname.Text = string.Empty;
            this.txtLogin.Text = string.Empty;
            this.txtPassword.Text = string.Empty;

            this.txtFirstname.Enabled = true;
            this.txtLastname.Enabled = true;
            this.cmdCreate.Enabled = true;

            this.grpMain.Focus();
            this.txtFirstname.Focus();
        }

        private void CreateUser()
        {
            if (string.IsNullOrEmpty(this.txtLastname.Text))
            {
                MessageBox.Show(this,"Należy podać dane użytkownika, nazwę lub pełne imię i nazwisko","Informajca",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var password = new Password().RandomPassword();

                var username = Helper.ReplaceDiacriticsChars((this.txtFirstname.Text.Length > 0 ? this.txtFirstname.Text.Substring(0, 1) : string.Empty)+ this.txtLastname.Text).ToLower();

                var fullname = $"{(this.txtFirstname.Text.Length > 0 ? this.txtFirstname.Text : string.Empty)} {this.txtLastname.Text}";

                var cmd = new ExecuteCommand();

                cmd.ExecuteCommandSync($"net user {username} {password} /ADD /FULLNAME:\"{fullname}\"");

                cmd.ExecuteCommandSync($"net localgroup \"Użytkownicy pulpitu zdalnego\" {username} /ADD");

                this.AddToFile(username, password, fullname);

                this.txtLogin.Text = username;
                this.txtPassword.Text = password;

                this.txtFirstname.Enabled = false;
                this.txtLastname.Enabled = false;
                this.cmdCreate.Enabled = false;
            }
            catch(Exception exp)
            {
                MessageBox.Show(this, exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToFile(string username,string password,string fullname)
        {
            var file = new StreamWriter(Application.StartupPath + "\\users.txt",true);

            try
            {
                file.WriteLine($"{fullname}:{username}:{password}");
            }
            finally
            {
                file.Close();
            }
        }
    }
}
