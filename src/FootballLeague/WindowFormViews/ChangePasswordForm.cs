using FootballLeague.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballLeague.WindowFormViews
{
    public partial class ChangePasswordForm : Form
    {
        private UserService userService;
        private string username;
        public ChangePasswordForm(string username, UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
            this.username = username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newPassword = textBoxNewPassword.Text;
            string reEnterPassword = textBoxReEnterPassword.Text;
            if (string.Compare(newPassword, reEnterPassword) == 0)
            {
                userService.ChangePassword(username, newPassword);
                MessageBox.Show("Change successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("New password and re-enter dont match");
            }
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxOldPassword.Clear();
            textBoxNewPassword.Clear();
            textBoxReEnterPassword.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
