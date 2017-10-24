﻿using System;
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
            for (int j = 1; j <= 6; j++)
            {
                try
                {
                    Stopwatch timer = new Stopwatch();
                    Random val = new Random();
                    //a.Insert("Create table logs(temp double, czas datetime(6) not null primary key) engine = myisam; ");
                    //a.Insert("");
                    timer.Start();
                    for (int i = 0; i < 1000; i++)
                    {
                        a.Insert("insert into   lab4.logs"+j+"(temp, czas) Values (" 
                                            + val.Next(0, 10000000) + ", now(6)); ");
                    }
                    timer.Stop();
                    TimeSpan ts = timer.Elapsed;
                    Console.WriteLine("logs{1} query passed   {0} rows       {2} time", a.Count("select count(*) from logs"+j),j,ts);
                    
                }

                catch (Exception e)
                {
                    
                    Console.WriteLine("There was a problem in logs"+ j +":");
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }

        }
    }
}