﻿using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;


namespace odb
{
    static class StaticMethods
    {
        //public static void InsertOrders(MyConnect a, string stockPath, string miastaPath)
        //{
        //    WriteLine("Inserting orders");

        //    string[] stock = File.ReadAllLines(stockPath);
        //    string[] miasta = File.ReadAllLines(miastaPath);
        //    for (int j = 0; j < miasta.Length; j++)
        //    {

        //        foreach (var item in stock)
        //        {

        //            string[] i = item.Split(',');


        //            try
        //            {

        //                a.Insert(String.Format(@"
        //                                    Insert into stock (item_name, category, price, quantity, shop_id)
        //                                    values ('{0}', '{1}', '{2}', '{3}', '{4}') 
        //                                    ", i[0], i[1], i[2], i[3], j + 1));

        //                //b.Insert(String.Format(@"
        //                //                    Insert into stock (item_name, category, price, quantity, shop_id, item_id) 
        //                //                    values ('{0}', '{1}', {2}, {3}, {4}, {5})
        //                //                    ", i[0], i[1], i[2], i[3], j + 1, "stock_id.nextval"));

        //            }
        //            catch (MySqlException e)
        //            {
        //                WriteLine("mysql error : ", e.Message);
        //                throw;
        //            }
        //            //catch (OracleException e)
        //            //{
        //            //    WriteLine("oracle error : ", e.Message);
        //            //    throw;
        //            //}
        //        }
        //    }
        //}


        ////function adding stock to db's
        //public static void InsertStock(MyConnect a, OracleConnect b, string stockPath, string miastaPath)
        //{
        //    WriteLine("Inserting stock");

        //    string[] stock = File.ReadAllLines(stockPath);
        //    string[] miasta = File.ReadAllLines(miastaPath);
        //    for (int j = 0; j < miasta.Length; j++)
        //    {

        //        foreach (var item in stock)
        //        {

        //            string[] i = item.Split(',');


        //            try
        //            {

        //                a.Insert(String.Format(@"
        //                                    Insert into stock (item_name, category, price, quantity, shop_id)
        //                                    values ('{0}', '{1}', '{2}', '{3}', '{4}') 
        //                                    ", i[0], i[1], i[2], i[3], j + 1));

        //                b.Insert(String.Format(@"
        //                                    Insert into stock (item_name, category, price, quantity, shop_id, item_id) 
        //                                    values ('{0}', '{1}', {2}, {3}, {4}, {5})
        //                                    ", i[0], i[1], i[2], i[3], j + 1, "stock_id.nextval"));

        //            }
        //            catch (MySqlException e)
        //            {
        //                WriteLine("mysql error : ", e.Message);
        //                throw;
        //            }
        //            catch (OracleException e)
        //            {
        //                WriteLine("oracle error : ", e.Message);
        //                throw;
        //            }
        //        }
        //    }
        //}
        //public static void InsertStock(MyConnect a, string stockPath, string miastaPath)
        //{
        //    WriteLine("Inserting stock");

        //    string[] stock = File.ReadAllLines(stockPath);
        //    string[] miasta = File.ReadAllLines(miastaPath);
        //    for (int j = 0; j < miasta.Length; j++)
        //    {

        //        foreach (var item in stock)
        //        {

        //            string[] i = item.Split(',');


        //            try
        //            {

        //                a.Insert(String.Format(@"
        //                                    Insert into stock (item_name, category, price, quantity, shop_id)
        //                                    values ('{0}', '{1}', '{2}', '{3}', '{4}') 
        //                                    ", i[0], i[1], i[2], i[3], j + 1));

        //                //b.Insert(String.Format(@"
        //                //                    Insert into stock (item_name, category, price, quantity, shop_id, item_id) 
        //                //                    values ('{0}', '{1}', {2}, {3}, {4}, {5})
        //                //                    ", i[0], i[1], i[2], i[3], j + 1, "stock_id.nextval"));

        //            }
        //            catch (MySqlException e)
        //            {
        //                WriteLine("mysql error : ", e.Message);
        //                throw;
        //            }
        //            //catch (OracleException e)
        //            //{
        //            //    WriteLine("oracle error : ", e.Message);
        //            //    throw;
        //            //}
        //        }
        //    }
        //}

        //public static void InsertShop(MyConnect a, OracleConnect b, string miastoPath)
        //{
        //    WriteLine("inserting shops");
        //    string[] miasto = File.ReadAllLines(miastoPath);
        //    foreach (var item in miasto)
        //    {

