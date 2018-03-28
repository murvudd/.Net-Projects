using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", miasta[1]));
            for (int i = 0; i < miasta.Length; i++)
            {
                try
                {
                    a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", miasta[i]));

                }
                catch (Exception)
                {

                    throw;
                }
            }




        }

        public static void InsertShops(MyConnect a, OracleConnect b, string miasto, int id)
        {
            string text = @"INSERT INTO SHOPS (CITY, SHOP_ID) values ({0}, {1});";
            a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ({0});", miasto));
            b.Insert(String.Format(text, miasto, id));
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
