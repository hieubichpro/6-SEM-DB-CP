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
        private string username;
        private UserService userService;
        private LeagueService leagueService;
        private CountryService countryService;
        private RequestService requestService;
        private ClubService clubService;
        public LeagueForm(string username, UserService userService, LeagueService leagueService, CountryService countryService, RequestService requestService, ClubService clubService)
        {
            InitializeComponent();
            this.username = username;
            this.userService = userService;
            this.leagueService = leagueService;
            this.countryService = countryService;
            this.requestService = requestService;
            this.clubService = clubService;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            NewLeague nl = new NewLeague(username, userService, leagueService, countryService);
            nl.ShowDialog();
        }

        private void LeagueForm_Load(object sender, EventArgs e)
        {
            showAllLeagueInfo();
        }

        private void showAllLeagueInfo()
        {
            dynamic allLeagues = leagueService.getAllLeagueInfo();
            dgvLeague.DataSource = allLeagues;
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            User currUser = userService.getUserByUsername(username);
            int id_club = currUser.IdClub;
            int id_user = currUser.Id;
            int id_league = (int)dgvLeague.CurrentRow.Cells[0].Value;
            requestService.insertRequestToLeague(id_league, id_club, id_user);

            MessageBox.Show("Request to club successfully");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            RequestOfLeague rol = new RequestOfLeague(username, userService, requestService, clubService, leagueService);
            rol.ShowDialog();
        }
    }
}
