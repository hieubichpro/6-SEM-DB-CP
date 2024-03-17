using FootballLeague.DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormViews
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registration r = new Registration();
            r.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textboxUsername.Text;
            string password = textboxPassword.Text;
            if (Login(username, password))
            {
                MainForm m = new MainForm();
                this.Hide();
                m.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
        bool Login(string username, string password)
        {
            return UserRepository.Instance.Login(username, password);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (textboxPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                textboxPassword.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (textboxPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                textboxPassword.PasswordChar = '*';
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
