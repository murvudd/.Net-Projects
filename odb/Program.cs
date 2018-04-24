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
            MyConnect root = new MyConnect();
            for (int i = 0; i < 100; i++)
            {
            Console.WriteLine("{0}      {1}",i,root.CheckEmailOfCustomer()==null);
                Thread.Sleep(10);
            }


            //MyConnect[] myConnect = new MyConnect[5];
            //myConnect[0] = new MyConnect(root.CheckEmailOfCustomer());
            //////OracleConnect b = new OracleConnect();
            //////Random rng = new Random();

            //////b.Check();
            //////


            ////root.InitializeDB(new int[] { 25, 10, 15, 20 });


            //a.Insert("insert into order_status(status, status_changed, order_id) values('Order Created', '2018-04-17 10:47:51', 10002);");

        }

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


