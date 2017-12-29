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


        }
        static int IleWystąpień(List<Atrybut> ListaA)
        {
            int i = 0;

            return i;
        }

        static void ReadPlik(List<Atrybut> ListaA)
        {
            string[] plik = File.ReadAllLines("C:\\Users\\Żaba\\Desktop\\plik1.txt");
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
