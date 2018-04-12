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
            //string[] imiona = File.ReadAllLines("imiona.txt");
            //string[] nazwiska = File.ReadAllLines("nazwiska.txt");
            //string[] miasta = File.ReadAllLines("miasta.txt");
            //string[] stock = File.ReadAllLines("stock.csv");



            InsertCustomers(100000, a, b, "imiona.txt", "nazwiska.txt", "miasta_all.txt");
            //InsertShop(a, b, "miasta.txt");
            //InsertStock(a, b, "stock.csv", miasta);


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
                    //a.Insert(String.Format(s1, i[0], i[1], i[2], i[3], j + 1));
                    k += 1;
                    //b.Insert(String.Format(s2, i[0], i[1], i[2], i[3], j + 1, k));

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
                catch (Exception)
                {
                    a.CloseConnection();
                    b.CloseConnection();
                }
            }
        }

        public static void InsertCustomers(int n, MyConnect a, OracleConnect b, string imionaPath, string nazwiskaPath, string miastaPath)
        {
            string[] imiona = File.ReadAllLines(imionaPath);
            string[] nazwiska = File.ReadAllLines(nazwiskaPath);
            string[] miasta = File.ReadAllLines(miastaPath);

            Random rng1 = new Random();
            Random rng2 = new Random();
            Random rng3 = new Random();
            Random rng4 = new Random();
            string name, lastName, city, email;
            int phone;


            Stopwatch timer = new Stopwatch();

            timer.Start();
            WriteLine("Running (...)\n");
            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(1);
                name = imiona[rng1.Next(0, imiona.Length)];
                lastName = nazwiska[rng2.Next(0, nazwiska.Length)];
                city = miasta[rng3.Next(0, miasta.Length)];
                email = name + "." + lastName + "@mail.com";
                phone = rng4.Next(100000000, 1000000000);
                //Console.WriteLine("wartość stringa {0}", String.Format(@"insert into customers (first_name, last_name, city, email, phone) values ('{0}', '{1}', '{2}', '{3}', '{4}')", name, lastName, city, email, phone));

                try
                {

                    Write(".");
                    a.Insert(String.Format(@"insert into customers (first_name, last_name, city, email, phone) values ('{0}', '{1}', '{2}', '{3}', '{4}')", name, lastName, city, email, phone));
                }
                catch (MySqlException e)
                {
                    switch (e.Number)
                    {
                        case 1062:

                            break;

                        default:
                            {
                                a.CloseConnection();
                                break;
                            }
                    }
                    WriteLine("BŁĄD !!   " + e.Number + " ||  " + e.Message + "     \n");
                    ReadKey();
                    a.CloseConnection();
                    //throw;
                }

                try
                {
                    b.Insert(String.Format(@"insert into customers (first_name, last_name, city, email, phone, customer_id) values ('{0}', '{1}', '{2}', '{3}', {4}, {5})", name, lastName, city, email, phone, i + 1));

                }
                catch (OracleException e)
                {
                    WriteLine("oracle e.Number " + e.Number + "oracle error code" + e.ErrorCode);
                    b.CloseConnection();
                    throw;
                }

            }
            timer.Stop();
            Console.WriteLine("czas wykonywania: {0}", timer.Elapsed);

        }

        public static void CreateNewStock()
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            string s;
            string[] lines = new string[800];
            decimal d;
            Random rng = new Random();
            for (int i = 0; i < lines.Length; i++)
            {
                s = @"item{0},category{1},{2},{3}";
                d = rng.Next(0, 10000);

                lines[i] = String.Format(s, i + 1, rng.Next(0, 100), d / 100, rng.Next(0, 1000));

            }
            System.IO.File.WriteAllLines(@"C:\Users\Żaba\Desktop\.Net-Projects\odb\lib\stock.txt", lines);
            t.Stop();
            Console.WriteLine("upłyneło {0}", t.Elapsed);

        }

        public static void Method()
        {
            string s = "Duplicate entry 'Bartlomiej.Kowalczyk@mail.com' for key 'email'";
        }


    }
}
