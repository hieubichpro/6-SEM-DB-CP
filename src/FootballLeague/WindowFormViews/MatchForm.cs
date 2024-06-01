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
    public partial class MatchForm : Form
    {
        private MatchService matchService;

        public MatchForm(MatchService mService)
        {
            InitializeComponent();
            matchService = mService;
            Loadd();
        }

        public void Loadd()
        {
            int id_league = (int)MyLeagueForm.dgvMyLeague.CurrentRow.Cells[0].Value;
            List<Match> matches = matchService.getMatchByIdLeague(id_league);
            foreach (Match match in matches)
            {
                int id = match.Id;
                string homeName = matchService.getNameClubById(match.IdHomeTeam);
                string guestName = matchService.getNameClubById(match.IdGuestTeam);
                string stadium = matchService.getStadiumById(match.IdStadium);
                string date = match.TimeStart;
                string homeGoal = "--";
                if (match.GoalHomeTeam != -1)
                    homeGoal = match.GoalHomeTeam.ToString();
                string guestGoal = "--";
                if (match.GoalGuestTeam != -1)
                    guestGoal = match.GoalGuestTeam.ToString();
                dgv.Rows.Add(id, homeName, homeGoal, guestGoal, guestName, stadium, date);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ScoreMatchForm smf = new ScoreMatchForm(matchService);
            smf.ShowDialog();
        }
    }
}
