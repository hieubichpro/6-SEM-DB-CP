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
    public partial class NewClub : Form
    {
        User user;
        UserService userService;
        ClubService clubService;
        CountryService countryService;
        FeedbackService feedbackService;
        public NewClub(ref User user, UserService userService, ClubService clubService, CountryService countryService, FeedbackService feedbackService)
        {
            InitializeComponent();
            this.user = user;
            this.userService = userService;
            this.clubService = clubService;
            this.countryService = countryService;
            this.feedbackService = feedbackService;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            Country currCountry = countryService.getCountryByName(cbbCountry.SelectedItem.ToString());
            clubService.insertClub(name, currCountry.Id);

            int idClub = clubService.getIdClubByName(name);

            userService.updateIdClubOfUser(user.Id, idClub);
            
            MessageBox.Show("Club have been created successfully");
            this.Close();
        }

        private void NewClub_Load(object sender, EventArgs e)
        {
            FillComboCountry();
            FillCreatorName();
        }

        private void FillComboCountry()
        {
            dynamic countryList = countryService.getAllCountries();
            foreach (Country country in countryList)
            {
                cbbCountry.Items.Add(country.Name);
            }
        }

        private void FillCreatorName()
        {
            textBoxCreator.Text = user.FirstName + " " + user.LastName;
        }
    }
}
