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
    public partial class LeagueForm : Form
    {
        private User user;
        private UserService userService;
        private LeagueService leagueService;
        private CountryService countryService;
        private RequestService requestService;
        private ClubService clubService;
        private FeedbackService feedbackService;
        public LeagueForm(ref User user, UserService userService, LeagueService leagueService, CountryService countryService, RequestService requestService, ClubService clubService, FeedbackService feedbackService)
        {
            InitializeComponent();
            this.user = user;
            this.userService = userService;
            this.leagueService = leagueService;
            this.countryService = countryService;
            this.requestService = requestService;
            this.clubService = clubService;
            this.feedbackService = feedbackService;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            NewLeague nl = new NewLeague(ref user, userService, leagueService, countryService, feedbackService);
            nl.ShowDialog();
        }

        private void LeagueForm_Load(object sender, EventArgs e)
        {
            showAllLeagueInfo();
            if (user.Role != "Coach")
            {
                btnRequest.Visible = false;
            }
        }

        private void showAllLeagueInfo()
        {
            dgvLeague.DataSource = leagueService.getAllLeagueInfo();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            int id_league = (int)dgvLeague.CurrentRow.Cells[0].Value;
            if (leagueService.hasStarted(id_league))
            {
                MessageBox.Show("This league has been started");
            }
            else
            {
                int id_club = user.IdClub;
                int id_user = user.Id;

                requestService.insertRequestToLeague(id_league, id_club, id_user);

                MessageBox.Show("Request to club successfully");
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            RequestOfLeague rol = new RequestOfLeague(ref user, userService, requestService, clubService, leagueService);
            rol.ShowDialog();
        }

        private void dgvLeague_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLeague.CurrentRow.Cells[0].Value == null || dgvLeague.CurrentRow.Cells[0].Value == DBNull.Value)
                return;
            int id_league = (int)dgvLeague.CurrentRow.Cells[0].Value;
            dgvTable.DataSource = leagueService.getTableLeague(id_league);
        }

        private void btnRating_Click(object sender, EventArgs e)
        {
            int id_league = (int)dgvLeague.CurrentRow.Cells[0].Value;
            int grade = Int32.Parse(cbbRating.Text);
            feedbackService.insertFeedback(grade, user.Id, id_league);
            showAllLeagueInfo();
        }
    }
}
