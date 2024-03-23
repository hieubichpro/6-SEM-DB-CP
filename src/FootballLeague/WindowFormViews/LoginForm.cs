using FootballLeague.BL;
using FootballLeague.DA;
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
    public partial class LoginForm : Form
    {
        private UserService userService;
        private LeagueService leagueService;
        private CountryService countryService;
        private ClubService clubService;
        private StadiumService stadiumService;
        private FeedbackService feedbackService;
        private MatchService matchService;
        private ApplicationService applicationService;
        public LoginForm(UserService userService, LeagueService leagueService, CountryService countryService, ClubService clubService, StadiumService stadiumService, FeedbackService feedbackService, MatchService matchService, ApplicationService applicationService)
        {
            InitializeComponent();
            this.userService = userService;
            this.leagueService = leagueService;
            this.countryService = countryService;
            this.clubService = clubService;
            this.stadiumService = stadiumService;
            this.feedbackService = feedbackService;
            this.matchService = matchService;
            this.applicationService = applicationService;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registration r = new Registration(userService);
            r.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textboxUsername.Text;
            string password = textboxPassword.Text;
            if (userService.Login(username, password))
            {
                MainForm m = new MainForm(username, userService, leagueService, countryService, clubService, stadiumService);
                m.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (textboxPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                textboxPassword.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (textboxPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                textboxPassword.PasswordChar = '*';
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
