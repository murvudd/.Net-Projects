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

        public void Run()
        {

            MyObject a = new MyObject("obiek" + Thread.CurrentThread.Name);
            Console.WriteLine("obiekt {0}  x {1},   y {2}", a.Name, a.PosX, a.PosY);

        }
    }
}
