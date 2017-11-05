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
            for (int j = 1; j <= 6; j++)
            {
                try
                {
                    Stopwatch timer5 = new Stopwatch();
                    Stopwatch timer1 = new Stopwatch();
                    Stopwatch timer2 = new Stopwatch();
                    Stopwatch timer3 = new Stopwatch();
                    Stopwatch timer4 = new Stopwatch();
                    Stopwatch timer6 = new Stopwatch();

                    Random val = new Random();
                    //a.Insert("Create table logs(temp double, czas datetime(6) not null primary key) engine = myisam; ");
                    //a.Insert("");
                    
                    switch (j)
                    {
                        case 1:
                            timer1.Start();
                            for (int i = 0; i < recordNum; i++)
                            {
                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                                                + val.Next(1000000, 10000000) + ", now(6)); do sleep(0.001); ");
                            }
                            timer1.Stop();
                            Console.WriteLine("logs{1} query passed   {0} rows", a.Count("select count(*) from logs" + j), j);
                            break;

                        case 2:
                            timer2.Start();
                            for (int i = 0; i < recordNum; i++)
                            {
                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                                    + val.Next(1000000, 10000000)+");");
                            }
                            timer2.Stop();
                            Console.WriteLine("logs{1} query passed   {0} rows", a.Count("select count(*) from logs" + j), j);
                            break;

                        case 3:
                            timer3.Start();
                            for (int i = 0; i < recordNum; i++)
                            {
                                a.Insert("insert into   lab4.logs" + j + "(temp) Values (" 
                                    + val.Next(1000000, 10000000) + ");");
                            }
                            timer3.Stop();
                            Console.WriteLine("logs{1} query passed   {0} rows", a.Count("select count(*) from logs" + j), j);
                            break;

                        case 4:
                            timer4.Start();
                            for (int i = 0; i < recordNum; i++)
                            {
                                a.Insert("insert into   lab4.logs" + j + "(temp, czas) Values ("
                                                + val.Next(1000000, 10000000) + ", now(6)+0); ");
                            }
                            timer4.Stop();
                            Console.WriteLine("logs{1} query passed   {0} rows", a.Count("select count(*) from logs" + j), j);
                            break;
                        case 5:
                            timer5.Start();
                            for (int i = 0; i < recordNum; i++)
                            {
                                a.Insert("insert into   lab4.logs" + j + "(temp) Values (" 
                                    + val.Next(1000000, 10000000) + ");");
                            }
                            timer5.Stop();
                            Console.WriteLine("logs{1} query passed   {0} rows", a.Count("select count(*) from logs" + j), j);
                            break;

                        case 6:
                            timer6.Start();
                            for (int i = 0; i < recordNum; i++)
                            {
                                a.Insert("insert into   lab4.logs" + j + "(temp) Values ("
                                    + val.Next(1000000, 10000000) + ");");
                            }
                            timer6.Stop();
                            Console.WriteLine("logs{1} query passed   {0} rows", a.Count("select count(*) from logs" + j), j);
                            break;
                    }
                    
                        
                    TimeSpan ts1 = timer1.Elapsed;
                    TimeSpan ts2 = timer2.Elapsed;
                    TimeSpan ts3 = timer3.Elapsed;
                    TimeSpan ts4 = timer4.Elapsed;
                    TimeSpan ts5 = timer5.Elapsed;
                    TimeSpan ts6 = timer6.Elapsed;
                    Console.WriteLine("czas1 {0}\nczas2 {1}\nczas3 {2}\nczas4 {3}\nczas5 {4}\nczas6 {5}",ts1,ts2,ts3,ts4,ts5,ts6);

                }

                catch (Exception e)
                {

                    Console.WriteLine("There was a problem in logs" + j + ":");
                    Console.WriteLine(e.Message);
                    
                    Console.ReadKey();
                }
            }
        }
    }
}
