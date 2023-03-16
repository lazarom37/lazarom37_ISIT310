using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAdapter_Writes_1
{
    public partial class ProductDisplayForm : Form
    {
        public ProductDisplayForm()
        {
            InitializeComponent();
        }

        private DataSet productsDataSet;  // define our DataSet at the class level so all methods can access

        private void ProductDisplayForm_Load(object sender, EventArgs e)
        {
            refreshFromSQL();
        }

        private void refreshFromSQL()
        {
            try
            {
                productsDataSet = NorthwindData.GetProductInfo();

                // notice I did not have to create headings on the dataGridView
                // it picks them up from the DataTable fields
                dataGridViewProducts.DataSource = productsDataSet;
                dataGridViewProducts.DataMember = "Products";
                dataGridViewProducts.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Aquamarine;  // colors
                dataGridViewProducts.AutoResizeColumns();  // sizing
                dataGridViewProducts.Columns["ProductID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshFromSQL();
        }

        // notice that we have a delete button, but no add or modify button
        // the dataGridView allows us to edit right inside of it, and it will talk to the Binding
        // Context object which will edit the datatable in memory.
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // use our BindingContext object to get the ROW that is selected when button clicked
                // it gives us an integer index from the datGridView which will match the index
                // of the in memory datatable
                int pointer = this.BindingContext[productsDataSet, "Products"].Position;
                // select a row in the datatable and it has a "Delete()" method.  
                // all this does is mark it for delete, it is still in SQL
                productsDataSet.Tables["Products"].Rows[pointer].Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                int searchValue = Convert.ToInt32(textBoxProductID.Text);  // get the ProductID from the text box
                int rowIndex = -1;
                // loop thru all rows in the dataGridView to find the row that matches
                foreach (DataGridViewRow row in dataGridViewProducts.Rows)
                {
                    if ((int)(row.Cells["ProductID"].Value) == (searchValue))
                    {
                        rowIndex = row.Index; // ok, got the index
                        break;
                    }
                }
                // using the integer Indexer instead of the named one, just to show its possible
                // flip it from whatever state it was to the other
                if (dataGridViewProducts.Rows[rowIndex].Cells[6].Value.ToString() == "True")
                {
                    productsDataSet.Tables["Products"].Rows[rowIndex]["Discontinued"] = "False";
                }
                else
                {
                    productsDataSet.Tables["Products"].Rows[rowIndex]["Discontinued"] = "True";
                }
                textBoxProductID.Text = ""; // clear the text box
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {
          

            try
            {
                // If you add a new row, the Discontinued column is not getting set to "false", it is null,
                // then the insert fails, so the code below marks any row that is not True to False
                for (var i = 0; i < productsDataSet.Tables["Products"].Rows.Count; i++) 
                {
                    // but if any row is marked for delete, then this code will fail, so avoid that!
                    if (productsDataSet.Tables["Products"].Rows[i].RowState != DataRowState.Deleted)
                    {

                        if ((productsDataSet.Tables["Products"].Rows[i]["Discontinued"].ToString() != "True") &&
                                (productsDataSet.Tables["Products"].Rows[i]["Discontinued"].ToString() != "False"))
                        {
                            productsDataSet.Tables["Products"].Rows[i]["Discontinued"] = false; // Sets the value to something accepted by the Database.    
                        }
                    }

                }
                NorthwindData.SaveProductInfo(productsDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
