using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
using MySqlConnector;

namespace rangdong_agv
{
    public class MySqlDAO
    {
        private MySqlConnection connection;
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;

        public MySqlDAO()
        {
            Initialize();
        }

        //Initialize values
        // To be updated: using a properties file to store database access information
        private void Initialize()
        {
            server = "localhost";
            //server = "127.0.0.1";
            port = "3306";
            //database = "rangdong_agv";
            database = "agv_update";
            uid = "root"; // username
            password = "17061999";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        //Trace.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        Console.WriteLine("Invalid username/password, please try again");
                        //Trace.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // *************************************************
        // AGV Parameter table
        //Insert statement
        public void insertAgvParameters(AgvParams agvParams)
        {
            // insert into database
        }

        public void getAgvParametersById(AgvParams agvParams)
        {
            // get from database
        }

        public void getAgvParametersById(int agvId)
        {
            // get from database
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        // *************************************************
        // AgvInfo table
        public List<AgvInfo> GetAllAgvInfo()
        {
            string query = "SELECT * FROM agvinfo";

            //Create a list to store the result
            List<AgvInfo> agvList = new List<AgvInfo>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    AgvInfo agvInfoRead = new AgvInfo();
                    agvInfoRead.AgvID = Convert.ToInt32(dataReader["agvid"]);
                    agvInfoRead.ZoneId = Convert.ToInt32(dataReader["zoneid"]);
                    agvInfoRead.ParkingLot = Convert.ToInt32(dataReader["parkinglot"]);
                    agvInfoRead.SetFullId();
                    agvList.Add(agvInfoRead);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return agvList;
            }
            else
            {
                return agvList;
            }
        }
        public List<AgvActiveInMonth> getAgvById(int id)
        {
            string query = "SELECT * FROM month_active_agv WHERE agv_id = " + id + "";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data
                List<AgvActiveInMonth> agvInfoReads = new List<AgvActiveInMonth>();
                while (dataReader.Read())
                {
                    AgvActiveInMonth agvInfoRead = new AgvActiveInMonth();
                    agvInfoRead.TotalActiveHour = Convert.ToInt32(dataReader["totalActiveHour"]);
                    agvInfoRead.Time = (DateTime)dataReader["time"];
                    agvInfoReads.Add(agvInfoRead);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return agvInfoReads;
            }
            else
            {
                return null;
            }
        }

        public AgvInfo getAgvInfoById(int agvId)
        {
            string query = "SELECT * FROM agv_material WHERE trip_id = " + agvId + "";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data
                AgvInfo agvInfoRead = new AgvInfo();
                while (dataReader.Read())
                {
                    agvInfoRead.timestamp = Convert.ToInt32(dataReader["timestamp"]);
                    agvInfoRead.timeComplete = Convert.ToInt32(dataReader["timeComplete"]);
                    agvInfoRead.SetFullId();
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return agvInfoRead;
            }
            else
            {
                return null;
            }
        }

        // *************************************************
        // RFID related table
        public void getAllTagLayout()
        {
            string query = "SELECT * FROM `tag_layout`";

            ////Create a list to store the result
            //List<TagLayout> tagLayoutList = new List<TagLayout>();

            ////Open connection
            //if (this.OpenConnection() == true)
            //{
            //    //Create Command
            //    MySqlCommand cmd = new MySqlCommand(query, connection);
            //    //Create a data reader and Execute the command
            //    MySqlDataReader dataReader = cmd.ExecuteReader();

            //    //Read the data and store them in the list
            //    while (dataReader.Read())
            //    {
            //        AgvInfo agvInfoRead = new AgvInfo();
            //        agvInfoRead.AgvID = Convert.ToInt32(dataReader["agvid"]);
            //        agvInfoRead.ZoneId = Convert.ToInt32(dataReader["zoneid"]);
            //        agvInfoRead.ParkingLot = Convert.ToInt32(dataReader["parkinglot"]);
            //        agvInfoRead.SetFullId();
            //        agvList.Add(agvInfoRead);
            //    }

            //    //close Data Reader
            //    dataReader.Close();

            //    //close Connection
            //    this.CloseConnection();

            //    //return list to be displayed
            //    return agvList;
            //}
            //else
            //{
            //    return agvList;
            //}
        }

        // get neighbor exclude -1 value
        public List<byte> getTagNeighborByTagId(int tag_id)
        {
            string query = "SELECT neighbor,command FROM `tag_layout`";

            List<byte> neighborIds = new List<byte>();
            //Create a list to store the result
            //List<TagLayout> tagLayoutList = new List<TagLayout>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    TagCommand tagCmd = new TagCommand();
                    int neighborId = Convert.ToInt32(dataReader["neighbor"]);
                    if (neighborId > 0)
                    {
                        tagCmd.TagId = (byte)tag_id;
                        tagCmd.TagCmd = Convert.ToByte(dataReader["command"]);
                        tagCmd.TagNeighbor = Convert.ToByte(dataReader["neighbor"]);
                        neighborIds.Add(tagCmd.TagNeighbor);
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return neighborIds;
            }
            else
            {
                return neighborIds;
            }
            //return 0;
        }

        // get all the neighbors includes -1 value
        public List<int> getTagAllNeighborByTagId(int tag_id)
        {
            string query = "SELECT neighbor,command FROM `tag_layout`";

            List<int> neighborIds = new List<int>();
            //Create a list to store the result
            //List<TagLayout> tagLayoutList = new List<TagLayout>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    int neighbor = Convert.ToInt32(dataReader["command"]);
                    neighborIds.Add(neighbor);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return neighborIds;
            }
            else
            {
                return neighborIds;
            }
            //return 0;
        }

