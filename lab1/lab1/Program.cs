using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
                

                // Wczytuje cały plik
                
                string[] plik = File.ReadAllLines("i500.ppm");
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                string[] dimString = plik[1].Split(delimiterChars);
                int i = 0;
                int[] dim = new int[2];
                foreach (var d in dimString)
                { 
                    int dimInt = Int32.Parse(d);
                    dim[i] = dimInt;
                    i += 0; 
                }
                dim[1] = dim[0];
                i = 0;
                //string[,] a = new string[dim[0],dim[1]];
                //Console.WriteLine("1={0},   2={1}", a[0, 0], a[1, 1]);

                string[]a = new string[plik.GetLength(0)];

                //int[][] b = new int[dim[0]][];

                //int[][] R = new int[dim[0]][];
                //int[][] G = new int[dim[0]][];
                //int[][] B = new int[dim[0]][];
                

                int[,] R = new int[dim[0],dim[1]];
                int[,] G = new int[dim[0], dim[1]];
                int[,] B = new int[dim[0], dim[1]];

              




            for (int j = 0; j < dim[0]; j++)
                {
                    i = 0;
                    string[] words = plik[j + 3].Split(delimiterChars);
                    for (int k = 0; k < words.Length; k += 3)
                    {
                        R[j,i] = int.Parse(words[k]);
                        G[j,i] = int.Parse(words[k + 1]);
                        B[j,i] = int.Parse(words[k + 2]);
                        i += 1;
                    }
                    //a[j] = words;
                    // Console.WriteLine("{0}, {1}, {2}, rozmiar {3}x{4}", R[0, j], G[0, j], B[0, j], R.GetLength(0), R.GetLength(1));
                    //Console.ReadKey();
                }
                i = 0;

            //// Negacja R
            //for (int j = 0; j < R.GetLength(0); j++)
            //{
            //    for (int k = 0; k < R.GetLength(1); k++)
            //    {
            //        R[k, j] = 255 - R[k, j];
            //    }

            //}

            //Console.WriteLine("Negacja R");


            //Negacja G
            for (int j = 0; j < G.GetLength(0); j++)
            {
                for (int k = 0; k < G.GetLength(1); k++)
                {
                    G[k, j] = 255 - G[k, j];
                }
            }
            Console.WriteLine("Negacja G");

            //// Negacja B
            //for (int j = 0; j < B.GetLength(0); j++)
            //{
            //    for (int k = 0; k < B.GetLength(1); k++)
            //    {
            //        B[k, j] = 255 - B[k, j];
            //    }
            //}
            //Console.WriteLine("Negacja B");

            //// R = 0
            //for (int j = 0; j < R.GetLength(0); j++)
            //{
            //    for (int k = 0; k < R.GetLength(1); k++)
            //    {
            //        R[k, j] = 0;
            //    }

            //}

            //Console.WriteLine("R = 0");

            //// G = 0
            //for (int j = 0; j < G.GetLength(0); j++)
            //{
            //    for (int k = 0; k < G.GetLength(1); k++)
            //    {
            //        G[k, j] = 0;
            //    }

            //}

            //Console.WriteLine("G = 0");

            //// B = 0
            //for (int j = 0; j < B.GetLength(0); j++)
            //{
            //    for (int k = 0; k < B.GetLength(1); k++)
            //    {
            //        B[k, j] = 0;
            //    }

            //}

            //Console.WriteLine("B = 0");


            //// odcienie szarości
            //int[,] Rnew = new int[dim[0], dim[1]];
            //int[,] Gnew = new int[dim[0], dim[1]];
            //int[,] Bnew = new int[dim[0], dim[1]];
            //for (int j = 0; j < R.GetLength(0); j++)
            //{
            //    for (int k = 0; k < R.GetLength(1); k++)
            //    {
            //        Rnew[k, j] = (R[k,j] + G[k,j] + B[k,j])/3;
            //    }

            //}
            //for (int j = 0; j < R.GetLength(0); j++)
            //{
            //    for (int k = 0; k < R.GetLength(1); k++)
            //    {
            //        Gnew[k, j] = (R[k, j] + G[k, j] + B[k, j]) / 3;
            //    }

            //}
            //for (int j = 0; j < R.GetLength(0); j++)
            //{
            //    for (int k = 0; k < R.GetLength(1); k++)
            //    {
            //        Bnew[k, j] = (R[k, j] + G[k, j] + B[k, j]) / 3;
            //    }

            //}
            //R = Rnew;
            //G = Gnew;
            //B = Bnew;
            //Console.WriteLine("Odcienie szarości");

            // obrót
            int[,] Rnew = new int[dim[0], dim[1]];
            int[,] Gnew = new int[dim[0], dim[1]];
            int[,] Bnew = new int[dim[0], dim[1]];
            for (int j = 0; j < R.GetLength(0); j++)
            {
                for (int k = 0; k < R.GetLength(1); k++)
                {
                    Rnew[k, j] = R[j, k] ;
                }

            }
            for (int j = 0; j < R.GetLength(0); j++)
            {
                for (int k = 0; k < R.GetLength(1); k++)
                {
                    Gnew[k, j] = G[j,k];
                }

            }
            for (int j = 0; j < R.GetLength(0); j++)
            {
                for (int k = 0; k < R.GetLength(1); k++)
                {
                    Bnew[k, j] = B[j, k];
                }

            }
            R = Rnew;
            G = Gnew;
            B = Bnew;
            Console.WriteLine("obrót");








            // Zapis do pliku
            i = 0;
            
            

                string[] plika = { plik[0], plik[1], plik[2] };

                File.Delete("File.ppm");
                File.WriteAllLines("File.ppm", plika);
                
                for (int j = 0; j < dim[0]; j++)
                {
                    string c = "";
                    

                    for (int k = 0; k <  dim[0]; k++)
                    {
                        c = R[j, k] + " " + G[j, k] + " " + B[j, k] + " " + c;
                        
                    }

                    a[j] = c;
                }

                
                File.AppendAllLines("File.ppm", a);
                Console.WriteLine("zapisano");
                Console.WriteLine("wszystko ok");
                Console.ReadKey();
                
            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine("nie ok :c ");
            //    Console.WriteLine(e.Message);
            //    Console.ReadKey();
            //}
        }
    }
}














            //try
            //{   // Open the text file using a stream reader.
            //    using (StreamReader sr = new StreamReader("TestFile.txt"))
            //    {
            //        // Read the stream to a string, and write the string to the console.
            //        String line = sr.ReadToEnd();
            //        Console.WriteLine(line);
            //        Console.ReadKey();
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("The file could not be read:");
            //    Console.WriteLine(e.Message);
            //    Console.ReadKey();
            //}

///*
//string[] testarray = new string[10] { "5", "6", "7", "8", "9", "10", "11", "12", "13", "14" };
//int i = 0;
//foreach (string element in testarray)
//{
//    i += 1;
//    Console.WriteLine("Element #{0}: {1}", i, element);

//}


//Console.WriteLine("wszytko ok");
//Console.ReadKey();

//}
//}
//}
