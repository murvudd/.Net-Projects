using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace test2.Models
{
    class Perceptron
    {
        //protected double[] Inputs { get; set; }
        public double[] Inputs { get; set; }
        //protected double[] Weights { get; set; }
        public double[,] Weights { get; set; }

        public Perceptron(double[] inp)
        {
            var rng = new Random();
            Inputs = inp;
            var W = new double[inp.Count()];
            for (int i = 0; i < inp.Count(); i++)
            {
                W[i] = rng.Next(-1000, 1001) * 0.001;
                Thread.Sleep(1);
            }
            Weights = W;
        }

        public void Print()
        {
            int i = 0;
            foreach (var item in this.Inputs)
            {
                i += 1;
                Console.WriteLine("input no. {0} is {1} with weight {2} ", i, item, this.Weights[i - 1]);
            }
        }

        public int Guess() 
        {
            double sum = 0;
            for (int i = 0; i < Inputs.Count(); i++)
            {
                sum += Inputs[i] * Weights[i][i];
            }
            return Math.Sign(sum);
        }

    }
}