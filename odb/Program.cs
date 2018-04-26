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
using static odb.StaticMethods;
using static odb.TestConnect;

namespace odb
{
    class Program
    {
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
            UserOfDB root = new UserOfDB();
            root.TruncateUsers(100);
            for (int i = 0; i < 100; i++)
            {

                thread[i] = new Thread(Task)
                {
                    Name = i + ""
                };
                thread[i].Start();

            }
            UserOfDB.IKupa kupa = new UserOfDB.Customer();
            UserOfDB.Customer myFoo = new UserOfDB.Customer();
            
        }
        static Thread[] thread = new Thread[100];
        static void Task()
        {
            UserOfDB user = new UserOfDB("user" + Thread.CurrentThread.Name);
            for (int i = 0; i < 100; i++)
            {
                user.UserInsertOrders();
            }

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


