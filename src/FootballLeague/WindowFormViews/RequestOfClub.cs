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
    public partial class RequestOfClub : Form
    {
        private string username;
        private UserService userService;
        private RequestService requestService;
        private ClubService clubService;
        public RequestOfClub(string username, UserService userService, RequestService requestService, ClubService clubService)
        {
            InitializeComponent();
            this.username = username;
            this.userService = userService;
            this.requestService = requestService;
            this.clubService = clubService;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RequestOfClub_Load(object sender, EventArgs e)
        {
            showAllRequest();
        }

        private void showAllRequest()
        {
            int idClub = (int)ClubForm.dgvClub.CurrentRow.Cells[0].Value;
            dynamic allInfo = requestService.getAllRequestToClub(idClub);
            dgvRequest.DataSource = allInfo;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //int idRequest = (int)dgvRequest.CurrentRow.Cells[0].Value;
            int idClub = (int)ClubForm.dgvClub.CurrentRow.Cells[0].Value;
            User currUser = userService.getUserByUsername(username);
            requestService.deleteRequestByIdUser(currUser.Id);
            userService.updateIdClubOfUser(currUser.Id, idClub);
            showAllRequest();
            dynamic allFootballerAfterAccept = userService.getAllFootballerInClub(idClub);
            ClubForm.dgvFootballerinClub.DataSource = allFootballerAfterAccept;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            int idRequest = (int)dgvRequest.CurrentRow.Cells[0].Value;
            requestService.deleteRequestByIdRequest(idRequest);
            showAllRequest();
        }
    }
}
