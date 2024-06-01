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
        private User user;
        private UserService userService;
        private RequestService requestService;
        private ClubService clubService;
        private LeagueService leagueService;
        public RequestOfLeague(ref User user, UserService userService, RequestService requestService, ClubService clubService, LeagueService leagueService)
        {
            InitializeComponent();
            this.user = user;
            this.userService = userService;
            this.requestService = requestService;
            this.clubService = clubService;
            this.leagueService = leagueService;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvRequest.SelectedRows.Count != 1)
                return;
            int idRequest = (int)dgvRequest.CurrentRow.Cells[0].Value;
            requestService.deleteRequestByIdRequest(idRequest);
            MessageBox.Show("Club have been rejected to League");
            showAllRequest();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int idLeague = (int)MyLeagueForm.dgvMyLeague.CurrentRow.Cells[0].Value;
            //if (dgvRequest.SelectedRows.Count != 1)
            //    return;
            int idClub = (int)dgvRequest.CurrentRow.Cells[2].Value;
            requestService.deleteRequestByIdClub(idClub);
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
            int idLeague = (int)MyLeagueForm.dgvMyLeague.CurrentRow.Cells[0].Value; //do LeagueForm.dgv static public
            dgvRequest.DataSource = requestService.getAllRequestToLeague(idLeague);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
