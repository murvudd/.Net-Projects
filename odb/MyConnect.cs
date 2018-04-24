using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;
using static odb.StaticMethods;

namespace odb
{
    class MyConnect
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;


        //Constructor
        public MyConnect()
        {
            Initialize();
        }
        public MyConnect(string user)
        {

            Initialize(user, "password");
            CreateUser();
        }
        public MyConnect(string user, string pass, string _server, string db)
        {
            Initialize(user, pass, _server, db);
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
        protected void Initialize(string user, string pass)
        {
            server = "localhost";
            database = "eshopinnodb"; // nazwa bazy danych
            uid = user;//login usera
            password = pass;// hasło usera
            string connectionString;
            connectionString = "SERVER=" + server + ";" +
                               "DATABASE=" + database + ";" +
                               "UID=" + uid + ";" +
                               "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        protected void Initialize(string user, string pass, string _server, string db)
        {
            server = _server;
            database = db; // nazwa bazy danych
            uid = user;//login usera
            password = pass;// hasło usera
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

        //Insert statement
        public void Insert(string query)
        {
            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    this.CloseConnection();
                    throw;
                }


                //close connection
                this.CloseConnection();
            }
        }
        public int CheckMaxOrderID()
        {
            int i = -1;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand("select max(order_id) from orders", this.connection);
                try
                {
                    int.TryParse(cmd.ExecuteScalar() + "", out i);
                    this.CloseConnection();
                }
                catch (Exception e)
                {
                    Console.WriteLine("no MaxOrderID  {0}", e.Message);
                    this.CloseConnection();
                    throw;
                }
                return i;
            }
            else
            {

                return i;
            }
        }

