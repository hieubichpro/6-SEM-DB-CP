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
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (processBar.Value < 100)
            {
                processBar.Value += 5;
                percent.Text = processBar.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                LoginForm n = new LoginForm();
                n.ShowDialog();
                this.Hide();
            }
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void processBar_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
