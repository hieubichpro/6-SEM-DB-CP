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
    public partial class RequestOfLeague : Form
    {
        private string username;
        private UserService userService;
        private RequestService requestService;
        private ClubService clubService;
        private LeagueService leagueService;
        public RequestOfLeague(string username, UserService userService, RequestService requestService, ClubService clubService, LeagueService leagueService)
        {
            InitializeComponent();
            this.username = username;
            this.userService = userService;
            this.requestService = requestService;
            this.clubService = clubService;
            this.leagueService = leagueService;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            int idRequest = (int)dgvRequest.CurrentRow.Cells[0].Value;
            requestService.deleteRequestByIdRequest(idRequest);
            showAllRequest();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int idLeague = (int)LeagueForm.dgvLeague.CurrentRow.Cells[0].Value;
            int idClub = (int)dgvRequest.CurrentRow.Cells[2].Value;
            User currUser = userService.getUserByUsername(username);
            requestService.deleteRequestByIdUser(currUser.Id);
            leagueService.insertIntoTableLeagueClub(idLeague, idClub);
            MessageBox.Show("Club have been joined to League");
            showAllRequest();
        }

        private void RequestOfLeague_Load(object sender, EventArgs e)
        {
            showAllRequest();
        }

        private void showAllRequest()
        {
            int idLeague = (int)LeagueForm.dgvLeague.CurrentRow.Cells[0].Value; //do LeagueForm.dgv static public
            dynamic allInfo = requestService.getAllRequestToLeague(idLeague);
            dgvRequest.DataSource = allInfo;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
