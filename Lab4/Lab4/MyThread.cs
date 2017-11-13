using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{
    class MyThread
    {
        public MyThread()
        {
        }

        public static void Run(int j, int i)
        {

            MyObject o = new MyObject("obiek" + Thread.CurrentThread.Name, j, i);
            Console.WriteLine("Wątek {0} rozpoczyna pracę",
                Thread.CurrentThread.Name, Thread.CurrentThread.Priority);


        }


        public static void Run(Pole[,] a, MyObject o)
        {

            o = new MyObject("" + Thread.CurrentThread.Name, a.GetUpperBound(1), a.GetUpperBound(0));
            //Console.WriteLine("obiekt{0} rozpoczyna prace",o.Name);
            do
            {
                //Program.sem.WaitOne();
                //Console.WriteLine("tekst ze srodka wątku {0}", o.Name);
                
                o.DrawPole(a);                
                o.DrawObjct(a);
                
                //Thread.Sleep(10);
               // Program.sem.Release();
                if (o.PosX==0 || o.PosX==a.GetUpperBound(1) || o.PosY== 0 || o.PosY==a.GetUpperBound(0)) break;
            }
            while (true);//(!((o.PosX != 0 || o.PosX != a.GetUpperBound(1)) && (o.PosY !=0 || o.PosY != a.GetUpperBound(0))));
        }
      
        public static void ThreadControl(Pole[,] a, int n0, Thread[] T, MyObject[] O)
        {
            Console.WriteLine("n0 z Tc {0}      {1}     {2}", n0, T.Length, O.Length); ;
            for (int i = 0; i < n0; i++)
            {
                MyObject o = O[i];
                T[i] = new Thread(new ThreadStart(() => Run(a, o)))
                {
                    Name = "" + i
                };
               // Console.WriteLine("stan wątku {1}   {0}    {2}", T[i].ThreadState, T[i].Name, i);
            }
            for (int i=0; i<n0 ;i++) {
                T[i].Start();
                //Console.WriteLine("stan wątku {1}   {0}    {2}",T[i].ThreadState,T[i].Name,i);
            }

            do
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Program.DrawMap(a);

                for (int i  = 0; i < T.Length-1; i++)
                {
                    for (int j=0; j<i;j++)
                    {
                        if (i != j)
                        {
                            if (O[i].PosX != O[j].PosX && O[i].PosY != O[j].PosY)
                            {

                            }
                        }
                    }
                }

                foreach (Thread t in T)
                {
                    
                    
                    O[Convert.ToInt32(t.Name)].ChangeVel(a);
                    
                }
            } while (Alivecheck(T));
            
        }
       

        static bool Alivecheck(Thread[] T)
        {
            bool AreDone = false;
            foreach(Thread t in T)
            {
                if (t.IsAlive)
                {
                    AreDone = true;
                    break;
                }

            }

            return AreDone;
        }
    }
}
