using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISIT310_firstEF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            BirdsEntities myBirds = new BirdsEntities();

            var birdsQuery =
                //from birdFound in myBirds.Birds
                from birdCountFound in myBirds.BirdCounts
                where birdCountFound.Bird.BirdID == birdCountFound.BirdID //Adjusted using navigation property instead
                orderby birdCountFound.Counted ascending
                select new
                {
                    BirderID = birdCountFound.BirderID, //is now properly using BirderID
                    Counted = birdCountFound.Counted,
                    Name = birdCountFound.Bird.Name //used to be Name = birdFound.Name
                };

            dataGridView1.DataSource = birdsQuery.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
