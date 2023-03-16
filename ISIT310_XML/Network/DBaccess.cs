using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public static class DBaccess
    {
        //Note:  If your server is not named localhost, you will need to change the connection string
        // private const string connectString = @"Server = localhost;Database=Northwind;Integrated Security=SSPI";
        private const string connectString = @"Server = .;Database=Birds;Integrated Security=SSPI";

        // Generic error message for database issues
        private const string sqlErrorMessage = "Database operation failed.  Please contact your System Administrator";

        public static XMLdataSet GetBirdSet()
        {
            SqlDataAdapter xmlDataAdapter;   // takes rows returned from database and puts them into dataset

            xmlDataAdapter = new SqlDataAdapter();  //Instantiate the data adapter
            XMLdataSet internalXMLdataSet = new XMLdataSet(); //Instantiate the dataset

            try
            {
                xmlDataAdapter.SelectCommand = new SqlCommand();

                xmlDataAdapter.SelectCommand.CommandText = "Select * from BirdCount order by CountID";
                xmlDataAdapter.SelectCommand.Connection = new SqlConnection();
                xmlDataAdapter.SelectCommand.Connection.ConnectionString = connectString;

                xmlDataAdapter.Fill(internalXMLdataSet, "BirdCount");

                return internalXMLdataSet;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateBirdCount(XMLdataSet internalDataSet)
        {

            int rowCount;
            SqlDataAdapter xmlDataAdapter;

            //Instantiate the data adapter
            xmlDataAdapter = new SqlDataAdapter();

            try
            {

                //Configure the DataAdapter

                //INSERT Command
                xmlDataAdapter.InsertCommand = new SqlCommand();
                xmlDataAdapter.InsertCommand.CommandText =
                    "INSERT into BirdCount" +
                    "(CountID,RegionID,BirderID,BirdID,CountDate,Counted) " +
                    "VALUES (@CountID,@RegionID,@BirderID,@BirdID,@CountDate,@Counted)";

                xmlDataAdapter.InsertCommand.Connection = new SqlConnection();
                xmlDataAdapter.InsertCommand.Connection.ConnectionString = connectString;

                //Set up the parameters for the insert command

                xmlDataAdapter.InsertCommand.Parameters.Add("@CountID", System.Data.SqlDbType.Int);
                xmlDataAdapter.InsertCommand.Parameters["@CountID"].SourceColumn = "CountID";

                xmlDataAdapter.InsertCommand.Parameters.Add("@RegionID", System.Data.SqlDbType.NVarChar, 5);
                xmlDataAdapter.InsertCommand.Parameters["@RegionID"].SourceColumn = "RegionID";

                xmlDataAdapter.InsertCommand.Parameters.Add("@BirderID", System.Data.SqlDbType.Int);
                xmlDataAdapter.InsertCommand.Parameters["@BirderID"].SourceColumn = "BirderID";

                xmlDataAdapter.InsertCommand.Parameters.Add("@BirdID", System.Data.SqlDbType.NVarChar, 10);
                xmlDataAdapter.InsertCommand.Parameters["@BirdID"].SourceColumn = "BirdID";

                xmlDataAdapter.InsertCommand.Parameters.Add("@CountDate", System.Data.SqlDbType.SmallDateTime);
                xmlDataAdapter.InsertCommand.Parameters["@CountDate"].SourceColumn = "CountDate";

                xmlDataAdapter.InsertCommand.Parameters.Add("@Counted", System.Data.SqlDbType.Int);
                xmlDataAdapter.InsertCommand.Parameters["@Counted"].SourceColumn = "Counted";

                xmlDataAdapter.InsertCommand.Connection.Open();
                rowCount = xmlDataAdapter.Update(internalDataSet, "BirdCount");
                return rowCount;


            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException(sqlErrorMessage);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                xmlDataAdapter.InsertCommand.Connection.Close();
            }
        }
    }
}
