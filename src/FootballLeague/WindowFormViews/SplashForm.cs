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

namespace WindowFormViews
{
    public partial class SplashForm : Form
    {
        private readonly UserService userService;
        private LeagueService leagueService;
        private CountryService countryService;
        private ClubService clubService;
        private StadiumService stadiumService;
        private FeedbackService feedbackService;
        private MatchService matchService;
        private RequestService requestService;
        public SplashForm(UserService userService, LeagueService leagueService, CountryService countryService, ClubService clubService, StadiumService stadiumService, FeedbackService feedbackService, MatchService matchService, RequestService requestService)
        {
            InitializeComponent();
            this.userService = userService;
            this.leagueService = leagueService;
            this.countryService = countryService;
            this.clubService = clubService;
            this.stadiumService = stadiumService;
            this.feedbackService = feedbackService;
            this.matchService = matchService;
            this.requestService = requestService;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (processBar.Value < 100)
            {
                processBar.Value += 50;
                percent.Text = processBar.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                LoginForm n = new LoginForm(userService, leagueService, countryService, clubService, stadiumService, feedbackService, matchService, requestService);
                n.ShowDialog();
                this.Close();
            }
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void processBar_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
