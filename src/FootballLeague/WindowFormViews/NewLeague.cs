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
    public partial class NewLeague : Form
    {
        private User user;
        private UserService userService;
        private LeagueService leagueService;
        private CountryService countryService;
        private FeedbackService feedbackService;
        public NewLeague(ref User user, UserService userService, LeagueService leagueService, CountryService countryService, FeedbackService feedbackService)
        {
            InitializeComponent();
            this.user = user;
            this.userService = userService;
            this.leagueService = leagueService;
            this.countryService = countryService;
            this.feedbackService = feedbackService;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void NewLeague_Load(object sender, EventArgs e)
        {
            fillComboCountries();
            fillNameCreator();
        }
        private void fillComboCountries()
        {
            dynamic countryList = countryService.getAllCountries();
            foreach (Country country in countryList)
            {
                cbbCountry.Items.Add(country.Name);
            }
        }

        private void fillNameCreator()
        {
            textBoxCreator.Text = user.FirstName + " " + user.LastName;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cbbCountry.Text == "" || textBoxName.Text == "" || textBoxRating.Text == "")
            {
                MessageBox.Show("Fields blank");
                return;
            }
            Country currCountry = countryService.getCountryByName(cbbCountry.SelectedItem.ToString());
            leagueService.insertLeague(textBoxName.Text, Convert.ToDouble(textBoxRating.Text), user.Id, currCountry.Id);

            if (MyLeagueForm.dgvMyLeague != null)
                MyLeagueForm.dgvMyLeague.DataSource = leagueService.getAllLeagueByIDUser(user.Id);

            MessageBox.Show("League have been created successfully");
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxRating.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
