using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Lab7
{
    
    class Program 
    {
        
        static void Main(string[] args)
        {
            Random rng = new Random();
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
            pogoda.IntensywneOpadyŚniegu += autostrada.WyślijPługi;
            

            pogoda.IntensywneOpadyDeszczu += zbiornik.ZmniejszIlośćWody;
            pogoda.SilnyWiatr += lotnisko.Close;
            
            pogoda.Upał += elektrownia.WłączZasilanieAwaryjne;
            pogoda.Upał += szpital.WłączZasilanieAwaryjne;
            pogoda.Upał += lotnisko.Close;
            
            for (int i =0; i <100; i++)
            {
                Console.WriteLine("Warunki:");
                Console.WriteLine("opady deszczu: {0} \n" +
                    "opady śniegu: {1} \n" +
                    "temperatura: {2} \n" +
                    "szybkość wiatru: {3}"
                    ,pogoda.OpadyDeszczu,pogoda.OpadyŚniegu, pogoda.Temperatura, pogoda.Wiatr);
                Console.WriteLine("\nStan: ");
                Console.WriteLine("poziom wody zbiornika: {0}",zbiornik.PoziomWody);
                Console.WriteLine("czy tryb awaryjny elektrowni on? {0}",elektrownia.TrybAwaryjny);
                Console.WriteLine("dostępne pługi: {0}  pługi w użyciu {1}",autostrada.DostępnePługi,autostrada.PługiNaAutostradzie);
                Console.WriteLine("czy generator on: {0}",szpital.IsGeneratorOn);
                Console.WriteLine("czy lotnisko zamknięte: {0}",lotnisko.IsClosed);

                pogoda.OpadyŚniegu =20*rng.Next(0,6);
                
                

                pogoda.OpadyDeszczu = 10*rng.Next(0,31);
                zbiornik.PoziomWody += pogoda.OpadyDeszczu;                

                pogoda.Temperatura += 5;
                pogoda.Wiatr += 10;
                Thread.Sleep(1000);
                
                Console.Clear();
                

            }


           
        }

        

        public static void OnUpał(object sender, EventArgs e)
        {
            
        }

        public static void OnPług(object sender, EventArgs e)
        {
            Console.WriteLine("Wszystkie pługi na autostradzie");
        }

        public static void OnŚnieg(object sender, EventArgs e)
        {
            
        }

        public static void OnDeszcz(object sender, EventArgs e)
        {
            
        }

        public static void OnWiatr(object sender, EventArgs e)
        {
            
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
    

    

    interface IDokument<T>
    {
        void Podnieś(T obj);
    }
}