        // get {this tag_id, its neighbor id, command}
        public List<TagCommand> getNeighborTagCommandByTagId(int tag_id)
        {
            string query = "SELECT `neighbor`,`command` FROM `tag_layout` WHERE tag_id=@tag_id";

            List<TagCommand> tagCommands = new List<TagCommand>();
            //Create a list to store the result
            //List<TagLayout> tagLayoutList = new List<TagLayout>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand mysqlCmd = new MySqlCommand(query, connection);
                mysqlCmd.Parameters.AddWithValue("@tag_id", tag_id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = mysqlCmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    TagCommand tagCmd = new TagCommand();
                    int neighborId = Convert.ToInt32(dataReader["neighbor"]);
                    //if (neighborId > 0)
                    //{
                    tagCmd.TagId = (byte)tag_id;
                    int commandTemp = Convert.ToInt32(dataReader["command"]);
                    tagCmd.TagCmd = (byte)commandTemp;
                    tagCmd.TagNeighborInt = neighborId;
                    tagCmd.TagNeighbor = (byte)neighborId;
                    tagCommands.Add(tagCmd);
                    //}
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return tagCommands;
            }
            else
            {
                return tagCommands;
            }
            //return 0;
        }

        // for going backward
        // get (neighbor id as this position tagid, tagid as neighbor id, command_neighbor)
        public List<TagCommand> getTagNeighborCommandByNeighborId(int neighbor_id)
        {
            string query = "SELECT tag_id,neighbor_command FROM `tag_layout` WHERE neighbor=@neighbor";

            List<TagCommand> tagCommands = new List<TagCommand>();
            //Create a list to store the result
            //List<TagLayout> tagLayoutList = new List<TagLayout>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand mysqlCmd = new MySqlCommand(query, connection);
                mysqlCmd.Parameters.AddWithValue("@neighbor", neighbor_id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = mysqlCmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    TagCommand tagCmd = new TagCommand();

                    tagCmd.TagId = (byte)neighbor_id;
                    tagCmd.TagCmd = Convert.ToByte(dataReader["neighbor_command"]);
                    tagCmd.TagNeighbor = Convert.ToByte(dataReader["tag_id"]);
                    //tagCmd.TagNeighborInt = Convert.ToInt32(dataReader["neighbor_command"]);
                    tagCommands.Add(tagCmd);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return tagCommands;
            }
            else
            {
                return tagCommands;
            }
            //return 0;
        }

        public int getBranchIdByTagId(int tag_id)
        {
            string query = "SELECT branch_id FROM `rfid_tags` WHERE tag_id=@tag_id";

            //List<TagCommand> tagCommands = new List<TagCommand>();
            //Create a list to store the result
            //List<TagLayout> tagLayoutList = new List<TagLayout>();

            int branch_id = -1;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand mysqlCmd = new MySqlCommand(query, connection);
                mysqlCmd.Parameters.AddWithValue("@tag_id", tag_id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = mysqlCmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    branch_id = Convert.ToInt32(dataReader["branch_id"]);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return branch_id;
            }
            else
            {
                return branch_id;
            }
            //return 0;
        }

        //Count statement
        public int Count()
        {
            return 0;
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
        public void SaveAgvDailyStatics(AgvDailyStatics agvDailyStatics)
        {

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO  agv_daily_statistics(date,id,active_hour,inactive_hour,distance,total_load,delivery_success) " +
                    "VALUES(@date,@id,@active_hour,@inactive_hour,@distance,@total_load,@delivery_success)";
                cmd.Parameters.AddWithValue("@date", agvDailyStatics.date);
                cmd.Parameters.AddWithValue("@id", agvDailyStatics.id);
                cmd.Parameters.AddWithValue("@active_hour", agvDailyStatics.activeHour);
                cmd.Parameters.AddWithValue("@inactive_hour", agvDailyStatics.inActiveHour);
                cmd.Parameters.AddWithValue("@distance", agvDailyStatics.distance);
                cmd.Parameters.AddWithValue("@total_load", agvDailyStatics.totalLoad);
                cmd.Parameters.AddWithValue("@delivery_success", agvDailyStatics.deliverySuccess);

                cmd.ExecuteNonQuery();

                //close Connection
                this.CloseConnection();
            }
            else
            {

            }


        }
        public void SaveAgvParamsLatest(AgvParamsLatest agvParamsLatest)
        {

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO  agv_params_latest(id,state,speed,v_batt,batt_capacity,position) " +
                    "VALUES(@id,@state,@speed,@v_batt,@batt_capacity,@position)";
                cmd.Parameters.AddWithValue("@id", agvParamsLatest.id);
                cmd.Parameters.AddWithValue("@state", agvParamsLatest.state);
                cmd.Parameters.AddWithValue("@speed", agvParamsLatest.speed);
                cmd.Parameters.AddWithValue("@v_batt", agvParamsLatest.vBart);
                cmd.Parameters.AddWithValue("@batt_capacity", agvParamsLatest.battCapacity);
                cmd.Parameters.AddWithValue("@position", agvParamsLatest.position);


                cmd.ExecuteNonQuery();

                //close Connection
                this.CloseConnection();
            }
            else
            {

            }
        }
    }
}