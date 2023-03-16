using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class NorthwindData
    {
        private const string connectString = @"Data Source=.;Initial Catalog = Northwind;Integrated Security=SSPI";
        private const string sqlErrorMessage = "Database operation failed.  Please contact your System Administrator.";

        public static DataSet GetProductInfo()
        {
           
            try
            {
                //Instantiate the data adapter
                SqlDataAdapter productsDataAdapter = new SqlDataAdapter();

                //Instantiate the dataset
                DataSet internalDataSet = new DataSet();

                //Configure the DataAdapter
                productsDataAdapter.SelectCommand = new SqlCommand();

                productsDataAdapter.SelectCommand.CommandText =
                    "Select ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,DisContinued from Products order by ProductID";

                productsDataAdapter.SelectCommand.Connection = new SqlConnection();
                productsDataAdapter.SelectCommand.Connection.ConnectionString = connectString;

                //Retrieve data from the database
                productsDataAdapter.Fill(internalDataSet, "Products");

                //********************************************************************************
                ////now we wish to fill another table ,    //so we change the command text
                productsDataAdapter.SelectCommand.CommandText =
                   "Select * from [Suppliers]"; // <<<<<<<<<<<<<<<<<<<<<<

                //now we contact the database again
                // and add another table to the dataset
                productsDataAdapter.Fill(internalDataSet, "Suppliers");


                //==========================================================
                // the Database will reject any changes that conflict with its
                // ref integ rules, but that is after-the-fact ...
                // if you replicate the rule(s) here in the DataSet, then the
                // user will get told in the form when they make a mistake
                // this one prevents deleting a product that is currently
                // in an order


                ForeignKeyConstraint myFKeyConstraint2;
                myFKeyConstraint2 = new ForeignKeyConstraint("Prod-Supplier-FK",
                   internalDataSet.Tables["Suppliers"].Columns["SupplierID"],
                 internalDataSet.Tables["Products"].Columns["SupplierID"]);
                myFKeyConstraint2.DeleteRule = Rule.Cascade;
                myFKeyConstraint2.UpdateRule = Rule.Cascade;
                
                internalDataSet.Tables["Products"].Constraints.Add(myFKeyConstraint2);

                internalDataSet.EnforceConstraints = true;


                //************************************************************

                return internalDataSet;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException(sqlErrorMessage);
            }
            catch (Exception ex)
            {
                //send the exception to the presentation tier 
                throw ex;
            }


        }


        // Update the database with changes from the DataSet
        public static int SaveProductInfo(DataSet productsDataSet)
        {
            int rowCount;
          
            //Instantiate the data adapter
            SqlDataAdapter productDataAdapter = new SqlDataAdapter();

            try
            {

                //Configure the DataAdapter

                //INSERT Command
                productDataAdapter.InsertCommand = new SqlCommand();
                productDataAdapter.InsertCommand.CommandText =
                    "INSERT into Products" +
                    "(ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,DisContinued) " +
                    "VALUES (@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@DisContinued)";

                productDataAdapter.InsertCommand.Connection = new SqlConnection();
                productDataAdapter.InsertCommand.Connection.ConnectionString = connectString;

                //Set up the parameters for the insert command.  NOTE: compared to video, I used the other way of setting
                // up these Params.  Mine includes the datatype, for better DB integrity
                // I used SSMS, Table "Products", right click "design" to see what the types are

                productDataAdapter.InsertCommand.Parameters.Add("@ProductName", System.Data.SqlDbType.NVarChar, 40);
                productDataAdapter.InsertCommand.Parameters["@ProductName"].SourceColumn = "ProductName";

                productDataAdapter.InsertCommand.Parameters.Add("@SupplierID", System.Data.SqlDbType.Int);
                productDataAdapter.InsertCommand.Parameters["@SupplierID"].SourceColumn = "SupplierID";

                productDataAdapter.InsertCommand.Parameters.Add("@CategoryID", System.Data.SqlDbType.Int);
                productDataAdapter.InsertCommand.Parameters["@CategoryID"].SourceColumn = "CategoryID";

                productDataAdapter.InsertCommand.Parameters.Add("@QuantityPerUnit", System.Data.SqlDbType.NVarChar, 20);
                productDataAdapter.InsertCommand.Parameters["@QuantityPerUnit"].SourceColumn = "QuantityPerUnit";

                productDataAdapter.InsertCommand.Parameters.Add("@UnitPrice", System.Data.SqlDbType.Money);
                productDataAdapter.InsertCommand.Parameters["@UnitPrice"].SourceColumn = "UnitPrice";

                productDataAdapter.InsertCommand.Parameters.Add("@Discontinued", System.Data.SqlDbType.Bit);
                productDataAdapter.InsertCommand.Parameters["@Discontinued"].SourceColumn = "Discontinued";


                //UPDATE Command  ----------------------------------------------------------------------------------------------------------

                productDataAdapter.UpdateCommand = new SqlCommand();

                //note that we do not need a new connection
                // we can use the same connection as that used by the InsertCommand 
                productDataAdapter.UpdateCommand.Connection = productDataAdapter.InsertCommand.Connection;

                // here is the prototype SQL for the Update Command
                productDataAdapter.UpdateCommand.CommandText =
                    " UPDATE Products " +
                    " SET ProductName = @ProductName , " +
                    " SupplierID = @SupplierID, " +
                    " CategoryID =@CategoryID, " +
                    " QuantityPerUnit= @QuantityPerUnit," +
                    " UnitPrice=@UnitPrice, " +
                    " DisContinued=@DisContinued " +
                     " WHERE ProductID = @ProductID";

                //Set up the parameters for the update command  (need to change from productDataAdapter.InsertCommand.Parameters
                // to productDataAdapter.UpdateCommand.Parameters

                productDataAdapter.UpdateCommand.Parameters.Add("@ProductID", System.Data.SqlDbType.Int);
                productDataAdapter.UpdateCommand.Parameters["@ProductID"].SourceColumn = "ProductID";

                productDataAdapter.UpdateCommand.Parameters.Add("@ProductName", System.Data.SqlDbType.NVarChar, 40);
                productDataAdapter.UpdateCommand.Parameters["@ProductName"].SourceColumn = "ProductName";

                productDataAdapter.UpdateCommand.Parameters.Add("@SupplierID", System.Data.SqlDbType.Int);
                productDataAdapter.UpdateCommand.Parameters["@SupplierID"].SourceColumn = "SupplierID";

                productDataAdapter.UpdateCommand.Parameters.Add("@CategoryID", System.Data.SqlDbType.Int);
                productDataAdapter.UpdateCommand.Parameters["@CategoryID"].SourceColumn = "CategoryID";

                productDataAdapter.UpdateCommand.Parameters.Add("@QuantityPerUnit", System.Data.SqlDbType.NVarChar, 20);
                productDataAdapter.UpdateCommand.Parameters["@QuantityPerUnit"].SourceColumn = "QuantityPerUnit";

                productDataAdapter.UpdateCommand.Parameters.Add("@UnitPrice", System.Data.SqlDbType.Money);
                productDataAdapter.UpdateCommand.Parameters["@UnitPrice"].SourceColumn = "UnitPrice";

                productDataAdapter.UpdateCommand.Parameters.Add("@Discontinued", System.Data.SqlDbType.Bit);
                productDataAdapter.UpdateCommand.Parameters["@Discontinued"].SourceColumn = "Discontinued";

                //DELETE Command

                productDataAdapter.DeleteCommand = new SqlCommand();

                //note that we do not need a new connection
                // we can use the same connection as that used by the InsertCommand 
                productDataAdapter.DeleteCommand.Connection = productDataAdapter.InsertCommand.Connection;

                productDataAdapter.DeleteCommand.CommandText =
                    "Delete from [Order Details] where ProductID = @ProductID; " +  // added to use FK cascading
                " Delete from Products where ProductID = @ProductID";

                //Set up the parameters for the delete command.  

                productDataAdapter.DeleteCommand.Parameters.Add("@ProductID", System.Data.SqlDbType.Int);
                productDataAdapter.DeleteCommand.Parameters["@ProductID"].SourceColumn = "ProductID";

                //GO
                // explicitly open connection
                productDataAdapter.InsertCommand.Connection.Open();

                //Use the DataAdapter to update the database
                rowCount = productDataAdapter.Update(productsDataSet, "Products");

                return rowCount;
            }

            //catch (SqlException sqlEx)
            //{
            //    throw new ApplicationException(sqlErrorMessage);
            //}

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                //close the connection
                productDataAdapter.InsertCommand.Connection.Close();
            }
        }


    }
}




