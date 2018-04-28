using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using static System.Console;

namespace odb
{
    class UserOfDB
    {
        public MySqlConnection connection;
        private string server = "localhost";
        private string database = "eshopinnodb";
        private string uid = "";
        private string password = "password";
        //Constructor



        //Initialize values
        protected void Initialize()
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";"
                                    + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        //Open connection to database
        protected bool OpenConnection()
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
                        Console.WriteLine("Cannot connect to server.  Message: " + ex.Message+ "Inner Exception" + ex.InnerException);
                        throw;
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
        protected bool CloseConnection()
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

        protected interface ISelect
        {
            void Select(string query);
        }
        protected interface IInsert
        {
            void Insert(string query);
        }
        protected interface ICount
        {
            int Count(string query);
        }
        protected interface IDrop
        {
            void Drop(string query);
        }
        protected interface IUpdate
        {
            void Update(string query);
        }

        protected interface ICustomerPrivs : ISelect, ICount, IUpdate, IInsert
        {

        }
        protected interface IShopManager : ISelect, IDrop, IUpdate, IInsert, ICount
        {

        }

        public class Customer : UserOfDB, ICustomerPrivs
        {
            /// <summary>
            /// str[0] userID
            /// str[1] password
            /// str[2] schema
            /// str[3] server
            /// </summary>
            /// <param name="str"></param>

            public Customer(params string[] str)
            {
                if (str.Length == 1)
                {
                    uid = str[0];

                }
                if (str.Length == 2)
                {
                    uid = str[0];
                    password = str[1];

                }
                if (str.Length == 4)
                {
                    uid = str[0];
                    password = str[1];
                    database = str[2];
                    server = str[3];
                }
                Initialize();
            }
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

            public void Select(string query)
            {

            }

            public void Update(string query)
            {

            }
            public int[] SelectMaxCustmIDItmID()
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

            public void InsertOrders()
            {
                int[] list = this.SelectMaxCustmIDItmID();
                int j, k;
                Random rng = new Random();
                WriteLine(this.uid + " is inserting orders");
                int cstm_id, itm_id;
                if (list[0] != -1 && list[1] != -1)
                {

                    while (true)
                    {
                        cstm_id = rng.Next(1, list[0] + 1);
                        itm_id = rng.Next(1, list[1] + 1);
                        j = this.Count(String.Format(@"select count(*) from customers where customer_id = {0}", cstm_id));
                        k = this.Count(String.Format(@"select count(*) from stock where item_id = {0}", itm_id));
                        if (j != 0 && k != 0)
                        {

                            this.Insert(String.Format(@"
                                       insert into orders (customer_id, item_id) values ({0},{1})
                                       ", cstm_id, itm_id));
                            Write(".");
                            break;
                        }
                        else
                        {
                            WriteLine("\nnie istnieje taki rekord \"" + this.uid + "\" \n");
                            continue;
                        }
                    }

                }
                else
                {
                    WriteLine("Can't insert orders max customer_id {0}, stock_id {1}", list[0], list[1]);
                }
            }

        }
        public class ShopManager : UserOfDB, IShopManager
        {
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

            public void Select(string query)
            {

            }

            public void Update(string query)
            {

            }

            public void Drop(string query)
            {
                throw new NotImplementedException();
            }
        }
        public class ShopBot : UserOfDB, IShopManager
        {
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

            public void Select(string query)
            {

            }

            public void Update(string query)
            {

            }

            public void Drop(string query)
            {
                throw new NotImplementedException();
            }
        }
        public class Admin : UserOfDB
        {
            public Admin()
            {
                uid = "root";//login usera
                password = "admin1";// hasło usera
                database = "eshopinnodb"; // nazwa bazy danych
                server = "localhost";
                string connectionString = "SERVER=" + server + ";" +
                                                   "DATABASE=" + database + ";" +
                                                   "UID=" + uid + ";" +
                                                   "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
            }
            /// <summary>
            /// str[0] userID
            /// str[1] password
            /// str[2] schema
            /// str[3] server
            /// </summary>
            /// <param name="str"></param>
            public Admin(params string[] str)
            {
                if (str.Length == 1)
                {
                    uid = str[0];
                    password = "password";

                }
                if (str.Length == 2)
                {
                    uid = str[0];
                    password = str[1];

                }
                if (str.Length == 4)
                {
                    uid = str[0];
                    password = str[1];
                    database = str[2];
                    server = str[3];
                }
                Initialize();
            }

            public void Query(string qry)
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(qry, this.connection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    
                        CloseConnection();
                }
            }
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

                    this.InsertShop("Data/miasta.txt");
                    CreateNewStock(n[0]);
                    this.InsertStock("Data/stock.txt", "Data/miasta.txt");

                    this.InsertCustomers(n[1], "Data/imiona.txt", "Data/nazwiska.txt", "Data/miasta_all.txt");


                    this.InsertOrders(n[2]);
                    this.InsertOrderStatus(n[3]);
                }
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
            public void DropUsers()
            {
                int k = 0;
                if (this.OpenConnection() == true)
                {

                    MySqlCommand cmd = new MySqlCommand("select count(user) from mysql.user where user like 'user%';", this.connection);
                    int.TryParse(cmd.ExecuteScalar() + "", out k);
                    this.CloseConnection();
                }
                for (int i = 0; i < k; i++)
                {
                    this.Insert(string.Format("drop user if exists 'user{0}'@'localhost';", i));
                }
                //for (int i = 0; i < user.Length; i++)
                //{
                //    this.Insert(string.Format("create user if not exists 'user{0}'@'localhost' IDENTIFIED BY 'password';", i));
                //    this.Insert(string.Format("GRANT SELECT, INSERT ON eshopinnodb.orders TO 'user{0}'@'localhost';", i));
                //    this.Insert(string.Format("GRANT SELECT, INSERT, DELETE ON eshopinnodb.customers TO 'user{0}'@'localhost';", i));
                //    this.Insert(string.Format("GRANT SELECT ON eshopinnodb.stock TO 'user{0}'@'localhost';", i));
                //}

                //for (int i = 0; i < n; i++)
                //{
                //    while (true)
                //    {
                //        if (!this.CheckIfUserExists("user" + i))
                //        {
                //            this.CreateUser("user" + i);
                //            break;
                //        }
                //        else
                //        {
                //            continue;
                //        }
                //    }

                //}
                WriteLine("done");
            }
            public void DropAdmins()
            {
                int k = 0;
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand("select count(user) from mysql.user where user like 'admin%';", this.connection);
                    int.TryParse(cmd.ExecuteScalar() + "", out k);
                    this.CloseConnection();
                }
                for (int i = 0; i < k; i++)
                {
                    this.Insert(string.Format("drop user if exists 'admin{0}'@'localhost';", i));
                }

