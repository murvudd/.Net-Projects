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
        static void Main(string[] args)
        {
            MyConnect a = new MyConnect();
            OracleConnect b = new OracleConnect();
            Random rng = new Random();

            b.Check();

            TruncateDB(a);

            InsertShop(a, b, "Data/miasta.txt");
            CreateNewStock(1500);
            InsertStock(a, b, "Data/stock.txt", "Data/miasta.txt");

            InsertCustomers(1000000, a, b, "Data/imiona.txt", "Data/nazwiska.txt", "Data/miasta_all.txt");


        }


        //function adding stock to db's
        public static void InsertStock(MyConnect a, OracleConnect b, string stockPath, string miastaPath)
        {
            Console.WriteLine("Inserting stock");

            string[] stock = File.ReadAllLines(stockPath);
            string[] miasta = File.ReadAllLines(miastaPath);
            for (int j = 0; j < miasta.Length; j++)
            {

                foreach (var item in stock)
                {

                    string[] i = item.Split(',');


                    try
                    {

                    a.Insert(String.Format(@"
                                            Insert into stock (item_name, category, price, quantity, shop_id)
                                            values ('{0}', '{1}', '{2}', '{3}', '{4}') 
                                            ", i[0], i[1], i[2], i[3], j + 1));

                    b.Insert(String.Format(@"
                                            Insert into stock (item_name, category, price, quantity, shop_id, item_id) 
                                            values ('{0}', '{1}', {2}, {3}, {4}, {5})
                                            ", i[0], i[1], i[2], i[3], j + 1, "stock_id.nextval"));

                    }
                    catch (MySqlException e)
                    {
                        WriteLine("mysql error : ",e.Message);
                        throw;
                    }
                    catch (OracleException e)
                    {
                        WriteLine("oracle error : ", e.Message);
                        throw;
                    }
                }
            }
        }

        public static void InsertShop(MyConnect a, OracleConnect b, string miastoPath)
        {
            WriteLine("inserting shops");
            string[] miasto = File.ReadAllLines(miastoPath);
            foreach (var item in miasto)
            {

                try
                {
                    a.Insert(String.Format(@"INSERT INTO SHOPS (CITY) values ('{0}');", item));
                    b.Insert(String.Format(@"INSERT INTO SHOPS (CITY, SHOP_ID) values ('{0}', '{1}')", item, "shop_id.nextval"));

                }
                catch (MySqlException e)
                {
                    WriteLine("mysql error : ", e.Message);
                    a.CloseConnection();
                }
                catch (OracleException e)
                {
                    WriteLine("oracle error : ", e.Message);
                    b.CloseConnection();
                }
            }
        }

        public static void InsertCustomers(int n, MyConnect a, OracleConnect b, string imionaPath, string nazwiskaPath, string miastaPath)
        {
            string[] imiona = File.ReadAllLines(imionaPath);
            string[] nazwiska = File.ReadAllLines(nazwiskaPath);
            string[] miasta = File.ReadAllLines(miastaPath);

            Random rng = new Random();

            string name, lastName, city;
            int phone;


            Stopwatch timer = new Stopwatch();
            Increment inc = new Increment();
            timer.Start();
            WriteLine("Running (...)\n");
            for (int i = 0; i < n; i++)
            {
                name = imiona[rng.Next(0, imiona.Length)];
                Thread.Sleep(1);
                lastName = nazwiska[rng.Next(0, nazwiska.Length)];
                Thread.Sleep(1);
                city = miasta[rng.Next(0, miasta.Length)];
                Thread.Sleep(1);
                phone = rng.Next(100000000, 1000000000);


                while (true)
                {
                    try
                    {
                        a.Insert(String.Format(@"
                                            insert into customers 
                                            (first_name, last_name, city, email, phone) 
                                            values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}')
                                            ", name, lastName, city, inc.I, phone));

                        b.Insert(String.Format(@"
                                                    insert into customers 
                                                    (first_name, last_name, city, email, phone, customer_id) 
                                                    values ('{0}', '{1}', '{2}', '{0}.{1}@mail{3}.com', '{4}', customer_id.nextval)
                                                    ", name, lastName, city, inc.I, phone));

                        Write(".");
                        inc.Reset();
                        break;
                    }
                    catch (MySqlException e) when (e.Number == 1062)
                    {
                        WriteLine("BŁĄD !! ||  " + e.Number + " ||  " + e.Message + "     \n");
                        continue;

                    }
                    catch (OracleException e) when (e.ErrorCode == -2147467259)
                    {

                        WriteLine("BŁĄD !! ||  " + e.ErrorCode + " ||  " + e.Message + "     \n");
                        b.CloseConnection();
                        continue;
                    }
                    catch (OracleException e)
                    {
                        throw;
                    }
                }

            }

            timer.Stop();
            Console.WriteLine("czas wykonywania: {0}", timer.Elapsed);
        }

        public static void CreateNewStock(int n)
        {
            Stopwatch t = new Stopwatch();
            t.Start();

            string[] lines = new string[n];
            decimal d;
            Random rng = new Random();
            for (int i = 0; i < lines.Length; i++)
            {


                d = rng.Next(0, 10000);
                lines[i] = String.Format("item{0},category{1},{2},{3}", i + 1, rng.Next(0, 100), d / 100, rng.Next(0, 1000));

            }
            System.IO.File.WriteAllLines(@"D:\Source\Repos\.Net-Projects\.Net-Projects\odb\lib\Data\stock.txt", lines);
            System.IO.File.WriteAllLines(@"D:\Source\Repos\.Net-Projects\.Net-Projects\odb\bin\Debug\Data\stock.txt", lines);
            t.Stop();
            Console.WriteLine("upłyneło {0}", t.Elapsed);

        }

        public static void TruncateDB(MyConnect a)
        {

            string sa = @"
            
                start transaction;

DROP database eshopinnodb;
Create database eshopInnoDB;
use eshopInnoDB;


CREATE TABLE `shops` (
  `city` char(20) UNIQUE,
  `shop_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`shop_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `orders` (
  `order_id` int(10) unsigned  AUTO_INCREMENT,
  `custm_id` int(10) unsigned ,
  `item_id` int(10) unsigned ,
  PRIMARY KEY (`order_id`)
  ) ENGINE=InnoDB AUTO_INCREMENT=10001 DEFAULT CHARSET=utf8;


	
CREATE TABLE `stock` (
  `item_name` varchar(15) ,
  `category` varchar(15) ,
  `quantity` int(10) unsigned ,
  `price` decimal(6,2) ,
  `shop_id` int(10) unsigned ,
  `item_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`item_id`),
  KEY `shop_id` (`shop_id`)
  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `order_status` (
  `status` varchar(20) ,
  `order_date` datetime ,
  `order_id` int(10) unsigned ,
  `status_id` int(10) unsigned AUTO_INCREMENT unique
  -- UNIQUE KEY `status_id` (`status_id`),
  -- KEY `order_id` (`order_id`)
  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `customers` (
  `first_name` char(20) ,
  `last_name` char(30) ,
  `city` char(50) ,
  `email` varchar(255) unique,
  `phone` varchar(20) ,
  `customer_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



alter table `order_status` 
add CONSTRAINT `order_status_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`);

alter table `stock`
	add CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`shop_id`) REFERENCES `shops` (`shop_id`);

ALTER TABLE `orders` 
	add CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`custm_id`) REFERENCES `customers` (`customer_id`),
	add CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`item_id`) REFERENCES `stock` (`item_id`);
commit;
            
            ";
            // string a


//            string sb = @"
//            drop table customers;
//            drop table order_status;
//            drop table orders;
//            drop table shops;
//            drop table stock;


//create table shops(

//	city varchar2(20 char) not null unique,
//	shop_id NUMBER primary key
//)

//CREATE TABLE stock(
//	item_name VARCHAR2(20 char),
//	categry VARCHAR2(15 char) not null,
    
    
//	quantity    NUMBER not null
//    CONSTRAINT check_qty CHECK (quantity > 0),
      
//	price decimal(6,2) 
//    CONSTRAINT nn_price NOT NULL 
//    CONSTRAINT check_price CHECK (price > 0),

//	shop_id NUMBER not null,
//    -- CONSTRAINT fk_stock FOREIGN KEY (shops) references shops(shop_id),

//	item_id NUMBER primary key

//    -- GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1),
//    -- CONSTRAINT pk_stock PRIMARY KEY (item_id)
//)

//CREATE TABLE order_status
//( 
//    status varchar2(20 char) not null,

//	order_date date not null,

//	order_id NUMBER(10) not null
//		CONSTRAINT uint_order_id check (order_id > 0),

//	status_id NUMBER(10) not null,
//		CONSTRAINT uint_status_id check (status_id > 0)
    
//    /*CONSTRAINT fk_order_status
//        FOREIGN KEY (order_id)
//        REFERENCES orders(order_id) */
//)

//create table orders(
//	order_id number(10) primary key,
//	custm_id number(10),
//	item_id number(10)
//)

//create table customers(
//	first_name char(20 char),
//	last_name char(30 char),
//	city char(50),
//	email varchar2(255) Unique,
//	phone varchar2(20 char),
//	customer_id number(10) primary key 
//)

//CREATE SEQUENCE stock_id
//  START WITH 1
//  INCREMENT BY 1
//  CACHE 100

//CREATE SEQUENCE customer_id
//  START WITH 1
//  INCREMENT BY 1
//  CACHE 100

//CREATE SEQUENCE shop_id
//  START WITH 1
//  INCREMENT BY 1
//  CACHE 100
//            ";

            a.Insert(sa);
            //b.Insert(sb);
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