        //        try
        //        {
        //            a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", item));
        //            b.Insert(String.Format(@"INSERT INTO SHOPS (CITY, SHOP_ID) values ('{0}', {1})", item, "shop_id.nextval"));

        //        }
        //        catch (MySqlException e)
        //        {
        //            WriteLine("mysql error : ", e.Message);
        //            a.CloseConnection();
        //        }
        //        catch (OracleException e)
        //        {
        //            WriteLine("oracle error : ", e.Message);
        //            b.CloseConnection();
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}
        //public static void InsertShop(MyConnect a, string miastoPath)
        //{
        //    WriteLine("inserting shops");
        //    string[] miasto = File.ReadAllLines(miastoPath);
        //    foreach (var item in miasto)
        //    {

        //        try
        //        {
        //            a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", item));
        //            //b.Insert(String.Format(@"INSERT INTO SHOPS (CITY, SHOP_ID) values ('{0}', {1})", item, "shop_id.nextval"));

        //        }
        //        catch (MySqlException e)
        //        {
        //            WriteLine("mysql error : ", e.Message);
        //            a.CloseConnection();
        //        }
        //        //catch (OracleException e)
        //        //{
        //        //    WriteLine("oracle error : ", e.Message);
        //        //    b.CloseConnection();
        //        //}
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}

        //public static void InsertCustomers(int n, MyConnect a, OracleConnect b, string imionaPath, string nazwiskaPath, string miastaPath)
        //{
        //    string[] imiona = File.ReadAllLines(imionaPath);
        //    string[] nazwiska = File.ReadAllLines(nazwiskaPath);
        //    string[] miasta = File.ReadAllLines(miastaPath);

        //    Random rng = new Random();

        //    string name, lastName, city;
        //    int phone;


        //    Stopwatch timer = new Stopwatch();
        //    Increment inc = new Increment();
        //    timer.Start();
        //    WriteLine("Running (...)\n");
        //    for (int i = 0; i < n; i++)
        //    {
        //        name = imiona[rng.Next(0, imiona.Length)];
        //        Thread.Sleep(1);
        //        lastName = nazwiska[rng.Next(0, nazwiska.Length)];
        //        Thread.Sleep(1);
        //        city = miasta[rng.Next(0, miasta.Length)];
        //        Thread.Sleep(1);
        //        phone = rng.Next(100000000, 1000000000);


        //        while (true)
        //        {
        //            try
        //            {
        //                b.Insert(String.Format(@"
        //                                            insert into customers 
        //                                            (first_name, last_name, city, email, phone, customer_id) 
        //                                            values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}', customer_id.nextval)
        //                                            ", name, lastName, city, inc.I, phone));
        //                a.Insert(String.Format(@"
        //                                    insert into customers 
        //                                    (first_name, last_name, city, email, phone) 
        //                                    values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}')
        //                                    ", name, lastName, city, inc.I, phone));


        //                Write(".");
        //                //inc.Reset();
        //                break;
        //            }
        //            catch (MySqlException e) when (e.Number == 1062)
        //            {
        //                WriteLine("\nBŁĄD !! ||  " + e.Number + " ||  " + e.Message + "     \n");
        //                continue;

        //            }
        //            catch (OracleException e) when (e.ErrorCode == -2147467259 && e.Number == 1)
        //            {

        //                WriteLine("\nBŁĄD !! ||  " + e.ErrorCode + " ||  " + e.Message + "  || number " + e.Number + "    \n");
        //                b.CloseConnection();
        //                continue;
        //            }
        //            catch (OracleException e) when (e.Number == 1654)
        //            {
        //                throw;
        //            }
        //        }

        //    }

        //    timer.Stop();
        //    Console.WriteLine("czas wykonywania: {0}", timer.Elapsed);
        //}
        //public static void InsertCustomers(int n, MyConnect a, string imionaPath, string nazwiskaPath, string miastaPath)
        //{
        //    string[] imiona = File.ReadAllLines(imionaPath);
        //    string[] nazwiska = File.ReadAllLines(nazwiskaPath);
        //    string[] miasta = File.ReadAllLines(miastaPath);

        //    Random rng = new Random();

        //    string name, lastName, city;
        //    int phone;


        //    Stopwatch timer = new Stopwatch();
        //    //Increment inc = new Increment();
        //    timer.Start();
        //    WriteLine("Running (...)\n");
        //    for (int i = 0; i < n; i++)
        //    {
        //        name = imiona[rng.Next(0, imiona.Length)];
        //        Thread.Sleep(1);
        //        lastName = nazwiska[rng.Next(0, nazwiska.Length)];
        //        Thread.Sleep(1);
        //        city = miasta[rng.Next(0, miasta.Length)];
        //        Thread.Sleep(1);
        //        phone = rng.Next(100000000, 1000000000);

        //        int k = 0;
        //        while (true)
        //        {
        //            try
        //            {
        //                //b.Insert(String.Format(@"
        //                //                            insert into customers 
        //                //                            (first_name, last_name, city, email, phone, customer_id) 
        //                //                            values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}', customer_id.nextval)
        //                //                            ", name, lastName, city, inc.I, phone));
        //                a.Insert(String.Format(@"
        //                                    insert into customers 
        //                                    (first_name, last_name, city, email, phone) 
        //                                    values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}')
        //                                    ", name, lastName, city, k, phone));


        //                Write(".");
        //                k = 0;
        //                break;
        //            }
        //            catch (MySqlException e) when (e.Number == 1062)
        //            {
        //                WriteLine("\nBŁĄD !! ||  " + e.Number + " ||  " + e.Message + "     \n");
        //                MySqlCommand cmd = new MySqlCommand(String.Format(@"select count(*) from customers where (customers.first_name = '{0}' && customers.last_name = '{1}');", name, lastName), a.connection);
        //                a.OpenConnection();
        //                int.TryParse(cmd.ExecuteScalar() + "", out k);
        //                a.CloseConnection();
        //                continue;

        //            }
        //            //catch (OracleException e) when (e.ErrorCode == -2147467259 && e.Number == 1)
        //            //{

        //            //    WriteLine("\nBŁĄD !! ||  " + e.ErrorCode + " ||  " + e.Message + "  || number " + e.Number + "    \n");
        //            //    b.CloseConnection();
        //            //    continue;
        //            //}
        //            //catch (OracleException e) when (e.Number == 1654)
        //            //{
        //            //    throw;
        //            //}
        //        }

        //    }

        //    timer.Stop();
        //    Console.WriteLine("czas wykonywania: {0}", timer.Elapsed);
        //}

        //public static void InsertOrders(MyConnect a, int n)
        //{
        //    int[] list = a.CheckMaxCustmIDItmID();
        //    int j, k;
        //    Random rng = new Random();
        //    WriteLine("inserting orders");
        //    int cstm_id, itm_id;
        //    if (list[0] != -1 && list[1] != -1)
        //    {
        //        for (int i = 0; i < n; i++)
        //        {
        //            while (true)
        //            {
        //                cstm_id = rng.Next(1, list[0] + 1);
        //                itm_id = rng.Next(1, list[1] + 1);
        //                j = a.Count(String.Format(@"select count(*) from customers where customer_id = {0}", cstm_id));
        //                k = a.Count(String.Format(@"select count(*) from stock where item_id = {0}", itm_id));
        //                if (j != 0 && k != 0)
        //                {

        //                    a.Insert(String.Format(@"
        //                               insert into orders (customer_id, item_id) values ({0},{1})
        //                               ", cstm_id, itm_id));
        //                    Write(".");
        //                    break;
        //                }
        //                else
        //                {
        //                    WriteLine("\nnie istnieje taki rekord\n");
        //                    continue;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        WriteLine("Can't insert orders max customer_id {0}, stock_id {1}", list[0], list[1]);
        //    }
        //}

        //public static string RandomDay(Random rng, int range, DateTime start)
        //{
        //    return start.AddDays(rng.Next(range)).ToString("yyyy-MM-dd H:mm:ss"); ;
        //}

        //public static void InsertOrderStatus(MyConnect a, int n)
        //{
        //    string[] status = new string[]
        //    {
        //        "Order Created",
        //        "Order Confirmed",
        //        "Order Send!",
        //        "Order Received",
        //        "Order Closed",
        //    };
        //    int MaxOrderId = a.SelectMaxOrderID();
        //    WriteLine("Maxorder id {0}", MaxOrderId);
        //    //ReadKey();
        //    int ordr_id;
        //    Random rng = new Random();
        //    DateTime start = new DateTime(2016, 1, 1);
        //    int range = (DateTime.Today - start).Days;
        //    for (int i = 0; i < n; i++)
        //    {

        //        while (true)
        //        {
        //            ordr_id = rng.Next(1, MaxOrderId + 1);
        //            int j = a.Count(String.Format("select count(*) from orders where order_id = '{0}';", ordr_id));
        //            if (j != 0)
        //            {
        //                Console.WriteLine("Trying insert orded status");
        //                try
        //                {
        //                    a.Insert(String.Format(@"
        //                                     insert into order_status (status, status_changed, order_id)
        //                                     values ('{0}', '{1}', '{2}');
        //                                     ", status[0], RandomDay(rng, range, start), ordr_id));
        //                    break;
        //                }
        //                catch (Exception e)
        //                {
        //                    Console.WriteLine("BŁĄD : {0}", e.Message);
        //                    throw;
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("error");
        //                continue;
        //            }
        //        }
        //    }
        //}

        //public static void CreateNewStock(int n)
        //{
        //    Stopwatch t = new Stopwatch();
        //    t.Start();

        //    string[] lines = new string[n];
        //    decimal d;
        //    Random rng = new Random();
        //    for (int i = 0; i < lines.Length; i++)
        //    {


        //        d = rng.Next(1, 10000);
        //        lines[i] = String.Format("item{0},category{1},{2},{3}", i + 1, rng.Next(0, 100), d / 100, rng.Next(1, 1000));

        //    }
        //    //System.IO.File.WriteAllLines(@"D:\Source\Repos\.Net-Projects\.Net-Projects\odb\lib\Data\stock.txt", lines);
        //    System.IO.File.WriteAllLines(@"D:\dokumenty\Source\Repos\.Net-Projects\odb\bin\Debug\Data\stock.txt", lines);
        //    t.Stop();
        //    Console.WriteLine("upłyneło {0}", t.Elapsed);

        //}


        ////        public static void TruncateDB(MyConnect a)
        ////        {
        ////            //query AUTO_INCREMENT=10001 
        ////            string sa = @"

        ////                DROP database eshopinnodb;
        ////Create database eshopInnoDB;
        ////use eshopInnoDB;


        ////CREATE TABLE `shops` (
        ////  `city` char(20) UNIQUE,
        ////  `shop_id` int(10) unsigned AUTO_INCREMENT,
        ////  PRIMARY KEY (`shop_id`)
        ////) ENGINE=InnoDB DEFAULT CHARSET=utf8;


        ////CREATE TABLE `orders` (
        ////  `order_id` int(10) unsigned  AUTO_INCREMENT,
        ////  `customer_id` int(10) unsigned ,
        ////  `item_id` int(10) unsigned ,
        ////  PRIMARY KEY (`order_id`)
        ////  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;



        ////CREATE TABLE `stock` (
        ////  `item_name` varchar(15) ,
        ////  `category` varchar(15) ,
        ////  `quantity` int(10) unsigned ,
        ////  `price` decimal(6,2) ,
        ////  `shop_id` int(10) unsigned ,
        ////  `item_id` int(10) unsigned AUTO_INCREMENT,
        ////  PRIMARY KEY (`item_id`),
        ////  KEY `shop_id` (`shop_id`)

        ////) ENGINE=InnoDB DEFAULT CHARSET=utf8;


        ////CREATE TABLE `order_status` (
        ////  `status` varchar(255) ,
        ////  `status_changed` datetime ,
        ////  `order_id` int(10) unsigned ,
        ////  `status_id` int(10) unsigned AUTO_INCREMENT unique
        ////  -- UNIQUE KEY `status_id` (`status_id`),
        ////  -- KEY `order_id` (`order_id`)

        ////) ENGINE=InnoDB DEFAULT CHARSET=utf8;


        ////CREATE TABLE `customers` (
        ////  `first_name` char(20) ,
        ////  `last_name` char(30) ,
        ////  `city` char(50) ,
        ////  `email` varchar(255) unique,
        ////  `phone` varchar(20) ,
        ////  `customer_id` int(10) unsigned AUTO_INCREMENT,
        ////  PRIMARY KEY (`customer_id`)
        ////) ENGINE=InnoDB DEFAULT CHARSET=utf8;


        ////            ";

        ////            a.Insert(sa);
        ////            a.ApplyConstraints();
        ////        }

        ////        public static void ApplyConstraints(MyConnect a)
        ////        {
        ////            string sa = @"

        ////alter table `order_status` 
        ////add CONSTRAINT `order_status_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`);

        ////alter table `stock`
        ////	add CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`shop_id`) REFERENCES `shops` (`shop_id`);

        ////ALTER TABLE `orders` 
        ////	add CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`),
        ////	add CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`item_id`) REFERENCES `stock` (`item_id`);
        ////                         ";
        ////            a.Insert(sa);
        ////        }
        //public static void Task(MyConnect myConnect)
        //{
        //    WriteLine("Starting new thread, {0}", Thread.CurrentThread.Name);
        //    Random rng = new Random();

            
        //    switch (rng.Next())
        //    {
        //        case 0:

        //        case 1:
        //        case 2:
        //        case 3:
        //        case 4:
        //        case 5:

        //        default:
        //            break;
        //    }


        //}
    }
}
