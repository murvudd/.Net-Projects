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

            Console.OutputEncoding = System.Text.Encoding.GetEncoding("utf-16");
            Console.CursorVisible = false;


            //int n1 = 20; // wymiary planszy (indeksowany od 0  !! )
            Console.WriteLine("wymiar X 20");
            int nx= Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("wymiar Y 20");
            int ny = Convert.ToInt16(Console.ReadLine());

            Random rng = new Random();
            
             
            //int n0 = int.Parse(Console.ReadLine());
            int n0 = 15;
            try
            {
                Pole[,] Mapa = new Pole[ny, nx];              
                Console.WriteLine("Generowanie mapy proszę czekać");
                MapGen(Mapa);

                Console.WriteLine("gotowe, wcisnij dowolny klawisz aby rozpocząć");
                Console.ReadKey();
                Console.Clear();
                //MyThread MyThreadObj = new MyThread();
                //Thread Tcontrol = new Thread(new ThreadStart(MyThread.ThreadControl(()=>Print("s"))));
                Thread[] T = new Thread[n0];
                MyObject[] O = new MyObject[n0];


                Thread Tcontrol = new Thread(new ThreadStart(
                    () => MyThread.ThreadControl(Mapa, n0, T, O)))
                {
                   //Priority = ThreadPriority.Highest
                };
                //Tcontrol.Start(Mapa);
                Tcontrol.Start();                
                
            //do
            //{
            //        Console.Clear();
            //        Console.SetCursorPosition(0, 0);
                  //  DrawMap(Mapa);
            //        foreach (MyObject q in O)
            //        {
            //            //q.DrawObjct(Mapa);
            //            //Thread.Sleep(1500);
            //            //Console.CursorVisible = false;
                        
            //            q.DrawPole(Mapa);
            //            q.ChangeVel(Mapa);
            //            q.DrawObjct(Mapa);
            //            Thread.Sleep(250);
            //        }
            //}
            //while (true);

            }
            catch (Exception e) { Console.Write(e.Message); throw; }

        }

        static public Semaphore sem = new Semaphore(1, 1);


        //static public void DrawArr(Pole[,] a)
        //{
        //    Console.Clear();
        //    for (int j = 0; j <= a.GetUpperBound(0); j++)
        //    {
        //        for (int i = 0; i <= a.GetUpperBound(1); i++)
        //        {
        //            a[j, i].View = (char)a[j, i].Dir;
        //        }
        //    }
        //}

        //static public void DrawSpace(Pole[,] a)
        //{
        //    Console.Clear();
        //    for (int j = 1; j <= a.GetUpperBound(0) - 1; j++)
        //    {
        //        for (int i = 1; i <= a.GetUpperBound(1) - 1; i++)
        //        {
        //            a[j, i].View = ' ';
        //        }
        //    }
        //}

        static void MapGen(Pole[,] Mapa)
        {
            for (int j = 0; j <= Mapa.GetUpperBound(0); j++)
            {
                for (int i = 0; i <= Mapa.GetUpperBound(1); i++)
                {
                    if (j == 0 || j == Mapa.GetUpperBound(0) || i == 0 || i == Mapa.GetUpperBound(1))
                    {
                        Mapa[j, i] = new Pole(88, i, j); // 88 to char 'X' w utf16

                    }

                    else
                    {
                        Mapa[j, i] = new Pole(i, j);
                        Thread.Sleep(30);

                    }
                }

            }
        }

        static void MapGen(Pole[,] Mapa, int q)
        {
            for (int j = 0; j <= Mapa.GetUpperBound(0); j++)
            {
                for (int i = 0; i <= Mapa.GetUpperBound(1); i++)
                {
                    if (j == 0 || j == Mapa.GetUpperBound(0) || i == 0 || i == Mapa.GetUpperBound(1))
                    {
                        Mapa[j, i] = new Pole(88, i, j); // 88 to char 'X' w utf16

                    }

                    else
                    {
                        Mapa[j, i] = new Pole(q, i, j);
                        Thread.Sleep(3);

                    }
                }

            }
        }



        public static void DrawMap(Pole[,] a)
        {
            
            Console.SetCursorPosition(0, 0);
            for (int j = 0; j <= a.GetUpperBound(0); j++)
            {
                for (int i = 0; i <= a.GetUpperBound(1); i++)
                {
                    Console.Write("{0}", (char)a[j, i].Dir);
                }
                Console.Write("\n");
            }
        }

    }
}


//Obkt[] obiekty = new Obkt[n0];
//for (int i = 0; i < n0; i++)
//{
//    obiekty[i] = new Obkt("" + i);
//    Thread.Sleep(1);
//}
//Wtk MyThreadClass = new Wtk();
//Thread[] threads = new Thread[n0];
//for(int i = 0; i < n0; i++)
//{
//    threads[i] = new Thread(new ThreadStart(MyThreadClass.Run));
//    Thread.Sleep(100);
//    threads[i].Name = "t_"+i;
//    threads[i].Start();

//}
