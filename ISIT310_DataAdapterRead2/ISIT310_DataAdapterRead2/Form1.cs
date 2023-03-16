using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Network;

namespace ISIT310_DataAdapterReads2
{
    public partial class Form1 : Form
    {
        private DataSet BirdDataSet;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get Data
            BirdDataSet = DBaccess.GetBirdSet();

            dataGridView1.DataSource = BirdDataSet;
            dataGridView1.DataMember = "BirdSet";

            dataGridView2.DataSource = BirdDataSet;
            dataGridView2.DataMember = "BirdSet.UsefulRelation";
        }

        private void moveFirst_Click(object sender, EventArgs e)
        {
            this.BindingContext[BirdDataSet, "BirdSet"].Position = 0;
        }

        private void moveNext_Click(object sender, EventArgs e)
        {
            this.BindingContext[BirdDataSet, "BirdSet"].Position += 1;
        }

        private void movePrevious_Click(object sender, EventArgs e)
        {
            this.BindingContext[BirdDataSet, "BirdSet"].Position -= 1;
        }

        private void moveLast_Click(object sender, EventArgs e)
        {
            this.BindingContext[BirdDataSet, "BirdSet"].Position = this.BindingContext[BirdDataSet, "BirdSet"].Count - 1;
        }
    }
}
