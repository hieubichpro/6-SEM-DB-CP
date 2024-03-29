using FootballLeague.BL;
using Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballLeague.WindowFormViews
{
    public partial class ClubForm : Form
    {
        private string username;
        private UserService userService;
        private ClubService clubService;
        private CountryService countryService;
        private RequestService requestService;
        public ClubForm(string username, UserService userService, ClubService clubService, CountryService countryService, RequestService requestService)
        {
            InitializeComponent();
            this.username = username;
            this.userService = userService;
            this.clubService = clubService;
            this.countryService = countryService;
            this.requestService = requestService;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            NewClub ncl = new NewClub(username, userService, clubService, countryService);
            ncl.ShowDialog();

        }

        private void showAllClubs()
        {
            dynamic allClub = clubService.getAllClubAndInfo();
            //dgvClub.Columns.Add("id", "id");
            //dgvClub.Columns.Add("name", "name");
            //dgvClub.Columns.Add("id_user", "id_user");
            //dgvClub.Columns.Add("id_country", "id_country");
            //foreach (Club club in allClub)
            //{
            //    dgvClub.Rows.Add(club.Id, club.Name, club.IdUser, club.IdCountry);
            //}
            //dgvClub.CurrentCell = null;
            dgvClub.DataSource = allClub;
        }

        private void ClubForm_Load(object sender, EventArgs e)
        {
            showAllClubs();
        }

        private void dgvClub_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idClub = (int)dgvClub.CurrentRow.Cells[0].Value;
            dynamic allFootballerInClub = userService.getAllFootballerInClub(idClub);
            dgvFootballerinClub.DataSource = allFootballerInClub;
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            int id_club = (int)dgvClub.CurrentRow.Cells[0].Value;
            int id_user = userService.getUserByUsername(username).Id;
            requestService.insertRequestToClub(id_club, id_user);

            MessageBox.Show("Request to club successfully");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            RequestOfClub roc = new RequestOfClub(username, userService, requestService, clubService);
            roc.ShowDialog();
        }
    }
}
