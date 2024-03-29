﻿using FootballLeague.BL;
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
    public partial class StadiumForm : Form
    {
        private string username;
        private StadiumService stadiumService;
        private CountryService countryService;
        private UserService userService;
        public StadiumForm(string username, StadiumService stadiumService, CountryService countryService, UserService userService)
        {
            InitializeComponent();
            this.username = username;
            this.stadiumService = stadiumService;
            this.countryService = countryService;
            this.userService = userService;
        }

        public string Username { get => username; set => username = value; }
        public StadiumService StadiumService { get => stadiumService; set => stadiumService = value; }
        public CountryService CountryService { get => countryService; set => countryService = value; }

        private void StadiumForm_Load(object sender, EventArgs e)
        {
            showAllStadium();
            FillCountryCbb();
            string role = "";
            if (username != "Guest")
            {
                role = userService.getUserByUsername(username).Role;
            }
            if (role == "Admin")
            {
                EnabledPanelContents(mypanel, true);
            }
            else
            {
                EnabledPanelContents(mypanel, false);
            }
        }

        private void showAllStadium()
        {
            dynamic allStadium = stadiumService.getAllStadiumInfo();
            dgvStadium.DataSource = allStadium;
        }

        private void FillCountryCbb()
        {
            dynamic allCountry = countryService.getAllCountries();
            foreach (Country c in allCountry)
            {
                cbbCountry.Items.Add(c.Name);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string capacity = textBoxCapacity.Text;
            string nameCountry = cbbCountry.SelectedItem.ToString();

            Country currCountry = countryService.getCountryByName(nameCountry);
            stadiumService.insertStadium(name, capacity, currCountry.Id);

            // update dgvStadium
            showAllStadium();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            textBoxCapacity.Clear();
            cbbCountry.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvStadium.SelectedRows.Count != 1)
            {
                MessageBox.Show("Error", "Error");
                return;
            }
            int selectedRow = dgvStadium.SelectedCells[0].RowIndex;
            if (dgvStadium.Rows[selectedRow].Cells["id"].Value == null)
            {
                MessageBox.Show("Error", "Error");
                return;
            }
            int id = (int)dgvStadium.Rows[selectedRow].Cells["id"].Value;
            stadiumService.deleteStadiumById(id);

            showAllStadium();
        }

        private void EnabledPanelContents(Panel panel, bool enabled)
        {
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Enabled = enabled;
            }
        }
    }
}
