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
        private User user;
        private UserService userService;
        private ClubService clubService;
        private CountryService countryService;
        private RequestService requestService;
        public ClubForm(ref User user, UserService userService, ClubService clubService, CountryService countryService, RequestService requestService)
        {
            InitializeComponent();
            this.user = user;
            this.userService = userService;
            this.clubService = clubService;
            this.countryService = countryService;
            this.requestService = requestService;
        }
        private void showAllClubs()
        {
            //dgvClub.Columns.Add("id", "id");
            //dgvClub.Columns.Add("name", "name");
            //dgvClub.Columns.Add("id_user", "id_user");
            //dgvClub.Columns.Add("id_country", "id_country");
            //foreach (Club club in allClub)
            //{
            //    dgvClub.Rows.Add(club.Id, club.Name, club.IdUser, club.IdCountry);
            //}
            //dgvClub.CurrentCell = null;
            dgvClub.DataSource = clubService.getAllClubAndInfo();
        }

        private void ClubForm_Load(object sender, EventArgs e)
        {
            showAllClubs();
            if (user.Role != "Footballer")
            {
                btnRequest.Visible = false;
            }
            else
            {
                if (user.IdClub != -1)
                    btnRequest.Enabled = false;
            }
        }

        private void dgvClub_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idClub = (int)dgvClub.CurrentRow.Cells[0].Value;
            dgvFootballerinClub.DataSource = userService.getAllFootballerInClub(idClub);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            int id_club = (int)dgvClub.CurrentRow.Cells[0].Value;
            requestService.insertRequestToClub(id_club, user.Id);
            MessageBox.Show("Request to club successfully");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            RequestOfClub roc = new RequestOfClub(ref user, userService, requestService, clubService);
            roc.ShowDialog();
        }
    }
}
