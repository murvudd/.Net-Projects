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
