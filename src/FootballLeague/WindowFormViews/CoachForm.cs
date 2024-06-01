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
    public partial class CoachForm : Form
    {
        private User user;
        private UserService userService;
        public CoachForm(ref User user, UserService userService)
        {
            InitializeComponent();
            this.user = user;
            this.userService = userService;
        }
        public UserService UserService { get => userService; set => userService = value; }

        private void showAllCoach()
        {
            dgvCoach.DataSource = userService.getAllUserAndInfoByRole("Coach"); ;
        }

        private void CoachForm_Load(object sender, EventArgs e)
        {
            showAllCoach();
        }
    }
}
