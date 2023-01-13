using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog210_1stDBAccess_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // prepare and format the listView
            listView1.BackColor = System.Drawing.Color.LightBlue;  // just playing with the listview props and appearance
            listView1.ForeColor = System.Drawing.Color.Blue;
            listView1.BorderStyle = BorderStyle.Fixed3D;
            listView1.View = View.Details;  // just like file explorer, there are several view options
            listView1.Columns.Add("CompanyName", 200, HorizontalAlignment.Left);  // these numbers are pixels, not characters
            listView1.Columns.Add("Phone", 100, HorizontalAlignment.Left);
           
            listView1.GridLines = true;


            // our 3 ADO objects for reading data from Prog123:  SqlConnection  SqlCommand  SqlDataReader  

            //// (the @ tells C# to accept funny characters, like the \  )
            const string connectString = @"Server=localhost; Database=northwind; Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectString);
            // using the constructor that accpets the connection string, one of several choices

            SqlCommand selectCommand = new SqlCommand("Select CompanyName, Phone from Shippers", connection);
            // using the constructor that accpets the SQL command string, and the connection
            // one of several choices. Those are just properties that can be set after you create the object

            //open the database connection
            selectCommand.Connection.Open();

            // define a variable of type Reader  as that is what this sql command 
            // will return from the ExecuteReader method call
            SqlDataReader sqlReader = selectCommand.ExecuteReader();

            // note our command specified 2 columns
            //SqlCommand("Select CompanyName, Phone from Shippers)"
            // we will access them using the objects indexer   [0] company name  [1] Phone

            while (sqlReader.Read()) // reader object returns a false when there are no more rows
            {
                listView1.Items.Add(sqlReader[0].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(sqlReader[1].ToString());
            }

            //while (sqlReader.Read()) // or can use the column names directly
            //{
            //    listView1.Items.Add(sqlReader["CompanyName"].ToString());
            //    listView1.Items[listView1.Items.Count - 1].SubItems.Add(sqlReader["Phone"].ToString());
            //}

            sqlReader.Close();
            selectCommand.Connection.Close();
            
        }
        }
    }

