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
    public partial class MyClubForm : Form
    {
        private User user;
        private UserService userService;
        private ClubService clubService;
        private CountryService countryService;
        private RequestService requestService;
        public MyClubForm(ref User user, UserService userService, ClubService clubService, CountryService countryService, RequestService requestService)
        {
            InitializeComponent();
            this.user = user;
            this.userService = userService;
            this.clubService = clubService;
            this.countryService = countryService;
            this.requestService = requestService;
        }

        private void MyClubForm_Load(object sender, EventArgs e)
        {
            getAllFootballerInClub();
            getAllRequest();
            showNameClub();
        }

        private void showNameClub()
        {
            nameClubTextBox.Text = clubService.getNameClubById(user.IdClub);
        }
        private void getAllFootballerInClub()
        {
            dgvFootballer.DataSource = userService.getAllFootballerInClub(user.IdClub);
        }

        private void getAllRequest()
        {

            dgvRequests.DataSource = requestService.getAllRequestToClub(user.IdClub);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idUser = (int)dgvFootballer.CurrentRow.Cells[0].Value;
            userService.updateIdClubOfUser(idUser, -1);
            getAllFootballerInClub();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int idClub = user.IdClub;
            int idFootballer = (int)dgvRequests.CurrentRow.Cells[1].Value;
            requestService.deleteRequestByIdUser(idFootballer);
            userService.updateIdClubOfUser(idFootballer, idClub);
            getAllFootballerInClub();
            getAllRequest();
            MessageBox.Show("Footballer was joined in your team");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            int idRequest = (int)dgvRequests.CurrentRow.Cells[0].Value;
            requestService.deleteRequestByIdRequest(idRequest);
            getAllRequest();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
