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

        public static DataSet GetBirdSet()
        {
            //GOAL:
            //set table 1 of "Birds"
            //set table 2 of "BirdCount"
            //put them into DataSet
            //return DataSet
            try
            {
                string CommandText = "Select * from Bird order by BirdID";
                SqlConnection myConn = new SqlConnection(connectString);
                SqlCommand myCmd = new SqlCommand(CommandText, myConn);

                SqlDataAdapter birdsAdapter = new SqlDataAdapter(myCmd);
                DataRelation birdDataRelation;
                DataSet birdsDataSet = new DataSet("Birds DataSet");

                birdsAdapter.Fill(birdsDataSet, "BirdSet");

                birdsAdapter.SelectCommand.CommandText = "Select * from [BirdCount] order by BirdID";
                birdsAdapter.Fill(birdsDataSet, "BirdCountSet");

                //set up the relationship between the 2 tables
                birdDataRelation = new DataRelation("UsefulRelation",
                    birdsDataSet.Tables["BirdSet"].Columns["BirdID"],
                    birdsDataSet.Tables["BirdCountSet"].Columns["BirdID"]);
                birdsDataSet.Relations.Add(birdDataRelation); // add it to the property which is a List<DataRelation>

                return birdsDataSet;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException(sqlErrorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
