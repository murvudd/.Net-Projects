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

        public static void Run(Pole[,] a)
        {

            MyObject o = new MyObject("" + Thread.CurrentThread.Name, a.GetUpperBound(1), a.GetUpperBound(0));
            Console.WriteLine("Wątek {0} rozpoczyna pracę",
                Thread.CurrentThread.Name, Thread.CurrentThread.Priority);
            o.DrawPole(a);
            
            o.DrawObjct(a);
            
        }
        public static void Run(int j, int i)
        {

            MyObject o = new MyObject("obiek" + Thread.CurrentThread.Name, j, i);
            Console.WriteLine("Wątek {0} rozpoczyna pracę",
                Thread.CurrentThread.Name, Thread.CurrentThread.Priority);


        }

        public void ThreadControl(Pole[,] a, int n0)
        {
           
            Thread[] T = new Thread[n0];
            for (int i = 0; i < T.Length; i++)
            {
                T[i] = new Thread(new ThreadStart( ()=>Run(a)));
                T[i].Name = "" + 1;                
            }

            
        }
       
    }
}
