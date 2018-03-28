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
            
            b.Check();
            string[] imiona = File.ReadAllLines("imiona.txt");
            string[] nazwiska = File.ReadAllLines("nazwiska.txt");
            string[] miasta = File.ReadAllLines("miasta.txt");


            b.Insert(@"insert into shops values ('"+miasta[1]+"' , "+5+")");
            Console.WriteLine(miasta[1]);
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
