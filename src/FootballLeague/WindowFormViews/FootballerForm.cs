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
    public partial class FootballerForm : Form
    {
        private UserService userService;
        public FootballerForm(UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        private void FootballerForm_Load(object sender, EventArgs e)
        {
            fillAllFootballer();
        }

        private void fillAllFootballer()
        {
            dynamic allFootballer = userService.getAllUserAndInfoByRole("Footballer");
            dgvFootballer.DataSource = allFootballer;
        }
    }
}
