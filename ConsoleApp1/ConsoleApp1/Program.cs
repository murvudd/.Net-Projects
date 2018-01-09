using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp1
{
    class Parse
    {
        static bool StringToBool(string x)
        {
            if(x == "1") return true;
            
            else return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Branch> ListaOpcji = new List<Branch>();
            List<Atrybut> ListaA = new List<Atrybut>();
            ReadPlik(ListaA);
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t", ListaA[0].a, ListaA[0].b, ListaA[0].c, ListaA[0].d, ListaA[0].e, ListaA[0].f);
            
            Console.ReadKey();
        }
        //static int IleWystąpień(List<Atrybut> ListaA, int sw, string x)
        //{
        //    int i = 0;
        //    switch (sw)
        //    {
        //        case 1:
        //            for (int j = 0; j<8; j++)
        //            {
        //                if (ListaA[j].a == x) i++;
        //            }
        //            break;
        //        case 2:
        //            for (int j = 0; j<8; j++)
        //            {
        //                if (ListaA[j].b == x) i++;
        //            }
        //            break;
        //        case 3:
        //            for (int j = 0; j<8; j++)
        //            {
        //                if (ListaA[j].c == x) i++;
        //            }
        //            break;
        //        case 4:
        //            for (int j = 0; j<8; j++)
        //            {
        //                if (ListaA[j].d == x) i++;
        //            }
        //            break;
        //        case 5:
        //            for (int j = 0; j<8; j++)
        //            {
        //                if (ListaA[j].e == x) i++;
        //            }
        //            break;
        //    }

        //    return i;
        //}

        static double Entropia(List<Atrybut> ListaA)
        {
            double v = 0;
            //v=Math.Log(,2);
            return v;
        }

        static void ReadPlik(List<Atrybut> ListaA)
        {
            string[] plik = File.ReadAllLines("plik1.txt");
            for (int i = 0; i < plik.Length; i++)
            {
                string[] line = plik[i].Split(' ');
                ListaA.Add(new Atrybut
                {
                    a = line[0],
                    b = line[1],
                    c = line[2],
                    d = line[3],
                    e = line[4],
                    f = line[5],
                });
            }

        }
    }
}
