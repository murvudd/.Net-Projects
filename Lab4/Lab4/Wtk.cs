using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{
    class Wtk
    {
        public Wtk()
            {
            }

        public void Run()
        {
            
            Obkt a = new Obkt("obiek"+Thread.CurrentThread.Name);
            Console.WriteLine("obiekt {0}  x {1},   y {2}", a.Name, a.PosX, a.PosY);

        }
    }
}
