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
    public partial class InforUserForm : Form
    {
        private string username;
        UserService userService;
        public InforUserForm(string username, UserService userService)
        {
            InitializeComponent();
            this.username = username;
            this.userService = userService;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void InfroUserForm_Load(object sender, EventArgs e)
        {
            FillAllInformation();
        }

        private void FillAllInformation()
        {
            User currentUser = userService.getUserByUsername(username);
            textBoxUsername.Text = currentUser.Login;
            textBoxPassword.Text = currentUser.Password;
            textBoxRole.Text = currentUser.Role;
            textBoxFirstname.Text = currentUser.FirstName;
            textBoxLastname.Text = currentUser.LastName;
            textBoxAge.Text = currentUser.Age.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            userService.ChangeInfoUser(username, textBoxFirstname.Text, textBoxLastname.Text, textBoxAge.Text);
            MessageBox.Show("Information have been updated successfully");
            this.Close();
        }
    }
}
