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
        private RequestService requestService;
        public FootballerForm(UserService userService, RequestService requestService)
        {
            InitializeComponent();
            this.userService = userService;
            this.requestService = requestService;
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

        private void dgvFootballer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idFootballer = (int)dgvFootballer.CurrentRow.Cells[0].Value;
            dgvRequest.DataSource = requestService.getAllRequestOfFootballer(idFootballer); ;
        }
    }
}
