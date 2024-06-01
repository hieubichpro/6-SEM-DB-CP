using FootballLeague.BL;
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
    public partial class ScoreMatchForm : Form
    {
        private MatchService matchService;
        public ScoreMatchForm(MatchService matchService)
        {
            InitializeComponent();
            this.matchService = matchService;
        }
        private void ScoreMatchForm_Load(object sender, EventArgs e)
        {
            LoadMatch();
        }

        private void LoadMatch()
        {
            labelHomeName.Text = MatchForm.dgv.CurrentRow.Cells[1].Value.ToString();
            labelNameGuest.Text = MatchForm.dgv.CurrentRow.Cells[4].Value.ToString();
            textBoxHomeGoal.Text = MatchForm.dgv.CurrentRow.Cells[2].Value.ToString();
            textBoxGuestGoal.Text = MatchForm.dgv.CurrentRow.Cells[3].Value.ToString();
            labelStadium.Text = MatchForm.dgv.CurrentRow.Cells[5].Value.ToString();
            labelDate.Text = MatchForm.dgv.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id_match = (int)MatchForm.dgv.CurrentRow.Cells[0].Value;
            matchService.setScoreMatch(id_match, Int32.Parse(textBoxHomeGoal.Text), Int32.Parse(textBoxGuestGoal.Text));
            this.Close();
        }

    }
}
