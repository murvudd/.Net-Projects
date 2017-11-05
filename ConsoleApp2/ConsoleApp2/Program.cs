using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            Publikacja a = new Publikacja("aa", "bb ", 1984);
            Książka b = new Książka(100, "cc", "dd", 1111);
            Film c = new Film(50, "DVD", "ddd", "vvv", 996);
            Tygodnik d = new Tygodnik(10, "aa", "bb", 655);


            Console.WriteLine("{0}    {1}", d.Numer, d.ID);
            Console.ReadKey();


            ////int i = 0;
            //char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();

            //Random rng = new Random();
            //     rng.Next(1, 25);

        }
    }
}
