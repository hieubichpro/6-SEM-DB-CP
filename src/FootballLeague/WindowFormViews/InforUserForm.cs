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
using WindowFormViews;

namespace FootballLeague.WindowFormViews
{
    public partial class InforUserForm : Form
    {
        private User user;
        private MainForm mainForm;
        UserService userService;
        public InforUserForm(ref User user, MainForm mainForm, UserService userService)
        {
            InitializeComponent();
            this.user = user;
            this.mainForm = mainForm;
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
            textBoxUsername.Text = user.Login;
            textBoxPassword.Text = user.Password;
            textBoxRole.Text = user.Role;
            textBoxFirstname.Text = user.FirstName;
            textBoxLastname.Text = user.LastName;
            textBoxAge.Text = user.Age.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mainForm.someChange(ref user, textBoxFirstname.Text, textBoxLastname.Text, Int32.Parse(textBoxAge.Text));
            MessageBox.Show("Information have been updated successfully");
            this.Close();
        }
    }
}
