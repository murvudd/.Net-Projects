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
        static void DumpToSqlInsert(string InPath, string OutPath)
        {
            List<string> LineList = new List<string>();
            //string[] text = File.ReadAllLines(@"D:\Dokumenty\Dump20180608.sql");
            string[] text = File.ReadAllLines(InPath);
            foreach (string line in text)
            {
                if (line.Contains(@"INSERT INTO `stock`"))
                {
                    LineList.Add(line);
                }
            }

            File.WriteAllLines(path: OutPath, contents: LineList);
            //File.AppendAllLines(@"D:\Source\Repos\.Net-Projects\.Net-Projects\odb\lib\OracleInsertStock.txt", LineList);

        }
        static Thread[] AdminThread = new Thread[5];
        static Thread[] CustomerThread = new Thread[100 - AdminThread.Length];
        // pierwotny main (drugie sprawko

        //static void Main(string[] args)
        //{
        //    //public static void InitalizeDB(MyConnect a, int[] n)
        //    //{
        //    //    if (n.Length == 4)
        //    //    {

        //    //        TruncateDB(a);
        //    //        ApplyConstraints(a);

        //    //        InsertShop(a, "Data/miasta.txt");
        //    //        CreateNewStock(n[0]);
        //    //        InsertStock(a, "Data/stock.txt", "Data/miasta.txt");

        //    //        InsertCustomers(n[1], a, "Data/imiona.txt", "Data/nazwiska.txt", "Data/miasta_all.txt");


        //    //        InsertOrders(a, n[2]);
        //    //        InsertOrderStatus(a, n[3]);
        //    //    }
        //    //}
        //    UserOfDB.Admin root = new UserOfDB.Admin();


        //    root.DropUsers();
        //    root.DropAdmins();

        //    for (int i = 0; i < AdminThread.Length; i++)
        //    {
        //        AdminThread[i] = new Thread(root.CreateAdmin("admin" + i).AdminSim)
        //        {
        //            Name = i + ""
        //        };
        //        WriteLine("AdminThread" + AdminThread[i].Name + "  rozpoczyna pracę");
        //        AdminThread[i].Start();
        //    }
        //    for (int i = 0; i < AdminThread.Length; i++)
        //    {
        //        AdminThread[i] = new Thread(root.CreateAdmin("Customer" + i).CustomerSim)
        //        {
        //            Name = i + ""
        //        };
        //        WriteLine("AdminThread" + AdminThread[i].Name + "  rozpoczyna pracę");
        //        AdminThread[i].Start();
        //    }
        //    //WriteLine("za minute zamknięcie threadów");
        //    //Thread.Sleep(10 * 1000);
        //    //WriteLine("zamykanie threadów");
        //    //foreach (var thrd in thread)
        //    //{
        //    //    thrd.Abort();
        //    //}
        //    //WriteLine("thready zamkniete");

        //}
        static void Main(string[] args)
        {
            LocalOracleConnect root = new LocalOracleConnect();

            string[] InsertStringSql = File.ReadAllLines(@"D:\dokumenty\Source\Repos\.Net-Projects\odb\lib\OracleInsert\OrderStatusPt3.txt");
            int i = 0;
            foreach (string line in InsertStringSql)
            {
                root.Insert(line);
                
                Console.WriteLine(i++);
            }

            //for (int i = 12707; i < 19999; i++)
            //{
            //    root.Insert(InsertStringSql[i]);
            //    Console.Write(".");
            //}


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


