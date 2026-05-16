using Store.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            linkLabel1.LinkVisited = true;

            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo(
                    linkLabel1.Links[0].LinkData.ToString()
                )
                { UseShellExecute = true }
            );
        }

        private void Login_Load(object sender, EventArgs e)
        {

            //Login Bgc color
            this.BackColor = ColorTranslator.FromHtml("#F1F5F9"); //light gray
            storeTitle.ForeColor = ColorTranslator.FromHtml("#F1F5F9");
            panel1.BackColor = ColorTranslator.FromHtml("#2563EB"); // blue
            panel2.BackColor = ColorTranslator.FromHtml("#1E293B"); //dark gray
            lblfooter1.ForeColor = ColorTranslator.FromHtml("#F1F5F9");
            txbUser.BackColor = ColorTranslator.FromHtml("#F1F5F9");
            linkLabel1.ForeColor = ColorTranslator.FromHtml("#F1F5F9");

            // Link
            linkLabel1.Text = "Icons8";
            linkLabel1.Links.Clear();
            linkLabel1.Links.Add(0, linkLabel1.Text.Length, "https://icons8.com/license");

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txbUser.Text;
            string password = txbPassword.Text;
            if (user != "" && password != "")
            {
                DBCon db = new DBCon();
                SQLiteConnection con = db.DbConnection();

                if (con != null)
                {

                    //        MessageBox.Show("Successfully Connected.", "Connected",
                    //MessageBoxButtons.OK, MessageBoxIcon.Information);


                    bool success = Actions.checkCredential(con, user, password);
                    if (success)
                    {
                        db.DBClose(con); // ✅ close the SAME connection

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Field with asterisk(*) are required.", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }

        }

        private void Login_Shown(object sender, EventArgs e)
        {
            txbUser.Focus();
        }

        private void txbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txbPassword.Focus();
            }
        }

        private void txbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
