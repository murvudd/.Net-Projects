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

        static Thread[] AdminThread = new Thread[5];
        static Thread[] CustomerThread = new Thread[200 - AdminThread.Length];
        static void Main(string[] args)
        {
            //public static void InitalizeDB(MyConnect a, int[] n)
            //{
            //    if (n.Length == 4)
            //    {

            //        TruncateDB(a);
            //        ApplyConstraints(a);

            //        InsertShop(a, "Data/miasta.txt");
            //        CreateNewStock(n[0]);
            //        InsertStock(a, "Data/stock.txt", "Data/miasta.txt");

            //        InsertCustomers(n[1], a, "Data/imiona.txt", "Data/nazwiska.txt", "Data/miasta_all.txt");


            //        InsertOrders(a, n[2]);
            //        InsertOrderStatus(a, n[3]);
            //    }
            //}
            UserOfDB.Admin root = new UserOfDB.Admin();
            

            root.DropUsers();
            root.DropAdmins();
            
            for (int i = 0; i < AdminThread.Length; i++)
            {
                AdminThread[i] = new Thread(root.CreateAdmin("admin" + i).AdminSim)
                {
                    Name = i + ""
                };
                WriteLine("AdminThread" + AdminThread[i].Name + "  rozpoczyna pracę");
                AdminThread[i].Start();
            }
            for (int i = 0; i < AdminThread.Length; i++)
            {
                AdminThread[i] = new Thread(root.CreateAdmin("Customer" + i).CustomerSim)
                {
                    Name = i + ""
                };
                WriteLine("AdminThread" + AdminThread[i].Name + "  rozpoczyna pracę");
                AdminThread[i].Start();
            }
            //WriteLine("za minute zamknięcie threadów");
            //Thread.Sleep(10 * 1000);
            //WriteLine("zamykanie threadów");
            //foreach (var thrd in thread)
            //{
            //    thrd.Abort();
            //}
            //WriteLine("thready zamkniete");

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


