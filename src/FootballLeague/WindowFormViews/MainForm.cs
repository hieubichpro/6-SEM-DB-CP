﻿using FootballLeague.BL;
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
        private string username;
        private UserService userService;
        private LeagueService leagueService;
        private CountryService countryService;
        private ClubService clubService;
        private StadiumService stadiumService;
        private RequestService requestService;

        public MainForm(string username, UserService userService, LeagueService leagueService, CountryService countryService, ClubService clubService, StadiumService stadiumService, RequestService requestService)
        {
            InitializeComponent();
            FillNameAndRole();
            this.username = username;
            this.userService = userService;
            this.leagueService = leagueService;
            this.countryService = countryService;
            this.clubService = clubService;
            this.stadiumService = stadiumService;
            this.requestService = requestService;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            if (username != "Guest")
            {
                User currUser = userService.getUserByUsername(username);
                labelName.Text = currUser.FirstName + " " + currUser.LastName;
                LabelRolee.Text = currUser.Role;
            }
            else
            {
                labelName.Text = username;
                LabelRolee.Text = username;
                userToolStripMenuItem.Visible = false;
                aboutToolStripMenuItem.Visible = false;
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
            openChildForm(new LeagueForm(username, userService, leagueService, countryService, requestService, clubService));
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
            openChildForm(new ClubForm(username, userService, clubService, countryService, RequestService));
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm c = new ChangePasswordForm(username, userService);
            c.ShowDialog();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InforUserForm i = new InforUserForm(username, userService);
            i.ShowDialog();
        }

        private void btnCoach_Click(object sender, EventArgs e)
        {
            openChildForm(new CoachForm(username, userService));
        }

        private void btnStadium_Click(object sender, EventArgs e)
        {
            openChildForm(new StadiumForm(username, stadiumService, countryService, userService));
        }

        private void infoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            InforUserForm i = new InforUserForm(username, userService);
            i.ShowDialog();
        }
    }
}
