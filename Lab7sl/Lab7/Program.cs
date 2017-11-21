using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab7
{
    
    class Program 
    {
        
        static void Main(string[] args)
        {
            Email email = new Email();
            Console.WriteLine(email.Priorytet);
            email.Podnieś(email);
            Console.WriteLine(email.Priorytet);
            List<Case> CaseList = new List<Case>();

            string[] plik = File.ReadAllLines("attacks.csv");
            //char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            for (int i = 1; i < plik.Length; i++)
            {
                string[] b = plik[i].Split(';');
                CaseList.Add(new Case
                {
                    Year = Parse.ToNullableInt(b[2]),
                    Type = b[3],
                    Country = b[4],
                    Area = b[5],
                    Activity = b[7],
                    Name = b[8],
                    Sex = b[9],
                    Age = Parse.ToNullableInt(b[10]),
                    Fatal = b[12]
                });

            }

            WarunkiAtmosferyczne pogoda = new WarunkiAtmosferyczne();
            ZbiornikRetenccyjny zbiornik = new ZbiornikRetenccyjny();
            Elektrownia elektrownia = new Elektrownia();
            Autostrada autostrada = new Autostrada();
            Szpital szpital = new Szpital();
            Lotnisko lotnisko = new Lotnisko();



           
        }
    
    }
    static class Parse
    {
        public static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }
    }
    interface IComparer
    {

    }

    

    interface IDokument<T>
    {
        void Podnieś(T obj);
    }
}
