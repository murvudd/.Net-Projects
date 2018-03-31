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




            ////a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", miasta[1]));
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

        public static void InsertEshop(MyConnect a, OracleConnect b, string miasto, int id)
        {
            string text = @"INSERT INTO SHOPS (CITY, SHOP_ID) values ({0}, {1});";
            a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ({0});", miasto));
            b.Insert(String.Format(text, miasto, id));
        }


        public static void Write()
        {
            string item_name = "Item";
            string category = "Category";
            int quantity;
            decimal price;
            int shop_id;
            Random rng = new Random();

            for (int i = 0; i < 10; i++)
            {
                item_name = item_name + " " + i + 1;
                category = category + " " + i + 1;
                quantity = rng.Next(0, 20);
                Thread.Sleep(1);
                price = rng.Next(100, 1000)/100;


                File.WriteAllLines(@"C:\Users\Żaba\Desktop\.Net-Projects\odb\lib\Item.txt", item_name, category, quantity.ToString, price.ToString, shop_id.ToString, lines);
            }
        }

        public static void InsertStock(MyConnect a, OracleConnect b)
        {
            Random rng = new Random();
            string @string = @"insert into stock (item name, category, quantity, price, shop_id) 
                                           values ('{0}', '{1}', {2}, {3}, {4}, {5})";
            a.Insert(string.Format(@string));

        }

        public void InsertCustomers()
        {

        }

        //public static string RNGCity()
        //{
        //    string s;
        //    Random rng = new Random();

        //    switch (rng.Next(0,10))
        //    {
        //        case 0:
        //            s = "Warszawa";
        //            break;

        //        case 1:
        //            s = "Kraków";
        //            break;

        //        case 2:
        //            s = "Łódź";
        //            break;

        //        case 3:
        //            s = "Wrocław";
        //            break;

        //        case 4:
        //            s = "Poznań";
        //            break;

        //        case 5:
        //            s = "Gdańsk";
        //            break;

        //        case 6:
        //            s = "Szczecin";
        //            break;

        //        case 7:
        //            s = "Bydgoszcz";
        //            break;

        //        case 8:
        //            s = "Lublin";
        //            break;

        //        case 9:
        //            s = "Katowice";
        //            break;

        //        default:
        //            s = "Internet";
        //            break;
        //    }
        //    return s;

        //}


    }
}
