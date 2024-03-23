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
    public partial class CoachForm : Form
    {
        private string username;
        private UserService userService;
        public CoachForm(string username, UserService userService)
        {
            InitializeComponent();
            this.username = username;
            this.userService = userService;
        }

        public string Username { get => username; set => username = value; }
        public UserService UserService { get => userService; set => userService = value; }

        private void showAllCoach()
        {
            dynamic allCoach = userService.getAllUserAndInfoByRole("Coach");
            dgvCoach.DataSource = allCoach;
        }

        private void CoachForm_Load(object sender, EventArgs e)
        {
            showAllCoach();
        }
    }
}
