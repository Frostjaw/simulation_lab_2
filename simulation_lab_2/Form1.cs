using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace simulation_lab_2
{
    public partial class Form1 : Form
    {
        private Championship _championship;

        public Form1()
        {
            InitializeComponent();

            _championship = new Championship();
            var bindingList = new BindingList<Team>(_championship.Teams);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _championship.PlayRound();

            _championship.Teams.Sort((x, y) => x.Score.CompareTo(y.Score));
            _championship.Teams.Reverse();

            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _championship.Refresh();
            _championship.Teams.Sort((x, y) => x.Name.CompareTo(y.Name));

            dataGridView1.Refresh();
        }
    }
}