                //for (int i = 0; i < n; i++)
                //{
                //    while (true)
                //    {
                //        if (!this.CheckIfUserExists("user" + i))
                //        {
                //            this.CreateUser("user" + i);
                //            break;
                //        }
                //        else
                //        {
                //            continue;
                //        }
                //    }
                //}
                WriteLine("done");
            }

            /// <summary>
            /// <para>Creates user of db from initialized MyConnect instance</para>
            /// </summary>
            //public Customer CreateCustomer(string uid)
            //{
            //    Customer user = new Customer() {
            //        uid = uid
            //    };
            //    user.Initialize();
            //    if (this.OpenConnection() == true)
            //    {
            //        //MySqlCommand cmd = new MySqlCommand("select ;", this.connection);
            //        //MySqlDataReader dataReader = cmd.ExecuteReader();
            //        //int.TryParse(cmd.ExecuteScalar() + "", out i);

            //        MySqlCommand cmd0 = new MySqlCommand(string.Format(@"create user if not exists '{0}'@'{3}' IDENTIFIED BY '{1}'; 
            //                                                            ", user.uid, user.password, user.database, user.server), this.connection);
            //        MySqlCommand cmd1 = new MySqlCommand(string.Format(@"grant select, insert on {2}.orders to '{0}'@'{3}';
            //                                                            ", user.uid, user.password, user.database, user.server), this.connection);
            //        MySqlCommand cmd2 = new MySqlCommand(string.Format(@"grant select, insert, delete on {2}.customers to '{0}'@'{3}';
            //                                                            ", user.uid, user.password, user.database, user.server), this.connection);
            //        MySqlCommand cmd3 = new MySqlCommand(string.Format(@"grant select on {2}.stock to '{0}'@'{3}';
            //                                                            ", user.uid, user.password, user.database, user.server), this.connection);

            //        try
            //        {
            //            cmd0.ExecuteNonQuery();
            //            cmd1.ExecuteNonQuery();
            //            cmd2.ExecuteNonQuery();
            //            cmd3.ExecuteNonQuery();

