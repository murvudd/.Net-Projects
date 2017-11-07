using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Liczba Obiektów");
            int n0 = int.Parse(Console.ReadLine());
            Console.WriteLine("Wymiary planszy");
            int n1 = int.Parse(Console.ReadLine());

            //Obkt[] obiekty = new Obkt[n0];
            //for (int i = 0; i < n0; i++)
            //{
            //    obiekty[i] = new Obkt("" + i);
            //    Thread.Sleep(1);
            //}
            Wtk MyThreadClass = new Wtk();
            Thread[] threads = new Thread[n0];
            for(int i = 0; i < n0; i++)
            {
                threads[i] = new Thread(new ThreadStart(MyThreadClass.Run));
                Thread.Sleep(100);
                threads[i].Name = "t_"+i;
                threads[i].Start();
                
            }


            Plansza.Populate();

            Console.WriteLine(Plansza.Map[1, 1]);
            
            //int x = 0;
            //do
            //{

            //    Plansza.DrawBox(n1, n1);
            //    x++;
            //} while (x<10);
        }
    }
}