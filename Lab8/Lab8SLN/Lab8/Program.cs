using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using Lab8.Models;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnect a = new DBConnect();
            
            
            //            Console.WriteLine("Connectiod_id: {0}",a.Count("select connection_id

            //Console.Write(a.SelectAllFrom());
            /* TODO
             *  Dodać wyświetlanie tabel / wypisanie listy stringów 
             *  dodać w aplikacji konsolowej loopa z casem od wybierania przez użytkownika kolejnego kroku
             *  
             */

            Console.WriteLine(a.SelectAll());
            Console.ReadKey();



        }

        static void PopulateDB(DBConnect a)
        {
            string[] plik = File.ReadAllLines("all_month.csv");
            //char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            for (int i = 1; i < plik.Length; i++)
            {
                string[] b = plik[i].Split(',');
                string[] c = b[0].Split('-');
                int d0 = Convert.ToInt32(c[0]);
                string[] d1 = b[13].Split('"');
                string[] d2 = b[14].Split('"');


                try
                {
                    a.InsertEarthquake(d0, d1[1], d2[0], b[4]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Błąd     {0}     {1}\n{2}        {3}", e.Message, e.StackTrace, e.Source, e.InnerException);

                }
                //ID = b[11],
                //Rok = Convert.ToInt32(c[0]),
                //Siła = Convert.ToInt32(b[4]),
                //Kraj = "USA",
                //Miejsce = b[13],


            }
            Console.WriteLine("Gotowe!");
        }
    }
}