            //        }
            //        catch (MySqlException)
            //        {

            //            throw;
            //        }
            //    }
            //    return user;
            //}
            public Customer CreateCustomer(string uid)
            {
                Customer user = new Customer()
                {
                    uid = uid
                };
                user.Initialize();
                if (this.OpenConnection() == true)
                {
                    //MySqlCommand cmd = new MySqlCommand("select ;", this.connection);
                    //MySqlDataReader dataReader = cmd.ExecuteReader();
                    //int.TryParse(cmd.ExecuteScalar() + "", out i);

                    MySqlCommand cmd0 = new MySqlCommand(string.Format(@"create user if not exists '{0}'@'{3}' IDENTIFIED BY '{1}'; 
                                                                        ", user.uid, user.password, user.database, user.server), this.connection);
                    MySqlCommand cmd1 = new MySqlCommand(string.Format(@"grant select, insert on {2}.orders to '{0}'@'{3}';
                                                                        ", user.uid, user.password, user.database, user.server), this.connection);
                    MySqlCommand cmd2 = new MySqlCommand(string.Format(@"grant select, insert, delete on {2}.customers to '{0}'@'{3}';
                                                                        ", user.uid, user.password, user.database, user.server), this.connection);
                    MySqlCommand cmd3 = new MySqlCommand(string.Format(@"grant select on {2}.stock to '{0}'@'{3}';
                                                                        ", user.uid, user.password, user.database, user.server), this.connection);

                    try
                    {
                        cmd0.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();

                    }
                    catch (MySqlException)
                    {

                        throw;
                    }
                }
                CloseConnection();
                return user;
            }
            //public void CreateUser(string uid)
            //{
            //    if (this.OpenConnection() == true)
            //    {
            //        //MySqlCommand cmd = new MySqlCommand("select ;", this.connection);
            //        //MySqlDataReader dataReader = cmd.ExecuteReader();
            //        //int.TryParse(cmd.ExecuteScalar() + "", out i);
            //        MySqlCommand cmd0 = new MySqlCommand(string.Format(@"create user if not exists '{0}'@'{3}' IDENTIFIED BY '{1}'; 
            //                                                        ", uid, "password", "eshopinnodb", "localhost"), this.connection);
            //        MySqlCommand cmd1 = new MySqlCommand(string.Format(@"grant select, insert on {2}.orders to '{0}'@'{3}';
            //                                                        ", uid, "password", "eshopinnodb", "localhost"), this.connection);
            //        MySqlCommand cmd2 = new MySqlCommand(string.Format(@"grant select, insert, delete on {2}.customers to '{0}'@'{3}';
            //                                                        ", uid, "password", "eshopinnodb", "localhost"), this.connection);
            //        MySqlCommand cmd3 = new MySqlCommand(string.Format(@"grant select on {2}.stock to '{0}'@'{3}';
            //                                                        ", uid, "password", "eshopinnodb", "localhost"), this.connection);

            //        try
            //        {
            //            cmd0.ExecuteNonQuery();
            //            cmd1.ExecuteNonQuery();
            //            cmd2.ExecuteNonQuery();
            //            cmd3.ExecuteNonQuery();

            //        }
            //        catch (MySqlException)
            //        {

            //            throw;
            //        }
            //        finally
            //        {
            //            this.CloseConnection();
            //        }
            //    }
            //}
            //public void CreateUser(string uid, string password, string database, string server)
            //{
            //    if (this.OpenConnection() == true)
            //    {
            //        MySqlCommand cmd = new MySqlCommand("select ;", this.connection);
            //        MySqlDataReader dataReader = cmd.ExecuteReader();
            //        //int.TryParse(cmd.ExecuteScalar() + "", out i);
            //        cmd = new MySqlCommand(string.Format(@"create user if not exists '{0}'@'{3}' IDENTIFIED BY '{1}'; 
            //                                grant select, insert on {2}.orders to '{0}'@'{3}';
            //                                grant select, insert, delete on {2}.customers to '{0}'@'{3}';
            //                                ", uid, password, database, server), this.connection);
            //        try
            //        {
            //            cmd.ExecuteNonQuery();

            //        }
            //        catch (MySqlException)
            //        {

            //            throw;
            //        }
            //        finally
            //        {
            //            this.CloseConnection();
            //        }
            //    }
            //}
            public Admin CreateAdmin(string uid)
            {
                Admin admin = new Admin(uid);
                if (this.OpenConnection() == true)
                {
                    //MySqlCommand cmd = new MySqlCommand("select ;", this.connection);
                    //MySqlDataReader dataReader = cmd.ExecuteReader();
                    //int.TryParse(cmd.ExecuteScalar() + "", out i);
                    MySqlCommand cmd0 = new MySqlCommand(string.Format(@"create user if not exists '{0}'@'{3}' IDENTIFIED BY '{1}'; 
                                                                    ", admin.uid, "password", "eshopinnodb", "localhost"), this.connection);

                    MySqlCommand cmd1 = new MySqlCommand(string.Format(@"grant all on {2}.* to '{0}'@'{3}';
                                                                    ", admin.uid, "password", "eshopinnodb", "localhost"), this.connection);

                    try
                    {
                        cmd0.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();

                    }
                    catch (MySqlException)
                    {
                        WriteLine("CreateAdmin exception");
                        throw;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                }
                return admin;
            }

            ////Insert statement
            //public void Insert(string query)
            //{
            //    //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //    //open connection
            //    if (this.OpenConnection() == true)
            //    {
            //        //create command and assign the query and connection from the constructor
            //        MySqlCommand cmd = new MySqlCommand(query, connection);

            //        try
            //        {

            //            //Execute command
            //            cmd.ExecuteNonQuery();
            //        }
            //        catch (Exception)
            //        {
            //            this.CloseConnection();
            //            throw;
            //        }


            //        //close connection
            //        this.CloseConnection();
            //    }
            //}

            //COUNT!
            //public int Count(string query)
            //{

            //    int Count = -1;

            //    //Open Connection
            //    if (this.OpenConnection() == true)
            //    {
            //        //Create Mysql Command
            //        MySqlCommand cmd = new MySqlCommand(query, connection);

            //        //ExecuteScalar will return one value
            //        Count = int.Parse(cmd.ExecuteScalar() + "");

            //        //close Connection
            //        this.CloseConnection();

            //        return Count;
            //    }
            //    else
            //    {
            //        return Count;
            //    }
            //}



            //function adding stock to db's
            //public static void InsertStock(User a, OracleConnect b, string stockPath, string miastaPath)
            //{
            //    WriteLine("Inserting stock");

            //    string[] stock = File.ReadAllLines(stockPath);
            //    string[] miasta = File.ReadAllLines(miastaPath);
            //    for (int j = 0; j < miasta.Length; j++)
            //    {

            //        foreach (var item in stock)
            //        {

            //            string[] i = item.Split(',');


            //            try
            //            {

            //                a.Insert(String.Format(@"
            //                                    Insert into stock (item_name, category, price, quantity, shop_id)
            //                                    values ('{0}', '{1}', '{2}', '{3}', '{4}') 
            //                                    ", i[0], i[1], i[2], i[3], j + 1));

            //                b.Insert(String.Format(@"
            //                                    Insert into stock (item_name, category, price, quantity, shop_id, item_id) 
            //                                    values ('{0}', '{1}', {2}, {3}, {4}, {5})
            //                                    ", i[0], i[1], i[2], i[3], j + 1, "stock_id.nextval"));

            //            }
            //            catch (MySqlException e)
            //            {
            //                WriteLine("mysql error : ", e.Message);
            //                throw;
            //            }
            //            catch (OracleException e)
            //            {
            //                WriteLine("oracle error : ", e.Message);
            //                throw;
            //            }
            //        }
            //    }
            //}
            //public static void InsertShop(User a, OracleConnect b, string miastoPath)
            //{
            //    WriteLine("inserting shops");
            //    string[] miasto = File.ReadAllLines(miastoPath);
            //    foreach (var item in miasto)
            //    {

            //        try
            //        {
            //            a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", item));
            //            b.Insert(String.Format(@"INSERT INTO SHOPS (CITY, SHOP_ID) values ('{0}', {1})", item, "shop_id.nextval"));

            //        }
            //        catch (MySqlException e)
            //        {
            //            WriteLine("mysql error : ", e.Message);
            //            a.CloseConnection();
            //        }
            //        catch (OracleException e)
            //        {
            //            WriteLine("oracle error : ", e.Message);
            //            b.CloseConnection();
            //        }
            //        catch (Exception)
            //        {
            //            throw;
            //        }
            //    }
            //}
            public void InsertShop(string miastoPath)
            {
                WriteLine("inserting shops");
                string[] miasto = File.ReadAllLines(miastoPath);
                foreach (var item in miasto)
                {

                    try
                    {
                        this.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", item));
                        //b.Insert(String.Format(@"INSERT INTO SHOPS (CITY, SHOP_ID) values ('{0}', {1})", item, "shop_id.nextval"));

                    }
                    catch (MySqlException e)
                    {
                        WriteLine("mysql error : ", e.Message);
                        this.CloseConnection();
                    }
                    //catch (OracleException e)
                    //{
                    //    WriteLine("oracle error : ", e.Message);
                    //    b.CloseConnection();
                    //}
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            //public static void InsertCustomers(int n, User a, OracleConnect b, string imionaPath, string nazwiskaPath, string miastaPath)
            //{
            //    string[] imiona = File.ReadAllLines(imionaPath);
            //    string[] nazwiska = File.ReadAllLines(nazwiskaPath);
            //    string[] miasta = File.ReadAllLines(miastaPath);

            //    Random rng = new Random();

            //    string name, lastName, city;
            //    int phone;


            //    Stopwatch timer = new Stopwatch();
            //    Increment inc = new Increment();
            //    timer.Start();
            //    WriteLine("Running (...)\n");
            //    for (int i = 0; i < n; i++)
            //    {
            //        name = imiona[rng.Next(0, imiona.Length)];
            //        Thread.Sleep(1);
            //        lastName = nazwiska[rng.Next(0, nazwiska.Length)];
            //        Thread.Sleep(1);
            //        city = miasta[rng.Next(0, miasta.Length)];
            //        Thread.Sleep(1);
            //        phone = rng.Next(100000000, 1000000000);


            //        while (true)
            //        {
            //            try
            //            {
            //                b.Insert(String.Format(@"
            //                                            insert into customers 
            //                                            (first_name, last_name, city, email, phone, customer_id) 
            //                                            values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}', customer_id.nextval)
            //                                            ", name, lastName, city, inc.I, phone));
            //                a.Insert(String.Format(@"
            //                                    insert into customers 
            //                                    (first_name, last_name, city, email, phone) 
            //                                    values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}')
            //                                    ", name, lastName, city, inc.I, phone));


            //                Write(".");
            //                //inc.Reset();
            //                break;
            //            }
            //            catch (MySqlException e) when (e.Number == 1062)
            //            {
            //                WriteLine("\nBŁĄD !! ||  " + e.Number + " ||  " + e.Message + "     \n");
            //                continue;

            //            }
            //            catch (OracleException e) when (e.ErrorCode == -2147467259 && e.Number == 1)
            //            {

            //                WriteLine("\nBŁĄD !! ||  " + e.ErrorCode + " ||  " + e.Message + "  || number " + e.Number + "    \n");
            //                b.CloseConnection();
            //                continue;
            //            }
            //            catch (OracleException e) when (e.Number == 1654)
            //            {
            //                throw;
            //            }
            //        }

            //    }

            //    timer.Stop();
            //    Console.WriteLine("czas wykonywania: {0}", timer.Elapsed);
            //}
            public void InsertCustomer(string name, string lastName, string city)
            {
                Random rng = new Random();
                int phone = rng.Next(100000000, 1000000000);
                try
                {
                    //b.Insert(String.Format(@"
                    //                            insert into customers 
                    //                            (first_name, last_name, city, email, phone, customer_id) 
                    //                            values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}', customer_id.nextval)
                    //                            ", name, lastName, city, inc.I, phone));
                    this.Query(String.Format(@"
                                            insert into customers 
                                            (first_name, last_name, city, email, phone) 
                                            values ('{0}', '{1}', '{2}', '{0}.{1}@gmail{3}.com', '{4}')
                                            ", name, lastName, city, "", phone));
                    Write(".");
                }
                catch (MySqlException e) when (e.Number == 1062)
                {
                    WriteLine("\nBŁĄD !! ||  " + e.Number + " ||  " + e.Message + "     \n");

                }
                catch (Exception e)
                {
                    WriteLine("\nBŁĄD !! ||  " + e.Message + "     \n");
                    throw;
                }
                
                    this.CloseConnection();

            }
            public void InsertCustomers(int n, string imionaPath, string nazwiskaPath, string miastaPath)
            {
                string[] imiona = File.ReadAllLines(imionaPath);
                string[] nazwiska = File.ReadAllLines(nazwiskaPath);
                string[] miasta = File.ReadAllLines(miastaPath);

                string name, lastName, city;
                int phone;

                Random rng = new Random();
                Stopwatch timer = new Stopwatch();
                //Increment inc = new Increment();
                timer.Start();
                WriteLine("Running (...)\n");
                for (int i = 0; i < n; i++)
                {
                    name = imiona[rng.Next(0, imiona.Length)];
                    Thread.Sleep(1);
                    lastName = nazwiska[rng.Next(0, nazwiska.Length)];
                    Thread.Sleep(1);
                    city = miasta[rng.Next(0, miasta.Length)];
                    Thread.Sleep(1);
                    phone = rng.Next(100000000, 1000000000);

                    int k = 0;
                    while (true)
                    {
                        try
                        {
                            //b.Insert(String.Format(@"
                            //                            insert into customers 
                            //                            (first_name, last_name, city, email, phone, customer_id) 
                            //                            values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}', customer_id.nextval)
                            //                            ", name, lastName, city, inc.I, phone));
                            this.Insert(String.Format(@"
                                            insert into customers 
                                            (first_name, last_name, city, email, phone) 
                                            values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}')
                                            ", name, lastName, city, k, phone));


                            Write(".");
                            k = 0;
                            break;
                        }
                        catch (MySqlException e) when (e.Number == 1062)
                        {
                            WriteLine("\nBŁĄD !! ||  " + e.Number + " ||  " + e.Message + "     \n");
                            MySqlCommand cmd = new MySqlCommand(String.Format(@"
                                                                            select count(*) from customers where 
                                                                            (customers.first_name = '{0}' && customers.last_name = '{1}');
                                                                            ", name, lastName), this.connection);
                            this.OpenConnection();
                            int.TryParse(cmd.ExecuteScalar() + "", out k);
                            this.CloseConnection();
                            continue;

                        }
                        //catch (OracleException e) when (e.ErrorCode == -2147467259 && e.Number == 1)
                        //{

                        //    WriteLine("\nBŁĄD !! ||  " + e.ErrorCode + " ||  " + e.Message + "  || number " + e.Number + "    \n");
                        //    b.CloseConnection();
                        //    continue;
                        //}
                        //catch (OracleException e) when (e.Number == 1654)
                        //{
                        //    throw;
                        //}
                    }

                }

                timer.Stop();
                Console.WriteLine("czas wykonywania: {0}", timer.Elapsed);
            }
            public void InsertOrderStatus(int n)
            {
                string[] status = new string[]
                {
                "Order Created",
                "Order Confirmed",
                "Order Send!",
                "Order Received",
                "Order Closed",
                };
                int MaxOrderId = this.SelectMaxOrderID();
                WriteLine("Maxorder id {0}", MaxOrderId);
                //ReadKey();
                int ordr_id;
                Random rng = new Random();
                DateTime start = new DateTime(2016, 1, 1);
                int range = (DateTime.Today - start).Days;
                for (int i = 0; i < n; i++)
                {

                    while (true)
                    {
                        ordr_id = rng.Next(1, MaxOrderId + 1);
                        int j = this.Count(String.Format("select count(*) from orders where order_id = '{0}';", ordr_id));
                        if (j != 0)
                        {
                            Console.WriteLine("Trying insert orded status");
                            try
                            {
                                this.Insert(String.Format(@"
                                             insert into order_status (status, status_changed, order_id)
                                             values ('{0}', '{1}', '{2}');
                                             ", status[0], RandomDay(rng, range, start), ordr_id));
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("BŁĄD : {0}", e.Message);
                                throw;
                            }
                        }
                        else
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                    }
                }
            }


            public static void CreateNewStock(int n)
            {
                Stopwatch t = new Stopwatch();
                t.Start();

                string[] lines = new string[n];
                decimal d;
                Random rng = new Random();
                for (int i = 0; i < lines.Length; i++)
                {


                    d = rng.Next(1, 10000);
                    lines[i] = String.Format("item{0},category{1},{2},{3}", i + 1, rng.Next(0, 100), d / 100, rng.Next(1, 1000));

                }
                //System.IO.File.WriteAllLines(@"D:\Source\Repos\.Net-Projects\.Net-Projects\odb\lib\Data\stock.txt", lines);
                System.IO.File.WriteAllLines(@"D:\dokumenty\Source\Repos\.Net-Projects\odb\bin\Debug\Data\stock.txt", lines);
                t.Stop();
                Console.WriteLine("upłyneło {0}", t.Elapsed);

            }
            public void InsertStock(string stockPath, string miastaPath)
            {
                WriteLine("Inserting orders");

                string[] stock = File.ReadAllLines(stockPath);
                string[] miasta = File.ReadAllLines(miastaPath);
                for (int j = 0; j < miasta.Length; j++)
                {

                    foreach (var item in stock)
                    {

                        string[] i = item.Split(',');


                        try
                        {

                            this.Insert(String.Format(@"
                                            Insert into stock (item_name, category, price, quantity, shop_id)
                                            values ('{0}', '{1}', '{2}', '{3}', '{4}') 
                                            ", i[0], i[1], i[2], i[3], j + 1));

                            //b.Insert(String.Format(@"
                            //                    Insert into stock (item_name, category, price, quantity, shop_id, item_id) 
                            //                    values ('{0}', '{1}', {2}, {3}, {4}, {5})
                            //                    ", i[0], i[1], i[2], i[3], j + 1, "stock_id.nextval"));

                        }
                        catch (MySqlException e)
                        {
                            WriteLine("mysql error : ", e.Message);
                            throw;
                        }
                        //catch (OracleException e)
                        //{
                        //    WriteLine("oracle error : ", e.Message);
                        //    throw;
                        //}
                    }
                }
            }
            public void InsertOrders(int n)
            {
                int[] list = this.SelectMaxCustmIDItmID();
                int j, k;
                Random rng = new Random();
                WriteLine("inserting orders");
                int cstm_id, itm_id;
                if (list[0] != -1 && list[1] != -1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        while (true)
                        {
                            cstm_id = rng.Next(1, list[0] + 1);
                            itm_id = rng.Next(1, list[1] + 1);
                            j = this.Count(String.Format(@"select count(*) from customers where customer_id = {0}", cstm_id));
                            k = this.Count(String.Format(@"select count(*) from stock where item_id = {0}", itm_id));
                            if (j != 0 && k != 0)
                            {

                                this.Insert(String.Format(@"
                                       insert into orders (customer_id, item_id) values ({0},{1})
                                       ", cstm_id, itm_id));
                                Write(".");
                                break;
                            }
                            else
                            {
                                WriteLine("\nnie istnieje taki rekord\n");
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    WriteLine("Can't insert orders max customer_id {0}, stock_id {1}", list[0], list[1]);
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
            public int SelectMaxOrderID()
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

            // check email of customers
            public string SelectEmailOfCustomer()
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

                return mail;
            }
            public string SelectEmailOfCustomer(out bool f)
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
                f = (mail != null);
                return mail;
            }
            public string SelectEmailOfCustomer(int id, bool cond)
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

            public int[] SelectMaxCustmIDItmID()
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
            public bool CheckIfUserExists(string userName)
            {
                int j = this.Count(string.Format(@"select count(*) from mysql.user where user = '{0}';", userName));
                if (j == 1)
                {
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    this.CloseConnection();
                    return false;
                }
            }
            public void CustomerSim()
            {
                UserOfDB.Customer user = this.CreateCustomer("user" + Thread.CurrentThread.Name);
                for (int i = 0; i < 100; i++)
                {
                    user.InsertOrders();
                }

            }
            public void AdminSim()
            {
                while (true)
                {
                    Random rng = new Random();
                    switch (rng.Next(0, 2))
                    {
                        case 0:
                            WriteLine("Inserting customer from user: "+Thread.CurrentThread.Name);
                            InsertCustomer("Krzysztof", "Karoń", "Kraków");
                            break;

                        case 1:
                            WriteLine("deleting customer from user: " + Thread.CurrentThread.Name);
                            DropCustomer("Krzysztof.Karoń@gmail.com");
                            break;

                            //case 3:
                            //    admin.UpdateCustomer();
                            //    break;

                            //case 4:
                            //    break;

                    }
                }




            }

            private void UpdateCustomer()
            {

            }

            private void DropCustomer(string email)
            {
                this.Query(String.Format(@"delete from customers where customers.email = '{0}';", email));
            }
        }

        public static string RandomDay(Random rng, int range, DateTime start)
        {
            return start.AddDays(rng.Next(range)).ToString("yyyy -MM-dd H:mm:ss"); ;
        }
        public void UserInsertIntoCustomers()
        {
        }
        public void UserSelect() { }
        public void UserDelete() { }
    }
}

