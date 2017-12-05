using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;


namespace Lab8
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        //private void Initialize()
        public void Initialize()
        {
            server = "localhost";
            database = "lab8";
            uid = "root";
            password = "admin1";
            string connectionString;
            connectionString = "SERVER=" + server + ";" +
                               "DATABASE=" + database + ";" +
                               "UID=" + uid + ";" +
                               "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //Open connection to database
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
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        Console.WriteLine("Invalid username/password, please try again");
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

        public bool Close()
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



        //Insert statement
        public void InsertEarthquake(int Rok, string Miejsce, string Kraj,  string Siła)
        {
            string query = "INSERT INTO earthquake (Rok, Miejsce, Kraj, Siła) VALUES('"
                + Rok + "', '"+Miejsce + "', '" 
                + Kraj  + "', '" 
                + Siła + "');";
            //INSERT INTO table_name (columns) VALUES('  ',' ',' ')
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }


        //Any MySQL statement
        public void Any(string query)
        {
            //query = any MySql query

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }


        //Update statement
        public void Update(int id, int magnitude)
        {
            string query = "UPDATE earthquake SET Siła='"+magnitude+"'" +
                " WHERE ID='"+id+"';";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }


        //Delete IDstatement
        public void DeleteID(int id)
        {
            // string query = "DELETE FROM tableinfo WHERE name='John Smith'";
            string query = "DELETE FROM earthquake where ID="+id+";";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string query)
        {
            // string query = "DELETE FROM tableinfo WHERE name='John Smith'";
            

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] SelectAll()
        {

            string query = "SELECT * FROM earthquake;";

            //Create a list to store the result
            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            
            //list[2] = new List<string>();

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
                    list[0].Add(dataReader["ID"] + "");                    
                    list[1].Add(dataReader["Rok"] + "");
                    list[2].Add(dataReader["Miejsce"] + "");
                    list[3].Add(dataReader["Kraj"] + "");
                    list[4].Add(dataReader["Siła"] + "");
                    
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                
                
                return list;
            }
            else
            {
                return list;
            }

        }

        //Select where ID >= variable 
        public List<string>[] SelectWhereMagnitude(decimal Magnitude)
        {

            string query = "SELECT * FROM earthquake WHERE Siła>"+Magnitude+";";

            //Create a list to store the result
            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();

            //list[2] = new List<string>();

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
                    list[0].Add(dataReader["ID"] + "");
                    list[1].Add(dataReader["Rok"] + "");
                    list[2].Add(dataReader["Miejsce"] + "");
                    list[3].Add(dataReader["Kraj"] + "");
                    list[4].Add(dataReader["Siła"] + "");

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed


                return list;
            }
            else
            {
                return list;
            }

        }


        //Console Write select list
        public static void PrintList(List<string>[] list, int Rows)
        {
            Console.WriteLine("ID       Rok     Miejsce            Kraj        Siła");
            //            for(int i =0; i < list[0].Count; i++)
            for (int i = 0; i < Rows; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t{4}", list[0][i],list[1][i],list[2][i],list[3][i],list[4][i]);
            }
            
            
        }

        public static void PrintList(List<string>[] list)
        {
            Console.WriteLine("ID       Rok     Miejsce            Kraj        Siła");
            for(int i =0; i < list[0].Count; i++)
            
            {
                Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t{4}", list[0][i], list[1][i], list[2][i], list[3][i], list[4][i]);
            }


        }

        ///Count statement
        public int Count(string query)
        {
            //string query = "SELECT Count(*) FROM tableinfo";
            //int Count = -1;
            int Count = 0;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Populate DB with Data
        public void PopulateDB()
        {
            string[] plik = File.ReadAllLines("all_month.csv");
            //char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            for (int i = 1; i < plik.Length; i++)
            {
                string[] b = plik[i].Split(',');
                string[] c = b[0].Split('-');
                int d0 = Convert.ToInt32(c[0]);
                string[] d1 = b[13].Split('"');
                string[] d2 = b[14].Split('"');

                try
                {
                    if (d1[1] != null && d2[0] != null) this.InsertEarthquake(d0, d1[1], d2[0], b[4]);
                }
                catch (Exception e)
                {
                    this.CloseConnection();
                    Console.WriteLine("Błąd     {0}\n{1}\n{2}\n{3}", e.Message, e.StackTrace, e.Source, e.InnerException);

                }


                //ID = b[11],
                //Rok = Convert.ToInt32(c[0]),
                //Siła = Convert.ToInt32(b[4]),
                //Kraj = "USA",
                //Miejsce = b[13],


            }
            Console.WriteLine("Gotowe!");
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}
