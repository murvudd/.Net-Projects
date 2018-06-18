using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace odb
{
    class LocalOracleConnect
    {
        private OracleConnection connection;
        private string server;
        private string port;
        private string service_name;
        private string uid;
        private string password;

        public LocalOracleConnect()
        {
            Initialize();
        }

        protected void Initialize()
        {
            server = "localhost";
            port = "1521";
            service_name = "migration";
            uid = "SYSTEM";
            password = "admin1";

            string cs = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)
            (HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)
            (SERVICE_NAME={2})));User Id={3};Password={4};";

            //nadpisanie CS
            cs = String.Format(cs, server, port, service_name, uid, password);
            connection = new OracleConnection(cs);
        }


        //Open Connection
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (OracleException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                //switch (ex.Number)
                //{
                //    case 0:
                //        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                //        Console.WriteLine("Cannot connect to server.  Contact administrator");
                //        break;

                //    case 1045:
                //        //MessageBox.Show("Invalid username/password, please try again");
                //        Console.WriteLine("Invalid username/password, please try again");
                //        break;
                //}
                //return false;

                Console.WriteLine("Connection open failed !          Exception Number {0}, Message {1}, inner exception {2}", ex.Number, ex.Message, ex.InnerException);
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
            catch (OracleException ex)
            {
                //MessageBox.Show(ex.Message);
                Console.WriteLine("Connection Close failed !          Exception Number {0}, Message {1}, inner exception {2}", ex.Number, ex.Message, ex.InnerException);

                return false;
                throw;
            }
        }

        public void Check()
        {
            //open connection
            if (this.OpenConnection() == true)
            {

                OracleGlobalization og = connection.GetSessionInfo();
                Console.WriteLine(og.DateFormat + " " + og.Territory + " " + og.Language);

                //close connection
                this.CloseConnection();
            }
        }
        public void CheckCustomer_ID()
        {

        }

        //Insert statement
        public void Insert(string query)
        {
            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                OracleCommand cmd = new OracleCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
    }
}
