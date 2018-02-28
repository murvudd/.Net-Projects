using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test2.Models;

namespace NNtest2
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = new Perceptron(new double[] { });
            var b = new Perceptron(new double[] { 1, 2, 3 });
            var c = new Perceptron(new double[] { 2, 3, 4, 5 });
            var d = new Perceptron(new double[] { 3, 4, 5, 6, 7 });

            d.Print();

            Console.WriteLine(d.Guess());


            Console.ReadLine();
        }
    }
}