using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Diagnostics;
using static System.Console;
using MySql.Data.MySqlClient;

namespace odb
{
    class Program
    {
        static void Main(string[] args)
        {
            MyConnect a = new MyConnect();
            OracleConnect b = new OracleConnect();
            Random rng = new Random();

            b.Check();


            CreateNewStock(1500);

            InsertCustomers(100, a, b, "Data/imiona.txt", "Data/nazwiska.txt", "Data/miasta_all.txt");
            //InsertShop(a, b, "miasta.txt");
            InsertStock(a, b, "Data/stock.txt", "Data/miasta.txt");


        }


        public static void InsertStock(MyConnect a, OracleConnect b, string stockPath, string miastaPath)
        //function adding stock to db's
        {
            int k = 0;
            string[] stock = File.ReadAllLines(stockPath);
            string[] miasta = File.ReadAllLines(miastaPath);
            for (int j = 0; j < miasta.Length; j++)
            {

                foreach (var item in stock)
                {

                    string[] i = item.Split(',');
                    string s1 = @"Insert into stock (item_name, category, price, quantity, shop_id) values ('{0}', '{1}', '{2}', '{3}', '{4}') ";
                    string s2 = @"Insert into stock (item_name, category, price, quantity, shop_id, item_id) values ('{0}', '{1}', {2}, {3}, {4}, {5})";
                    //Console.WriteLine(" wartosc i0: {0}", i[0]);

                    //Console.WriteLine(" wartosc stringa s: {0}", String.Format(s2, i[0], i[1], i[2], i[3], j + 1, k));
                    a.Insert(String.Format(s1, i[0], i[1], i[2], i[3], j + 1));
                    k += 1;
                    b.Insert(String.Format(s2, i[0], i[1], i[2], i[3], j + 1, k));

                }
            }
        }


        public static void InsertShop(MyConnect a, OracleConnect b, string miastoPath)
        {
            int k = 0;
            string[] miasto = File.ReadAllLines(miastoPath);
            foreach (var item in miasto)
            {
                k += 1;
                try
                {
                    a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", item));
                    //b.Insert(String.Format(@"INSERT INTO SHOPS (CITY, SHOP_ID) values ('{0}', '{1}')", item, k));

                }
                catch (MySqlException e)
                {
                    a.CloseConnection();
                }
                catch(OracleException e)
                {

                    b.CloseConnection();
                }
            }
        }

        public static void InsertCustomers(int n, MyConnect a, OracleConnect b, string imionaPath, string nazwiskaPath, string miastaPath)
        {
            string[] imiona = File.ReadAllLines(imionaPath);
            string[] nazwiska = File.ReadAllLines(nazwiskaPath);
            string[] miasta = File.ReadAllLines(miastaPath);

            Random rng = new Random();

            string name, lastName, city;
            int phone;


            Stopwatch timer = new Stopwatch();
            Increment inc = new Increment();
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
                //Console.WriteLine("wartość stringa {0}", String.Format(@"
                //insert into customers (first_name, last_name, city, email, phone)
                //values ('{0}', '{1}', '{2}', '{3}', '{4}')
                //", name, lastName, city, email, phone));


                while (true)
                {
                    try
                    {
                        a.Insert(String.Format(@"
                                            insert into customers 
                                            (first_name, last_name, city, email, phone) 
                                            values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}')
                                            ", name, lastName, city, inc.I, phone));

                        b.Insert(String.Format(@"
                                                    insert into customers 
                                                    (first_name, last_name, city, email, phone, customer_id) 
                                                    values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}', customer_id.nextval)
                                                    ", name, lastName, city, inc.I, phone));

                        Write(".");
                        inc.Reset();
                        break;
                    }
                    catch (MySqlException e) when (e.Number == 1062)
                    {
                        WriteLine("BŁĄD !! ||  " + e.Number + " ||  " + e.Message + "     \n");
                        continue;

                    }
                    catch (OracleException e) when (e.ErrorCode == -2147467259)
                    {

                        WriteLine("BŁĄD !! ||  " + e.ErrorCode + " ||  " + e.Message + "     \n");
                        b.CloseConnection();
                        continue;
                    }

                }

                //try
                //{

                //    inc.Reset();
                //    Write(".");
                //    a.Insert(String.Format(@"
                //                            insert into customers 
                //                            (first_name, last_name, city, email, phone) 
                //                            values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}')
                //                            ", name, lastName, city, inc.I, phone));
                //}
                //catch (MySqlException e) when (e.Number == 1062)
                //{
                //    WriteLine("BŁĄD !! ||  " + e.Number + " ||  " + e.Message + "     \n");

                //    a.CloseConnection();
                //    try
                //    {

                //        a.Insert(String.Format(@"
                //                            insert into customers 
                //                            (first_name, last_name, city, email, phone) 
                //                            values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}')
                //                            ", name, lastName, city, inc.I, phone));

                //    }
                //    catch (MySqlException)
                //    {
                //        //if (a.OpenConnection() == true) a.CloseConnection();
                //        throw e;
                //    }
                //MySqlCommand cmd = new MySqlCommand(String.Format(@"
                //                insert into customers 
                //                (first_name, last_name, city, email, phone) 
                //                values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}')
                //                ", name, lastName, city, inc.I, phone));
                //WriteLine("wartosc inc {0}", inc.I);
                //try
                //{
                //    fffffffffffffffffff
                //cmd.ExecuteNonQuery();

                //}
                //catch (MySqlException)
                //{

                //    throw;
                //}
                ////close connection
                //a.CloseConnection();
                ////inc.Reset();


                {
                    //if (a.OpenConnection() == true)
                    //{
                    //    //create command and assign the query and connection from the constructor
                    //    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //    try
                    //    {

                    //        //Execute command
                    //        cmd.ExecuteNonQuery();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        this.CloseConnection();
                    //        throw;
                    //    }


                    //    //close connection
                    //    this.CloseConnection();
                    //}
                }

                //default:
                //    {
                //        a.CloseConnection();
                //        break;
                //    }
                //ReadKey();
                //a.CloseConnection();
                //throw;
            }


            timer.Stop();
            Console.WriteLine("czas wykonywania: {0}", timer.Elapsed);
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


                d = rng.Next(0, 10000);
                lines[i] = String.Format("item{0},category{1},{2},{3}", i + 1, rng.Next(0, 100), d / 100, rng.Next(0, 1000));

            }
            System.IO.File.WriteAllLines(@"D:\Source\Repos\.Net-Projects\.Net-Projects\odb\lib\Data\stock.txt", lines);
            System.IO.File.WriteAllLines(@"D:\Source\Repos\.Net-Projects\.Net-Projects\odb\bin\Debug\Data\stock.txt", lines);
            t.Stop();
            Console.WriteLine("upłyneło {0}", t.Elapsed);

        }

        public static void Method()
        {
            string s = "Duplicate entry 'Bartlomiej.Kowalczyk@mail.com' for key 'email'";
        }

    }



    public static class CustmID
    {
        private static int _i = 1;
        public static int I
        {
            get
            {
                _i += 1;
                return _i;
            }
            private set { _i = value; }
        }
        public static void Reset(int r)
        {
            _i = r;
        }
    }

    public class Increment
    {
        private int _i = -1;
        public int I
        {
            get
            {
                _i += 1;
                return _i;
            }
            private set { _i = value; }
        }
        public void Reset()
        {
            this._i = -1;
        }
    }







}


