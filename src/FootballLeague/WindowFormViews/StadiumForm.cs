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
    public partial class StadiumForm : Form
    {
        private User user;
        private StadiumService stadiumService;
        private CountryService countryService;
        private UserService userService;
        public StadiumForm(ref User user, StadiumService stadiumService, CountryService countryService, UserService userService)
        {
            InitializeComponent();
            this.user = user;
            this.stadiumService = stadiumService;
            this.countryService = countryService;
            this.userService = userService;
        }
        private void StadiumForm_Load(object sender, EventArgs e)
        {
            showAllStadium();
            FillCountryCbb();
            string role = user.Role;
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
            dgvStadium.DataSource = stadiumService.getAllStadiumAndInfo();
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
            string nameCountry = "";
            if (cbbCountry.SelectedItem == null || name == "" || capacity == "")
                MessageBox.Show("Blank field");
            else
            {
                nameCountry = cbbCountry.SelectedItem.ToString();


                Country currCountry = countryService.getCountryByName(nameCountry);
                stadiumService.insertStadium(name, capacity, currCountry.Id);
                MessageBox.Show("Add sucessfully");
            }
            deleteAllTextBox();

            // update dgvStadium
            showAllStadium();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            deleteAllTextBox();
        }

        public void deleteAllTextBox()
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

        private void dgvStadium_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvStadium.CurrentRow.Selected = true;
            textBoxName.Text = dgvStadium.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxCapacity.Text = dgvStadium.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbbCountry.Text = dgvStadium.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            int id = (int)dgvStadium.CurrentRow.Cells[0].Value;
            stadiumService.modifyStadium(id, textBoxName.Text, textBoxCapacity.Text, cbbCountry.Text);
            showAllStadium();
        }
    }
}
