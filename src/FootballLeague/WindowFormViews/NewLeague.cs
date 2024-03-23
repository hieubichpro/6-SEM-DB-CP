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
        private string username;
        private UserService userService;
        private LeagueService leagueService;
        private CountryService countryService;
        public NewLeague(string username, UserService userService, LeagueService leagueService, CountryService countryService)
        {
            InitializeComponent();
            this.username = username;
            this.userService = userService;
            this.leagueService = leagueService;
            this.countryService = countryService;

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
            User currUser = userService.getUserByUsername(username);
            textBoxCreator.Text = currUser.FirstName + " " + currUser.LastName;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            User currUser = userService.getUserByUsername(username);
            Country currCountry = countryService.getCountryByName(cbbCountry.SelectedItem.ToString());
            leagueService.insertLeague(textBoxName.Text, textBoxRating.Text, currUser.Id, currCountry.Id);
            MessageBox.Show("League have been created successfully");
            this.Close();
        }
    }
}
