using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstEFHWsol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void UpdateGridView()
        {
            //Couldn't think of a better way of updating dataGridView1
            BirdsEntities myBirds = new BirdsEntities();
            var birdInfo = from countEvent in myBirds.BirdCounts
                           where countEvent.Counted > 5
                           orderby countEvent.Bird.BirdID
                           select new
                           {
                               countEvent.CountID,
                               countEvent.Region.RegionName,
                               countEvent.Counted,
                               countEvent.Bird.Name
                           };
            dataGridView1.DataSource = birdInfo.ToList();
            dataGridView1.AutoResizeColumns();
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.BlanchedAlmond;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selected = dataGridView1.CurrentRow;
            int formCountID = (int)selected.Cells["CountID"].Value;

            BirdsEntities myBirds = new BirdsEntities();
            var selectedBird = (from countEvent in myBirds.BirdCounts
                           where countEvent.CountID == formCountID
                           select countEvent).First();

            selectedBird.Counted = Convert.ToInt32(textBox1.Text);
            myBirds.SaveChanges();
            textBox1.Clear();
            UpdateGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selected = dataGridView1.CurrentRow;
            int formCountID = (int)selected.Cells["CountID"].Value;

            BirdsEntities myBirds = new BirdsEntities();
            var selectedBird = (from countEvent in myBirds.BirdCounts
                                where countEvent.CountID == formCountID
                                select countEvent).First();

            myBirds.BirdCounts.Remove(selectedBird);
            myBirds.SaveChanges();
            UpdateGridView();
        }
    }
}