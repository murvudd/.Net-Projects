using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Oracle.ManagedDataAccess.Client;
using System.IO;


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
            string[] imiona = File.ReadAllLines("imiona.txt");
            string[] nazwiska = File.ReadAllLines("nazwiska.txt");
            string[] miasta = File.ReadAllLines("miasta.txt");
            string[] stock = File.ReadAllLines("stock.csv");

            

            
            //InsertShop(a, b, miasta);
            //InsertStock(a, b, "stock.csv", miasta);

            {////a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", miasta[1]));
             //for (int i = 0; i < miasta.Length; i++)
             //{
             //    try
             //    {
             //        a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", miasta[i]));

                //    }
                //    catch (Exception e)
                //    {
                //        Console.WriteLine(e.Message);

                //    }
                //}
                //for (int i = 0; i < miasta.Length; i++)
                //{
                //    try
                //    {
                //        b.Insert(String.Format(@"INSERT INTO SHOPS (CITY, shop_id) values ('{0}', {1});", miasta[i], i+1));

                //    }
                //    catch (Exception e)
                //    {
                //        Console.WriteLine(e.Message);

                //    }
                //}
            }



        }
        public static void InsertStock(MyConnect a, OracleConnect b, string path, string[] miasta)
        //function adding stock to db's
        {
            int k = 0;
            string[] stock = File.ReadAllLines(path);
            for (int j = 0; j < miasta.Length; j++)
            {

                foreach (var item in stock)
                {

                    string[] i = item.Split(',');
                    string s1 = @"Insert into stock (item_name, category, price, quantity, shop_id) values ('{0}', '{1}', '{2}', '{3}', '{4}') ";
                    string s2 = @"Insert into stock (item_name, category, price, quantity, shop_id, item_id) values ('{0}', '{1}', {2}, {3}, {4}, {5})";
                    //Console.WriteLine(" wartosc i0: {0}", i[0]);

                    Console.WriteLine(" wartosc stringa s: {0}", String.Format(s2, i[0], i[1], i[2], i[3], j + 1, k));
                    //a.Insert(String.Format(s1, i[0], i[1], i[2], i[3], j + 1));
                    k += 1;
                    //b.Insert(String.Format(s2, i[0], i[1], i[2], i[3], j + 1, k));

                }
            }
        }



        public static void InsertShop(MyConnect a, OracleConnect b, string[] miasto)
        //
        {
            int k = 0;
            foreach (var item in miasto)
            {
                k += 1;
                a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", item));
                b.Insert(String.Format(@"INSERT INTO SHOPS (CITY, SHOP_ID) values ('{0}', '{1}')", item, k));
            }
        }





        public void InsertCustomers()
        {

        }




    }
}
