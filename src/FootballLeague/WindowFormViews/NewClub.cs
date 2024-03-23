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
        string username;
        UserService userService;
        ClubService clubService;
        CountryService countryService;
        public NewClub(string username, UserService userService, ClubService clubService, CountryService countryService)
        {
            InitializeComponent();
            this.username = username;
            this.userService = userService;
            this.clubService = clubService;
            this.countryService = countryService;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            User currUser = userService.getUserByUsername(username);
            Country currCountry = countryService.getCountryByName(cbbCountry.SelectedItem.ToString());
            clubService.insertClub(name, currUser.Id, currCountry.Id);

            int idClub = clubService.getIdClubByName(name);

            userService.updateIdClubOfUser(currUser.Id, idClub);

            dynamic allClubAfterInsert = clubService.getAllClubAndInfo();
            ClubForm.dgvClub.DataSource = allClubAfterInsert;
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
            User curr = userService.getUserByUsername(username);
            textBoxCreator.Text = curr.FirstName + " " + curr.LastName;
        }
    }
}
