using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odb
{
    class Program
    {
        static void Main(string[] args)
        {
            MyConnect a = new MyConnect();
            try
            {
            a.Insert("");

            }
            catch (Exception)
            {

                throw;
            }


        }

        public static string RNGCity()
        {
            string s;
            Random rng = new Random();

            switch (rng.Next(0,10))
            {
                case 0:
                    s = "Warszawa";
                    break;

                case 1:
                    s = "Kraków";
                    break;

                case 2:
                    s = "Łódź";
                    break;

                case 3:
                    s = "Wrocław";
                    break;

                case 4:
                    s = "Poznań";
                    break;

                case 5:
                    s = "Gdańsk";
                    break;

                case 6:
                    s = "Szczecin";
                    break;

                case 7:
                    s = "Bydgoszcz";
                    break;

                case 8:
                    s = "Lublin";
                    break;

                case 9:
                    s = "Katowice";
                    break;

                default:
                    s = "Internet";
                    break;
            }
            return s;
            
        }


    }
}
