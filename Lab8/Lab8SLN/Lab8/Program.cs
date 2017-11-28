using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
            Console.ReadKey();



        }
    }
}
