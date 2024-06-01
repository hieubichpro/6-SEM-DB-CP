using FootballLeague.BL;
using Models;
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
        private User user;
        public ChangePasswordForm(ref User user, UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
            this.user = user;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string password = textBoxOldPassword.Text;
            string newPassword = textBoxNewPassword.Text;
            string reEnterPassword = textBoxReEnterPassword.Text;
            if (password == "" || newPassword == "" || reEnterPassword == "")
                MessageBox.Show("Field blank must be fill");
            else
            {

                if (string.Compare(user.Password, password) == 0 && string.Compare(newPassword, reEnterPassword) == 0)
                {
                    userService.ChangePassword(user, newPassword);
                    MessageBox.Show("Change successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Old Password uncorrected or New password and re-enter dont match");
                }
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
