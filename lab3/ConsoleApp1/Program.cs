using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3
{
    static class Parse
    {
        public static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }
    }
    class Case  {
        public int? Year {get; set;}
        public int? Age { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string Activity { get; set; }
        public string Sex { get; set; }
        public string Fatal { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Case> CaseList = new List<Case>();

            string[] plik = File.ReadAllLines("attacks.csv");
            //char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            for (int i=1; i<plik.Length;i++) {
                string[] b = plik[i].Split(';');
                CaseList.Add(new Case { Year = Parse.ToNullableInt(b[2]),
                    Type = b[3], Country = b[4], Area = b[5], Activity = b[7],
                    Name = b[8], Sex = b[9], Age = Parse.ToNullableInt (b[10]) });

            }

            //var list = (from e in CaseList where ((e.Country == "USA") && (e.Area == "Florida")) select e);
            var list = from e in CaseList
                       where e.Country == "USA" && e.Area =="Florida"
                       select e;


            foreach (var w in list)
            {
                Console.WriteLine(w.Area);
            }
            Console.WriteLine(list.Count());
            
            
        }
    }
}
