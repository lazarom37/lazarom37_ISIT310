using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this code runs before the first screen is drawn

            // populate the first of 3 listBox's  (NOT commboboxes, we want to se listBox
            // create a list of objects of type Region (which I had to define)
            // and then ask the SQL method GetRegions to popluate with this call
            List<Regions> RegionList = DBaccess.GetRegions();
           
            // now set up the listBox to get its data from that List
            listBoxRegions.DataSource = RegionList;

            // and set the hidden, corresponding value to be the DB key value for that Name
            listBoxRegions.ValueMember = "RegionID";

            // tell it to show the Name property to the user
            listBoxRegions.DisplayMember = "RegionName";

            //====================================================================
            List<Bird> BirdList = DBaccess.GetBird();

            // now set up the listBox to get its data from that List
            listBoxBird.DataSource = BirdList;

            // and set the hidden, corresponding value to be the DB key value for that Name
            listBoxBird.ValueMember = "BirdID";

            // tell it to show the Name property to the user
            listBoxBird.DisplayMember = "BirderName";


            //==============================================
            List<Birder> BirderList = DBaccess.GetBirder();

            // now set up the listBox to get its data from that List
            listBoxBirder.DataSource = BirderList;

            // and set the hidden, corresponding value to be the DB key value for that Name
            listBoxBirder.ValueMember = "BirderID";

            // tell it to show the Name property to the user
            listBoxBirder.DisplayMember = "BirderName";

            //=====================================


            // need to repeat that sort of code after you add 2 new listBox's named listBoxBirds and listBox Birders.
            // You also have to define two new Classes, Bird and Birder as I did for a new Region class

            updateScreen();
        }

        private void updateScreen()
        {
            dataGridView1.DataSource = DBaccess.GetCountData();
            dataGridView1.AutoResizeColumns();
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            CountRow addCountRow = new CountRow();
            addCountRow.RegionID = (listBoxRegions.SelectedValue).ToString();
            addCountRow.BirderID = ((int)listBoxBirder.SelectedValue);                               //  <<<<<<<<   need to change this to get value from a new listBoxBirders
            addCountRow.BirdID = (listBoxBird.SelectedValue).ToString();                                 //  <<<<<<<<   need to change this to get value from a new listBoxBirds
            addCountRow.Count = Convert.ToInt32(textBoxCount.Text);
            addCountRow.CountDate = Convert.ToDateTime(textBoxDate.Text);
            DBaccess.AddCount(addCountRow);

            updateScreen();  // refresh the display
        }

        private void buttonAddRegion_Click(object sender, EventArgs e)
        {
            new FormNewRegion().Show();  // opens and starts another form
        }

        private void buttonAddBirdType_Click(object sender, EventArgs e)
        {
            new FormNewBird().Show(); // opens and starts another form
        }

        private void buttonAddBirder_Click(object sender, EventArgs e)
        {
            new FormNewBirder().Show(); // opens and starts another form
        }
    }
}
