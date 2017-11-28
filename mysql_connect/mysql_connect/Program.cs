using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mysql_connect.Models;
using System.Diagnostics;

namespace mysql_connect
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnect a = new DBConnect();
            Console.WriteLine(a.Count("select connection_id();"));
            Console.WriteLine("ile rekordów ?");
            
            int recordNum = int.Parse(Console.ReadLine());
            //Stopwatch timer5 = new Stopwatch();
            Stopwatch timer1 = new Stopwatch();
            //Stopwatch timer2 = new Stopwatch();
            //Stopwatch timer3 = new Stopwatch();
            //Stopwatch timer4 = new Stopwatch();
            //Stopwatch timer6 = new Stopwatch();
            Random rng = new Random();

            {
                /*
                //for (int k = 0; k < 5; k++)
                //{
                //    switch (k)
                //    {
                //        case 0:
                //            for (int j = 1; j <= 6; j++)
                //            {
                //                try
                //                {


                //                    Random rng = new Random();
                //                    //a.Insert("Create table logs(temp double, czas datetime(6) not null primary key) engine = myisam; ");
                //                    //a.Insert("");

                //                    switch (j)
                //                    {
                //                        case 1:

                //                            a.Insert("drop table if exists logs1");
                //                            a.Insert("Create table logs1(temp double,czas datetime(6) not null primary key) engine = myisam; ");
                //                            timer1.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                //                                                + rng.Next(1000000, 10000000) + ", now(6));  ");
                //                            }
                //                            timer1.Stop();
                //                            TimeSpan ts1 = timer1.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts1);
                //                            timer1.Reset();
                //                            break;

                //                        case 2:
                //                            a.Insert("drop table if exists logs2; Create table logs2(temp double,czas int not null primary key auto_increment) engine = myisam; ");
                //                            timer2.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer2.Stop();
                //                            TimeSpan ts2 = timer2.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts2);
                //                            timer2.Reset();
                //                            break;

                //                        case 3:
                //                            a.Insert("drop table if exists logs3; Create table logs3(temp double,czas int not null auto_increment unique) engine = myisam; ");
                //                            timer3.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer3.Stop();
                //                            TimeSpan ts3 = timer3.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts3);
                //                            timer3.Reset();
                //                            break;

                //                        case 4:
                //                            a.Insert("drop table if exists logs4; Create table logs4(temp double,czas datetime(6) not null primary key) engine = innodb;");
                //                            timer4.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                //                                                + rng.Next(1000000, 10000000) + ", now(6)+0);  ");
                //                            }
                //                            timer4.Stop();
                //                            TimeSpan ts4 = timer4.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts4);
                //                            timer4.Reset();
                //                            break;
                //                        case 5:
                //                            a.Insert("drop table if exists logs5; Create table logs5(temp double,czas int not null primary key auto_increment) engine = innodb; ");
                //                            timer5.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer5.Stop();
                //                            TimeSpan ts5 = timer5.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts5);
                //                            timer5.Reset();
                //                            break;

                //                        case 6:
                //                            a.Insert("drop table if exists logs6; Create table logs6(temp double,czas int not null auto_increment unique) engine = innodb; ");
                //                            timer6.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer6.Stop();
                //                            TimeSpan ts6 = timer6.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts6);
                //                            timer6.Reset();
                //                            break;



                //                    }





                //                }

                //                catch (Exception e)
                //                {

                //                    Console.WriteLine("There was a problem in logs" + j + ":");
                //                    Console.WriteLine(e.Message);

                //                    Console.ReadKey();
                //                }
                //            }
                //            break;

                //        case 1:
                //            a.Insert("Set Global Transaction isolation level repeatable read;");
                //            Console.Write("Repetable read\n\n\n");
                //            for (int j = 1; j <= 6; j++)
                //            {
                //                try
                //                {


                //                    Random rng = new Random();
                //                    //a.Insert("Create table logs(temp double, czas datetime(6) not null primary key) engine = myisam; ");
                //                    //a.Insert("");

                //                    switch (j)
                //                    {
                //                        case 1:

                //                            a.Insert("drop table if exists logs1");
                //                            a.Insert("Create table logs1(temp double,czas datetime(6) not null primary key) engine = myisam; ");
                //                            timer1.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                //                                                + rng.Next(1000000, 10000000) + ", now(6));  ");
                //                            }
                //                            timer1.Stop();
                //                            TimeSpan ts1 = timer1.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts1);

                //                            timer1.Reset();
                //                            break;

                //                        case 2:
                //                            a.Insert("drop table if exists logs2; Create table logs2(temp double,czas int not null primary key auto_increment) engine = myisam; ");
                //                            timer2.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer2.Stop();
                //                            TimeSpan ts2 = timer2.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts2);

                //                            timer2.Reset(); break;

                //                        case 3:
                //                            a.Insert("drop table if exists logs3; Create table logs3(temp double,czas int not null auto_increment unique) engine = myisam; ");
                //                            timer3.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer3.Stop();
                //                            TimeSpan ts3 = timer3.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts3);
                //                            timer3.Reset(); break;

                //                        case 4:
                //                            a.Insert("drop table if exists logs4; Create table logs4(temp double,czas datetime(6) not null primary key) engine = innodb;");
                //                            timer4.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                //                                                + rng.Next(1000000, 10000000) + ", now(6)+0);  ");
                //                            }
                //                            timer4.Stop();
                //                            TimeSpan ts4 = timer4.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts4);
                //                            timer4.Reset(); break;
                //                        case 5:
                //                            a.Insert("drop table if exists logs5; Create table logs5(temp double,czas int not null primary key auto_increment) engine = innodb; ");
                //                            timer5.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer5.Stop();
                //                            TimeSpan ts5 = timer5.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts5);
                //                            timer5.Reset(); break;

                //                        case 6:
                //                            a.Insert("drop table if exists logs6; Create table logs6(temp double,czas int not null auto_increment unique) engine = innodb; ");
                //                            timer6.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer6.Stop();
                //                            TimeSpan ts6 = timer6.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts6);
                //                            timer6.Reset(); break;



                //                    }





                //                }

                //                catch (Exception e)
                //                {

                //                    Console.WriteLine("There was a problem in logs" + j + ":");
                //                    Console.WriteLine(e.Message);

                //                    Console.ReadKey();
                //                }
                //            }
                //            break;

                //        case 2:
                //            a.Insert("Set Global Transaction isolation level READ committed;");
                //            Console.Write("Read committed\n\n\n");
                //            for (int j = 1; j <= 6; j++)
                //            {
                //                try
                //                {


                //                    Random rng = new Random();
                //                    //a.Insert("Create table logs(temp double, czas datetime(6) not null primary key) engine = myisam; ");
                //                    //a.Insert("");

                //                    switch (j)
                //                    {
                //                        case 1:

                //                            a.Insert("drop table if exists logs1");
                //                            a.Insert("Create table logs1(temp double,czas datetime(6) not null primary key) engine = myisam; ");
                //                            timer1.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                //                                                + rng.Next(1000000, 10000000) + ", now(6));  ");
                //                            }
                //                            timer1.Stop();
                //                            TimeSpan ts1 = timer1.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts1);

                //                            timer1.Reset(); break;

                //                        case 2:
                //                            a.Insert("drop table if exists logs2; Create table logs2(temp double,czas int not null primary key auto_increment) engine = myisam; ");
                //                            timer2.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer2.Stop();
                //                            TimeSpan ts2 = timer2.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts2);
                //                            timer2.Reset(); break;

                //                        case 3:
                //                            a.Insert("drop table if exists logs3; Create table logs3(temp double,czas int not null auto_increment unique) engine = myisam; ");
                //                            timer3.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer3.Stop();
                //                            TimeSpan ts3 = timer3.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts3);
                //                            timer3.Reset(); break;

                //                        case 4:
                //                            a.Insert("drop table if exists logs4; Create table logs4(temp double,czas datetime(6) not null primary key) engine = innodb;");
                //                            timer4.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                //                                                + rng.Next(1000000, 10000000) + ", now(6)+0);  ");
                //                            }
                //                            timer4.Stop();
                //                            TimeSpan ts4 = timer4.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts4);
                //                            timer4.Reset(); break;
                //                        case 5:
                //                            a.Insert("drop table if exists logs5; Create table logs5(temp double,czas int not null primary key auto_increment) engine = innodb; ");
                //                            timer5.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer5.Stop();
                //                            TimeSpan ts5 = timer5.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts5);
                //                            timer5.Reset(); break;

                //                        case 6:
                //                            a.Insert("drop table if exists logs6; Create table logs6(temp double,czas int not null auto_increment unique) engine = innodb; ");
                //                            timer6.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer6.Stop();
                //                            TimeSpan ts6 = timer6.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts6);
                //                            timer6.Reset(); break;



                //                    }





                //                }

                //                catch (Exception e)
                //                {

                //                    Console.WriteLine("There was a problem in logs" + j + ":");
                //                    Console.WriteLine(e.Message);

                //                    Console.ReadKey();
                //                }
                //            }
                //            break;

                //        case 3:
                //            a.Insert("Set Global Transaction isolation level READ uncommitted;");
                //            Console.Write("Read uncommitted\n\n\n");
                //            for (int j = 1; j <= 6; j++)
                //            {
                //                try
                //                {


                //                    Random rng = new Random();
                //                    //a.Insert("Create table logs(temp double, czas datetime(6) not null primary key) engine = myisam; ");
                //                    //a.Insert("");

                //                    switch (j)
                //                    {
                //                        case 1:

                //                            a.Insert("drop table if exists logs1");
                //                            a.Insert("Create table logs1(temp double,czas datetime(6) not null primary key) engine = myisam; ");
                //                            timer1.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                //                                                + rng.Next(1000000, 10000000) + ", now(6));  ");
                //                            }
                //                            timer1.Stop();
                //                            TimeSpan ts1 = timer1.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts1);

                //                            timer1.Reset(); break;

                //                        case 2:
                //                            a.Insert("drop table if exists logs2; Create table logs2(temp double,czas int not null primary key auto_increment) engine = myisam; ");
                //                            timer2.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer2.Stop();
                //                            TimeSpan ts2 = timer2.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts2);
                //                            timer2.Reset(); break;

                //                        case 3:
                //                            a.Insert("drop table if exists logs3; Create table logs3(temp double,czas int not null auto_increment unique) engine = myisam; ");
                //                            timer3.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer3.Stop();
                //                            TimeSpan ts3 = timer3.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts3);
                //                            timer3.Reset(); break;

                //                        case 4:
                //                            a.Insert("drop table if exists logs4; Create table logs4(temp double,czas datetime(6) not null primary key) engine = innodb;");
                //                            timer4.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                //                                                + rng.Next(1000000, 10000000) + ", now(6)+0);  ");
                //                            }
                //                            timer4.Stop();
                //                            TimeSpan ts4 = timer4.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts4);
                //                            timer4.Reset(); break;
                //                        case 5:
                //                            a.Insert("drop table if exists logs5; Create table logs5(temp double,czas int not null primary key auto_increment) engine = innodb; ");
                //                            timer5.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer5.Stop();
                //                            TimeSpan ts5 = timer5.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts5);
                //                            timer5.Reset(); break;

                //                        case 6:
                //                            a.Insert("drop table if exists logs6; Create table logs6(temp double,czas int not null auto_increment unique) engine = innodb; ");
                //                            timer6.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer6.Stop();
                //                            TimeSpan ts6 = timer6.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts6);
                //                            timer6.Reset(); break;



                //                    }





                //                }

                //                catch (Exception e)
                //                {

                //                    Console.WriteLine("There was a problem in logs" + j + ":");
                //                    Console.WriteLine(e.Message);

                //                    Console.ReadKey();
                //                }
                //            }
                //            break;

                //        case 4:
                //            Console.Write("SERIALIZABLE\n\n\n");
                //            a.Insert("Set Global Transaction isolation level SERIALIZABLE;");
                //            for (int j = 1; j <= 6; j++)
                //            {
                //                try
                //                {


                //                    Random rng = new Random();
                //                    //a.Insert("Create table logs(temp double, czas datetime(6) not null primary key) engine = myisam; ");
                //                    //a.Insert("");

                //                    switch (j)
                //                    {
                //                        case 1:

                //                            a.Insert("drop table if exists logs1");
                //                            a.Insert("Create table logs1(temp double,czas datetime(6) not null primary key) engine = myisam; ");
                //                            timer1.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                //                                                + rng.Next(1000000, 10000000) + ", now(6));  ");
                //                            }
                //                            timer1.Stop();
                //                            TimeSpan ts1 = timer1.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts1);

                //                            timer1.Reset(); break;

                //                        case 2:
                //                            a.Insert("drop table if exists logs2; Create table logs2(temp double,czas int not null primary key auto_increment) engine = myisam; ");
                //                            timer2.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer2.Stop();
                //                            TimeSpan ts2 = timer2.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts2);
                //                            timer2.Reset(); break;

                //                        case 3:
                //                            a.Insert("drop table if exists logs3; Create table logs3(temp double,czas int not null auto_increment unique) engine = myisam; ");
                //                            timer3.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer3.Stop();
                //                            TimeSpan ts3 = timer3.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts3);
                //                            timer3.Reset(); break;

                //                        case 4:
                //                            a.Insert("drop table if exists logs4; Create table logs4(temp double,czas datetime(6) not null primary key) engine = innodb;");
                //                            timer4.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                //                                                + rng.Next(1000000, 10000000) + ", now(6)+0);  ");
                //                            }
                //                            timer4.Stop();
                //                            TimeSpan ts4 = timer4.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts4);
                //                            timer4.Reset(); break;
                //                        case 5:
                //                            a.Insert("drop table if exists logs5; Create table logs5(temp double,czas int not null primary key auto_increment) engine = innodb; ");
                //                            timer5.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer5.Stop();
                //                            TimeSpan ts5 = timer5.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts5);
                //                            timer5.Reset(); break;

                //                        case 6:
                //                            a.Insert("drop table if exists logs6; Create table logs6(temp double,czas int not null auto_increment unique) engine = innodb; ");
                //                            timer6.Start();
                //                            for (int i = 0; i < recordNum; i++)
                //                            {
                //                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                //                                    + rng.Next(1000000, 10000000) + ");");
                //                            }
                //                            timer6.Stop();
                //                            TimeSpan ts6 = timer6.Elapsed;
                //                            Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts6);
                //                            timer6.Reset(); break;



                //                    }





                //                }

                //                catch (Exception e)
                //                {

                //                    Console.WriteLine("There was a problem in logs" + j + ":");
                //                    Console.WriteLine(e.Message);

                //                    Console.ReadKey();
                //                }
                //            }
                //            break;

                //    }
                //}
                */
            }

            a.Insert("Set Global Transaction isolation level repeatable read;");
            Console.WriteLine("\n\nRepeatable Read");
            Run(a,timer1,rng,recordNum);
            

            a.Insert("Set Global Transaction isolation level READ committed;");
            Console.WriteLine("\n\nRead Commited");
            Run(a, timer1, rng, recordNum);

            a.Insert("Set Global Transaction isolation level READ uncommitted;");
            Console.WriteLine("\n\nRead Uncommited");
            Run(a, timer1, rng, recordNum);

            a.Insert("Set Global Transaction isolation level SERIALIZABLE;");
            Console.WriteLine("\n\nSerializable");
            Run(a, timer1, rng, recordNum);
        }


        static void Run(DBConnect a, Stopwatch t,Random rng, int recordNum)
        {
            for (int j =1;j<=6;j++) {
                a.Insert("drop table if exists logs" + j);
                if (j == 1) a.Insert("Create table logs1(temp double,czas datetime(6) not null ) engine = myisam; ");
                if (j == 2) a.Insert("Create table logs2(temp double,czas int not null primary key auto_increment) engine = myisam; ");
                if (j == 3) a.Insert("Create table logs3(temp double,czas int not null auto_increment unique) engine = myisam; ");
                if (j == 4) a.Insert("Create table logs4(temp double,czas datetime(6) not null ) engine = innodb;");
                if (j == 5) a.Insert("Create table logs5(temp double,czas int not null primary key auto_increment) engine = innodb; ");
                if (j == 6) a.Insert("drop table if exists logs6; Create table logs6(temp double,czas int not null auto_increment unique) engine = innodb; ");
                


                t.Start();
                for (int i = 0; i < recordNum; i++)
                {
                    if (j == 1) a.Insert("insert into   logs" + j + "(temp, czas) Values (" + rng.Next(1000000, 10000000) + ", now(6));  ");
                    if (j == 2) a.Insert("insert into   logs" + j + "(temp) Values (" + rng.Next(1000000, 10000000) + ");");
                    if (j == 3) a.Insert("insert into  logs" + j + "(temp) Values (" + rng.Next(1000000, 10000000) + ");");
                    if (j == 4) a.Insert("insert into   logs" + j + "(temp, czas) Values (" + rng.Next(1000000, 10000000) + ", now(6)+0);  ");
                    if (j == 5) a.Insert("insert into   logs" + j + "(temp) Values (" + rng.Next(1000000, 10000000) + ");");
                    if (j == 6) a.Insert("insert into   logs" + j + "(temp) Values (" + rng.Next(1000000, 10000000) + ");");
                }
                t.Stop();
                TimeSpan ts1 = t.Elapsed;
                Console.WriteLine("logs{1} query passed   {0} rows   time{2}", a.Count("select count(*) from logs" + j), j, ts1);

                t.Reset();
            }
        }

    }
}
