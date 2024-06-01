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
    public partial class MyLeagueForm : Form
    {
        private User user;
        private UserService userService;
        private LeagueService leagueService;
        private CountryService countryService;
        private RequestService requestService;
        private ClubService clubService;
        private FeedbackService feedbackService;
        private MatchService matchService;
        public MyLeagueForm(ref User user, UserService userService, LeagueService leagueService, CountryService countryService, RequestService requestService, ClubService clubService, FeedbackService feedbackService, MatchService matchService)
        {
            InitializeComponent();
            this.user = user;
            this.userService = userService;
            this.leagueService = leagueService;
            this.countryService = countryService;
            this.requestService = requestService;
            this.clubService = clubService;
            this.feedbackService = feedbackService;
            this.matchService = matchService;
        }
        private void showAllMyLeague()
        {
            dgvMyLeague.DataSource = leagueService.getAllLeagueByIDUser(user.Id);
        }

        private void MyLeagueForm_Load(object sender, EventArgs e)
        {
            showAllMyLeague();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            RequestOfLeague rol = new RequestOfLeague(ref user, userService, requestService, clubService, leagueService);
            rol.ShowDialog();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            NewLeague nl = new NewLeague(ref user, userService, leagueService, countryService, feedbackService);
            nl.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id_league = (int)dgvMyLeague.CurrentRow.Cells[0].Value;
            leagueService.deleteLeague(id_league);
            MessageBox.Show("League was deleted");
            showAllMyLeague();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            int id_league = (int)dgvMyLeague.CurrentRow.Cells[0].Value;
            int res = leagueService.createTimeTable(id_league);
            if (res == 1)
                MessageBox.Show("No clubs have been joined to the league");
            else if (res == 2)
                MessageBox.Show("Number of clubs must be even number");
            else if (res == 3)
                MessageBox.Show("The league has been scheduled");
            else
                MessageBox.Show("Created");
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            int id_league = (int)dgvMyLeague.CurrentRow.Cells[0].Value;
            dgvMyTable.DataSource = leagueService.getTableLeague(id_league);
        }

        private void dgvMyLeague_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMyLeague_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MatchForm m = new MatchForm(matchService);
            m.ShowDialog();
        }
    }
}
