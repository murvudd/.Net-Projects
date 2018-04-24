using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace odb
{
    class TestConnect
    {

        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;


        //Constructor
        public TestConnect()
        {
            Initialize();
        }

        //Initialize values
        //private void Initialize()
        protected void Initialize()
        {
            server = "localhost";
            database = "eshopinnodb"; // nazwa bazy danych
            uid = "root";//login usera
            password = "admin1";// hasło usera
            string connectionString;
            connectionString = "SERVER=" + server + ";" +
                               "DATABASE=" + database + ";" +
                               "UID=" + uid + ";" +
                               "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //Open connection to database
        public bool OpenConnection()
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
        public bool CloseConnection()
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


        ////Select statement
        public int[] SelectOrdersID()
        {
            //Create a list to store the result
            int[] list = new int[2] { -1, -1 };

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand("select max(customer_id) from customers;", connection);
                //Create a data reader and Execute the command

                try
                {
                    int.TryParse(cmd.ExecuteScalar() + "", out list[0]);

                }
                catch (Exception)
                {

                    throw;
                }
                cmd = new MySqlCommand("select max(item_id) from stock;", connection);
                try
                {
                    int.TryParse(cmd.ExecuteScalar() + "", out list[1]);
                }
                catch (Exception)
                {

                    throw;
                }

                return list;
            }
            else
            {
                Console.WriteLine("Error, connection not open");
                return list;
            }
        }



        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

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

        public static void TestMethod(MyConnect a, out string mail)
        {
            mail = null;
            //Console.Write("Początek test metody");
            if (a.OpenConnection() == true)
            {
                //Console.Write("while test metody");
                MySqlCommand cmd = new MySqlCommand(string.Format("select email from customers where customer_id = {0}", 1984), a.connection);
                MySqlDataReader DataReader = cmd.ExecuteReader();
                while (DataReader.Read())
                {
                    mail = DataReader["email"] + "";
                }
            }
            a.CloseConnection();
        }


        public string RandomDay(Random rng, int range, DateTime start)
        {
            start = new DateTime(2016, 1, 1);
            range = (DateTime.Today - start).Days;
            return start.AddDays(rng.Next(range)).ToString("yyyy-MM-dd H:mm:ss"); ;
        }

    }
}
