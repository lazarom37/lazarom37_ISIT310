using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISIT310_LINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //instantiate a copy of the DBML
            DataClasses1DataContext myDBML = new DataClasses1DataContext();
            //define LINQ query that generates FROM collection with all orders WHERE ShipCity = Seattle || Portland
            var orderQuery =
                from orderFound in myDBML.Orders
                where (orderFound.ShipCity == "Seattle") || (orderFound.ShipCity == "Portland")
                orderby orderFound.ShipCity descending
                select new
                {
                    City = orderFound.ShipCity,
                    DateOfOrder = orderFound.OrderDate,
                    Company = orderFound.Shipper.CompanyName,
                    ShipperName = orderFound.Customer.ContactName
                };
            dataGridView1.DataSource = orderQuery;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}