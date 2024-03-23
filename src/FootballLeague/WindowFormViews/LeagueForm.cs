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
    public partial class LeagueForm : Form
    {
        private string username;
        private UserService userService;
        private LeagueService leagueService;
        private CountryService countryService;
        public LeagueForm(string username, UserService userService, LeagueService leagueService, CountryService countryService)
        {
            InitializeComponent();
            this.username = username;
            this.userService = userService;
            this.leagueService = leagueService;
            this.countryService = countryService;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            NewLeague nl = new NewLeague(username, userService, leagueService, countryService);
            nl.ShowDialog();
        }
    }
}
