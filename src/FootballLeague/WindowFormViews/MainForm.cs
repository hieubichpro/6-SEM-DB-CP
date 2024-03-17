using FootballLeague.DA;
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
        public MainForm()
        {
            InitializeComponent();
            loadAccountList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void loadAccountList()
        {
            string query = "Select * from Users";
            dgvAccount.DataSource = Connecter.Instance.ExecuteQuery(query);
        }
    }
}
