using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class DBaccess
    {
        private const string connectString = @"Server=localhost; Database= Birds; Integrated Security=True";
        static public List<CountRowReturn> GetCountData()
        {
            List<CountRowReturn> DataList = new List<CountRowReturn>();
            SqlDataReader birdReader;  //datareader
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = new SqlConnection(connectString);
            selectCommand.CommandText =
                    "SELECT Region.RegionName, Bird.Name, Birder.BirderName, BirdCount.CountDate, BirdCount.Counted " +
                        "FROM Bird INNER JOIN " +
                         "BirdCount ON Bird.BirdID = BirdCount.BirdID INNER JOIN " +
                         "Birder ON BirdCount.BirderID = Birder.BirderID INNER JOIN " +
                         "Region ON BirdCount.RegionID = Region.RegionID " +
                         "ORDER BY RegionName";
            selectCommand.Connection.Open();

            birdReader = selectCommand.ExecuteReader();  //execute sql against the database

            //use data reader to retrieve rows one at a time
            while (birdReader.Read())
            {
                CountRowReturn tempRow = new CountRowReturn();
                tempRow.Birder = birdReader["BirderName"].ToString();
                tempRow.Bird = birdReader["Name"].ToString();
                tempRow.Region = birdReader["RegionName"].ToString();
                tempRow.Count = (int)birdReader["Counted"];
                tempRow.CountDate = (DateTime)birdReader["CountDate"];
                DataList.Add(tempRow);
            }

            birdReader.Close();  //close the data reader
            return DataList;
        }

        public static List<Bird> GetBird()
        {
            SqlConnection connection = new SqlConnection(connectString);
            SqlCommand commRegion = new SqlCommand("SELECT BirdID, Name FROM Bird", connection);
            List<Bird> BirdList = new List<Bird>();
            try
            {
                connection.Open();
                SqlDataReader reader = commRegion.ExecuteReader();
                while (reader.Read())
                {
                    Bird tempBird = new Bird();
                    tempBird.BirdID = reader["BirdID"].ToString();
                    tempBird.Name = reader["Name"].ToString();
                    BirdList.Add(tempBird);   // add the new object to the List
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birds DB: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return BirdList;
        }

        public static string AddBird(string pNewBird, string pNewID, string pNewDesc)  // adds one new type of bird to the Bird table
        {
            string returnString = "failed to add new bird";
            try
            {
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = new SqlConnection(connectString);
                insertCommand.CommandText = "INSERT INTO Bird (Name, BirdID, Description) VALUES( @Name, @ID, @DESC) ";
                // define the 1 Parameter since we cannot trust the textbox data
                insertCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                insertCommand.Parameters["@Name"].Value = pNewBird;

                insertCommand.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar);
                insertCommand.Parameters["@ID"].Value = pNewID;

                insertCommand.Parameters.Add("@DESC", System.Data.SqlDbType.NVarChar);
                insertCommand.Parameters["@DESC"].Value = pNewDesc;

                insertCommand.Connection.Open();
                insertCommand.ExecuteNonQuery();
                insertCommand.Connection.Close();
                returnString = "success, " + pNewBird + " added.";  // if we got this far, must have been successful.
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birds DB: " + ex);
            }
           
            return returnString;
            
        }

        public static string AddBirder(int pNewID, string pBirderName, string pPhone)  // adds one new type of bird to the Bird table
        {
            string returnString = "failed to add new birder";
            try
            {
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = new SqlConnection(connectString);
                insertCommand.CommandText = "INSERT INTO Birder (BirderID, BirderName, Phone) VALUES( @ID, @Name, @Phone) ";
                // define the 1 Parameter since we cannot trust the textbox data

                insertCommand.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar);
                insertCommand.Parameters["@ID"].Value = pNewID;

                insertCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                insertCommand.Parameters["@Name"].Value = pBirderName;

                insertCommand.Parameters.Add("@Phone", System.Data.SqlDbType.NVarChar);
                insertCommand.Parameters["@Phone"].Value = pPhone;

                insertCommand.Connection.Open();
                insertCommand.ExecuteNonQuery();
                insertCommand.Connection.Close();
                returnString = "success, " + pBirderName + " added.";  // if we got this far, must have been successful.
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birders DB: " + ex);
            }

            return returnString;

        }

        public static string AddRegion(string pNewRegion, string pNewID)  // adds one new type of bird to the Bird table
        {
            string returnString = "failed to add new region";
            try
            {
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = new SqlConnection(connectString);
                insertCommand.CommandText = "INSERT INTO Region (RegionName, RegionID) VALUES( @Name, @ID) ";
                // define the 1 Parameter since we cannot trust the textbox data
                insertCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                insertCommand.Parameters["@Name"].Value = pNewRegion;

                insertCommand.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar);
                insertCommand.Parameters["@ID"].Value = pNewID;

                insertCommand.Connection.Open();
                insertCommand.ExecuteNonQuery();
                insertCommand.Connection.Close();
                returnString = "success, " + pNewRegion + " added.";  // if we got this far, must have been successful.
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Regions DB: " + ex);
            }

            return returnString;

        }

        public static List<Birder> GetBirder()
        {
            SqlConnection connection = new SqlConnection(connectString);
            SqlCommand commRegion = new SqlCommand("SELECT BirderID, BirderName FROM Birder", connection);
            List<Birder> BirderList = new List<Birder>();
            try
            {
                connection.Open();
                SqlDataReader reader = commRegion.ExecuteReader();
                while (reader.Read())
                {
                    Birder tempBirder = new Birder();
                    tempBirder.BirderID = Convert.ToInt32(reader["BirderID"]);
                    tempBirder.BirderName = reader["BirderName"].ToString();
                    BirderList.Add(tempBirder);   // add the new object to the List
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birds DB: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return BirderList;
        }

        public static void AddCount(CountRow addCountRow)  // add a row of data to the BirdCount table
        {
            try
            {
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = new SqlConnection(connectString);
                insertCommand.CommandText =
                    "INSERT INTO BirdCount (BirderID, BirdID, RegionID, Counted, CountDate ) VALUES( " + addCountRow.BirderID + " , '" + addCountRow.BirdID + "' , '" + addCountRow.RegionID + "' ,  @Counted, @CountDate) ";
                // define the 2 Parameters since we cannot trust the textbox data
                insertCommand.Parameters.Add("@Counted", System.Data.SqlDbType.Int);
                insertCommand.Parameters["@Counted"].Value = addCountRow.Count;

                insertCommand.Parameters.Add("@CountDate", System.Data.SqlDbType.Date);
                insertCommand.Parameters["@CountDate"].Value = addCountRow.CountDate;

                insertCommand.Connection.Open();
                insertCommand.ExecuteNonQuery();
                insertCommand.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birds DB: " + ex);
                // ): Invalid column name 'A300'.
            }

        }

        // this code gets the Region names and IDs for the ListBox.  You will need two more methods like this for the other 2 new ListBoxes that you add.
        public static List<Regions> GetRegions()  // create a list of Region objects, one for each row of data in the Regions table
        {
            SqlConnection connection = new SqlConnection(connectString);
            SqlCommand commRegion = new SqlCommand("SELECT RegionID, RegionName FROM Region", connection);
            List<Regions> RegionList = new List<Regions>();
            try
            {
                connection.Open();
                SqlDataReader reader = commRegion.ExecuteReader();
                while (reader.Read())
                {
                    Regions tempRegion = new Regions();
                    tempRegion.RegionID = reader["RegionID"].ToString();
                    tempRegion.RegionName = reader["RegionName"].ToString();
                    RegionList.Add(tempRegion);   // add the new object to the List
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birds DB: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return RegionList;
        }
    } // end of DBaccess class


    // classes needed to transport SQL row data in the form of a C# object

    public class CountRow
    {
        public string RegionID { get; set; }
        public string BirdID { get; set; }
        public int BirderID { get; set; }
        public int Count { get; set; }
        public DateTime CountDate { get; set; }
    }

    public class CountRowReturn
    {
        public string Region { get; set; }
        public string Bird { get; set; }
        public string Birder { get; set; }
        public int Count { get; set; }
        public DateTime CountDate { get; set; }
    }

    public class Regions
    {
        public string RegionID { get; set; }
        public string RegionName { get; set; }
    }

    public class Bird
    {
        public string BirdID { get; set; }
        public string Name { get; set; }
    }

    public class Birder
    {
        public int BirderID { get; set; }
        public string BirderName { get; set; }
    }
}