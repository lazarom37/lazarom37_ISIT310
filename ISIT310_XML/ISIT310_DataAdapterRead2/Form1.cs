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
        static string currentDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RemoteBirdClub.xml";
        XMLdataSet BirdCountData;
        public Form1()
        {
            InitializeComponent();
            BirdCountData = new XMLdataSet();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Reads XML
            try
            {
                //clear the current dataGridView
                BirdCountData.BirdCount.Clear();
                //Read the XML
                BirdCountData.ReadXml(currentDocPath);
                //Actually prints the data
                dataGridView1.DataSource = BirdCountData.BirdCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Reads Database
            try
            {
                BirdCountData = DBaccess.GetBirdSet();
                dataGridView2.DataSource = BirdCountData.BirdCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Save to database
            DBaccess.UpdateBirdCount(BirdCountData);
        }
    }
}
