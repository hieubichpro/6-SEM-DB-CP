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

namespace WindowFormViews
{
    public partial class Registration : Form
    {
        private UserService userService;
        public Registration(UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
            checkMatchPassword.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.Compare(textboxPassword.Text, textboxRepassword.Text, true) == 0)
            {
                checkMatchPassword.Visible = true;
            }
            else
            {
                checkMatchPassword.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string username = textboxUsername.Text;
            string password = textboxPassword.Text;
            string repassword = textboxRepassword.Text;
            string role = comboboxRole.Text;
            string firstname = textboxFirstname.Text;
            string lastname = textboxLastname.Text;
            string age = textboxAge.Text;
            if (string.Compare(password, repassword) == 0)
            {
                userService.Register(username, password, role, firstname, lastname, age);
                MessageBox.Show("Registration successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Password and Repassword have not match");
            }
        }
    }
}
