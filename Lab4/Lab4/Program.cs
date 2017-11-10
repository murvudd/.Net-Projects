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

            //int n1 = 20; // wymiary planszy (indeksowany od 0  !! )
            Random rng = new Random();
            //Console.WriteLine("Liczba Obiektów");
            //int n0 = int.Parse(Console.ReadLine());
            int n0 = 10;
            try
            {
                MyObject[] Objects = new MyObject[n0];
                for (int i = 0; i < Objects.Length; i++)
                {
                    Objects[i] = new MyObject("obiekt_" + i);
                }
                Console.Write("Y dim\tX dim\n");
                Pole[,] Mapa = new Pole[int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())];

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
                            Thread.Sleep(3);

                        }
                    }

                }

                Console.OutputEncoding = System.Text.Encoding.GetEncoding("utf-16");
                DrawMap(Mapa);



            }
            catch (Exception e) { Console.Write(e.Message); throw; }

        }

        static void DrawMap(Pole[,] a)
        {
            Console.Clear();
            for (int i = 0; i <= a.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= a.GetUpperBound(1); j++)
                {
                    Console.Write("{0}\0\0", (char)a[i, j].Dir);
                    //Console.Write("i:{0}   j:{1}\n", i, j);
                }
                Console.WriteLine("\n");
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
