using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_FromModel
{
    public partial class Form1 : Form
    {
        OrderModelContainer1 myData = new OrderModelContainer1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order newOrder = new Order();

            newOrder.OrderID = Convert.ToInt32(textBox2.Text);
            newOrder.Supplier = (Supplier)comboBox1.SelectedItem;
            newOrder.OrderDate = DateTime.Now;
            newOrder.Quantity = Convert.ToInt32(textBox1.Text);
            newOrder.Part = (Part)comboBox2.SelectedItem;
            myData.Orders.Add(newOrder);
            myData.SaveChanges();
            RefreshData();

        }

        public void RefreshData()
        {
            var query = from eachOrder in myData.Orders
                        select new
                        {
                            eachOrder.OrderID,
                            eachOrder.Supplier.CompanyName,
                            eachOrder.Supplier.PhoneNumber,
                            eachOrder.OrderDate,
                            eachOrder.Quantity,
                            eachOrder.Part.PartName
                        };
            dataGridView1.DataSource = query.ToList();

            //Load up comboboxes (dropdowns)
            //Suppliers
            comboBox1.DataSource = myData.Suppliers.ToList();
            comboBox1.DisplayMember = "Supplier";
            comboBox1.ValueMember = "CompanyName";
            comboBox1.SelectedIndex = -1;
            //Part Name
            comboBox2.DataSource = myData.Parts.ToList();
            comboBox2.DisplayMember = "Part";
            comboBox2.ValueMember = "PartName";
            comboBox2.SelectedIndex = -1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