        public int SelectMaxCustomer_id()
        {
            int j = -1;
            MySqlCommand cmd;
            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand("select max(customer_id) from customers", this.connection);
                int.TryParse(cmd.ExecuteScalar() + "", out j);
                this.CloseConnection();
            }
            return j;
        }
        /// <summary>
        /// <para>
        /// returns true when theres customer with given id
        /// </para>
        /// </summary>
        /// <param name="j"></param>
        /// <param name="i"></param>
        public bool CheckIfCustomerExists(int id)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(string.Format("select count(*) from customers where customer_id = {0}", id), this.connection);
                int.TryParse(cmd.ExecuteScalar() + "", out int j);
                CloseConnection();
                if (j == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                CloseConnection();
                return false;
            }

        }
        public string CheckEmailOfCustomer(out bool f)
        {
            string mail = null;
            Random rng = new Random();
            int MaxId = this.SelectMaxCustomer_id() + 1;
            int id = rng.Next(1, MaxId);
            if (CheckIfCustomerExists(id))
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(string.Format("select email from customers where customer_id = {0}", id), this.connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        mail = reader["email"] + "";
                    }
                    reader.Close();
                    CloseConnection();
                }
            }
            f = (mail == null);
            return mail;
        }
        public string CheckEmailOfCustomer(int id, bool cond)
        {
            string mail = null;
            if (cond)
            {

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(string.Format("select email from customers where customer_id = {0}", id), this.connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        mail = reader["email"] + "";
                    }
                    reader.Close();
                    CloseConnection();
                }
            }
            return mail;
        }
        //public void CheckIasffRandomUserExists(out int i, out int j, out string mail)
        //{
        //    i = -1;
        //    j = -1;
        //    mail = null;


        //    if (this.OpenConnection() == true && j != 0 && j != -1)
        //    {
        //        Console.WriteLine("drugi if  " + j);
        //        int k = rng.Next(1, j);
        //        //cmd = new MySqlCommand(string.Format("select count(customer_id) from customers where customer_id = {0};", k, this.connection));
        //        cmd = new MySqlCommand(string.Format("select count(customer_id) from customers where customer_id = {0};", 1984, this.connection));
        //        Console.WriteLine("dwa i pol if");


        //        int.TryParse(cmd.ExecuteScalar() + "", out i);
        //        this.CloseConnection();

        //    }
        //    if (this.OpenConnection() == true && j != 0 && j != -1 && i != 0)
        //    {
        //        Console.WriteLine("trzeci if");
        //        cmd = new MySqlCommand(string.Format("select email from customers where customer_id = {0}", 1984), this.connection);
        //        MySqlDataReader DataReader = cmd.ExecuteReader();
        //        while (DataReader.Read())
        //        {
        //            mail = DataReader["email"] + "";
        //        }
        //        this.CloseConnection();
        //    }
        //    else
        //    {
        //        this.CloseConnection();
        //    }





        //}
        public int[] CheckMaxCustmIDItmID()
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
                finally
                {
                    this.CloseConnection();
                }

                return list;
            }
            else
            {
                Console.WriteLine("Error, connection not open");
                return list;
            }
        }
        public int Count(string query)
        {

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

        public void TruncateDB()
        {
            Console.WriteLine("Truncating DB");
            //query AUTO_INCREMENT=10001 
            string sa = @"
            
                DROP database eshopinnodb;
Create database eshopInnoDB;
use eshopInnoDB;


CREATE TABLE `shops` (
  `city` char(20) UNIQUE,
  `shop_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`shop_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `orders` (
  `order_id` int(10) unsigned  AUTO_INCREMENT,
  `customer_id` int(10) unsigned ,
  `item_id` int(10) unsigned ,
  PRIMARY KEY (`order_id`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;


	
CREATE TABLE `stock` (
  `item_name` varchar(15) ,
  `category` varchar(15) ,
  `quantity` int(10) unsigned ,
  `price` decimal(6,2) ,
  `shop_id` int(10) unsigned ,
  `item_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`item_id`),
  KEY `shop_id` (`shop_id`)
  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `order_status` (
  `status` varchar(255) ,
  `status_changed` datetime ,
  `order_id` int(10) unsigned ,
  `status_id` int(10) unsigned AUTO_INCREMENT unique
  -- UNIQUE KEY `status_id` (`status_id`),
  -- KEY `order_id` (`order_id`)
  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `customers` (
  `first_name` char(20) ,
  `last_name` char(30) ,
  `city` char(50) ,
  `email` varchar(255) unique,
  `phone` varchar(20) ,
  `customer_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

            
            ";

            this.Insert(sa);
            this.ApplyConstraints();
        }

        public void ApplyConstraints()
        {
            Console.WriteLine("Applying constraints");
            string sa = @"
                         
alter table `order_status` 
add CONSTRAINT `order_status_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`);

alter table `stock`
	add CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`shop_id`) REFERENCES `shops` (`shop_id`);

ALTER TABLE `orders` 
	add CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`),
	add CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`item_id`) REFERENCES `stock` (`item_id`);
                         ";
            this.Insert(sa);
        }

        /// <summary>
        /// <para>a</para>
        /// </summary>
        /// <param name="n">
        /// <para>n[0] # of new stock</para>
        /// <para>n[1] # new customers</para>
        /// <para>n[2] # of new orders</para>
        /// <para>n[3] # of orderStatuses</para>
        /// </param>
        public void InitializeDB(int[] n)
        {
            if (n.Length == 4)
            {

                this.TruncateDB();
                //this.ApplyConstraints();

                InsertShop(this, "Data/miasta.txt");
                CreateNewStock(n[0]);
                InsertStock(this, "Data/stock.txt", "Data/miasta.txt");

                InsertCustomers(n[1], this, "Data/imiona.txt", "Data/nazwiska.txt", "Data/miasta_all.txt");


                InsertOrders(this, n[2]);
                InsertOrderStatus(this, n[3]);
            }
        }

        /// <summary>
        /// <para>Creates user of db from initialized MyConnect instance</para>
        /// </summary>
        public void CreateUser()
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand("select ;", this.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //int.TryParse(cmd.ExecuteScalar() + "", out i);
                cmd = new MySqlCommand(string.Format(@"create user if not exists '{0}'@'localhost' IDENTIFIED BY '{1}'; 
                                            grant select, insert on {2}.orders to '{0}'@'{3}';
                                            grant select, insert, delete on {2}.customers to '{0}'@'{3}';
                                            ", this.uid, this.password, this.database, this.server), this.connection);
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (MySqlException)
                {

                    throw;
                }
            }
        }

    }
}
