using FootballLeague.BL;
using FootballLeague.DA;
using FootballLeague.WindowFormViews;
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

namespace WindowFormViews
{
    public partial class MainForm : Form
    {
        private User user;
        private UserService userService;
        private LeagueService leagueService;
        private CountryService countryService;
        private ClubService clubService;
        private StadiumService stadiumService;
        private RequestService requestService;
        private FeedbackService feedbackService;
        private MatchService matchService;
        public MainForm(ref User user, UserService userService, LeagueService leagueService, CountryService countryService, ClubService clubService, StadiumService stadiumService, RequestService requestService, FeedbackService feedbackService, MatchService matchService)
        {
            InitializeComponent();
            FillNameAndRole();
            this.user = user;
            this.userService = userService;
            this.leagueService = leagueService;
            this.countryService = countryService;
            this.clubService = clubService;
            this.stadiumService = stadiumService;
            this.requestService = requestService;
            this.feedbackService = feedbackService;
            this.matchService = matchService;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (user.Role != "Guest")
            {
                labelName.Text = user.FirstName + " " + user.LastName;
                LabelRolee.Text = user.Role;
                if (user.Role == "Coach")
                {
                    btnMyClub.BringToFront();
                    aboutToolStripMenuItem.Visible = false;
                }
                else if (user.Role == "Referee")
                {
                    btnMyLeague.BringToFront();
                    aboutToolStripMenuItem.Visible = false;
                }
                
                else
                {
                    if (user.Role == "Footballer")
                        aboutToolStripMenuItem.Visible = false;
                    btnMyClub.Visible = false;
                    btnMyLeague.Visible = false;
                }
            }
            else
            {
                labelName.Text = "Guest";
                LabelRolee.Text = "Guest";
                userToolStripMenuItem.Visible = false;
                aboutToolStripMenuItem.Visible = false;
                btnMyClub.Visible = false;
                btnMyLeague.Visible = false;
            }
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void FillNameAndRole()
        {
            //string query = "Select * from Users";
            //dgvAccount.DataSource = Connecter.Instance.ExecuteQuery(query);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
        }

        private void labelDate_Click(object sender, EventArgs e)
        {

        }

        private void btnLeague_Click(object sender, EventArgs e)
        {
            openChildForm(new LeagueForm(ref user, userService, leagueService, countryService, requestService, clubService, feedbackService));
        }

        private Form activeForm = null;

        public RequestService RequestService { get => requestService; set => requestService = value; }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnFootballer_Click(object sender, EventArgs e)
        {
            openChildForm(new FootballerForm(userService, requestService));
        }

        private void btnClub_Click(object sender, EventArgs e)
        {
            openChildForm(new ClubForm(ref user, userService, clubService, countryService, RequestService));
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm c = new ChangePasswordForm(ref user, userService);
            c.ShowDialog();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InforUserForm i = new InforUserForm(ref user, this, userService);
            i.ShowDialog();
        }

        private void btnCoach_Click(object sender, EventArgs e)
        {
            openChildForm(new CoachForm(ref user, userService));
        }

        private void btnStadium_Click(object sender, EventArgs e)
        {
            openChildForm(new StadiumForm(ref user, stadiumService, countryService, userService));
        }

        private void infoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            InforUserForm i = new InforUserForm(ref user, this, userService);
            i.ShowDialog();
        }

        private void btnMyClub_Click(object sender, EventArgs e)
        {
            user = userService.getUserById(user.Id);
            if (user.Role == "Coach" && user.IdClub == -1)
            {
                MessageBox.Show("You don't have any club. \nLet create your club first");
                NewClub nc = new NewClub(ref user, userService, clubService, countryService, feedbackService);
                nc.ShowDialog();

            }
            else if (user.Role == "Coach" && user.IdClub != -1)
            {
                openChildForm(new MyClubForm(ref user, userService, clubService, countryService, RequestService));
            }
        }

        private void btnMyLeague_Click(object sender, EventArgs e)
        {
            if (user.Role == "Referee" && !leagueService.haveLeague(user.Id))
            {
                MessageBox.Show("You don't have any league. \nLet create your league first");
                NewLeague nl = new NewLeague(ref user, userService, leagueService, countryService, feedbackService);
                nl.ShowDialog();
            }
            else if (user.Role == "Referee" && leagueService.haveLeague(user.Id))
            {
                openChildForm(new MyLeagueForm(ref user, userService, leagueService, countryService, requestService, clubService, feedbackService, matchService));
            }
        }

        private void labelTime_Click(object sender, EventArgs e)
        {

        }

        public void someChange(ref User user, string firstname, string lastname, int age)
        {
            userService.ChangeInfoUser(user, firstname, lastname, age);
            LoadData();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm af = new AdminForm(userService);
            af.ShowDialog();
        }
    }
}
