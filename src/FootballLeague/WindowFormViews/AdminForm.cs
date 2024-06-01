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
    public partial class AdminForm : Form
    {
        private UserService userService;
        public AdminForm(UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_user = (int) dgvUsers.CurrentRow.Cells[0].Value;
            User curr = userService.getUserById(id_user);
            textBoxLogin.Text = curr.Login;
            textBoxPass.Text = curr.Password;
            textBoxFN.Text = curr.FirstName;
            textBoxLN.Text = curr.LastName;
            textBoxAge.Text = curr.Age.ToString();
        }

        private void fillUser()
        {
            dgvUsers.DataSource = userService.readAllUsers();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            fillUser();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id_user = (int)dgvUsers.CurrentRow.Cells[0].Value;
            userService.deleteUser(id_user);
            MessageBox.Show("User was deleted");
            fillUser();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            int id_user = (int)dgvUsers.CurrentRow.Cells[0].Value;
            User curr = userService.getUserById(id_user);
            userService.ChangeInfoUser(curr, textBoxFN.Text, textBoxLN.Text, Int32.Parse(textBoxAge.Text));
            userService.ChangePassword(curr, textBoxPass.Text);
            userService.ChangeLogin(curr, textBoxLogin.Text);
            MessageBox.Show("Change sucessfully");
            fillUser();
        }
    }
}
