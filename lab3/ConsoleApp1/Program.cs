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
    class Case
    {
        public int? Year { get; set; }
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

            //var list = (from e in CaseList where ((e.Country == "USA") && (e.Area == "Florida")) select e);
            var list0 = from e in CaseList
                            //where e.Country == "USA" && e.Area =="Florida"
                        where e.Country == "USA"
                        select e;
            Console.WriteLine("{1}  {0}", list0.Count(), list0.ElementAt(0).Country);
            /*
           foreach (var w in list1)
            {
                Console.WriteLine(w.Area);
            }
            */
            var list1 = from e in CaseList
                            //where e.Country == "USA" && e.Area =="Florida"
                        where e.Area == "Florida"
                        select e;

            Console.WriteLine("{1}  {0}", list1.Count(), list1.ElementAt(0).Area);

            var list2 = from e in CaseList
                            //where e.Country == "USA" && e.Area =="Florida"
                        where e.Area == "Texas"
                        select e;

            Console.WriteLine("{1}  {0}", list2.Count(), list2.ElementAt(0).Area);

            var list3 = from e in CaseList
                            //where e.Country == "USA" && e.Area =="Florida"
                        where e.Country == "China"
                        select e;

            //            Console.WriteLine("{1}  {0}", list3.Count(), list3.ElementAt(0).Country);
            Console.WriteLine("China  {0}", list3.Count());

            //catch (Exception e)
            //{
            //    Console.WriteLine("nie ok :c ");
            //    Console.WriteLine(e.Message);
            //    Console.ReadKey();
            //}
            var list4 = from e in CaseList
                            //where e.Country == "USA" && e.Area =="Florida"
                        where e.Country == "Chile"
                        select e;

            Console.WriteLine("Chile  {0}", list4.Count());

            var list5 = from e in CaseList
                            //where e.Country == "USA" && e.Area =="Florida"
                        where e.Country == "USA" && e.Fatal == "Y"
                        select e;

            Console.WriteLine("{1} Fatal  {0}", list5.Count(), list5.ElementAt(0).Country);

            var list6 = from e in CaseList
                            //where e.Country == "USA" && e.Area =="Florida"
                        where e.Country == "AUSTRALIA" && e.Fatal == "Y"
                        select e;

            Console.WriteLine("{1} Fatal  {0}", list6.Count(), list6.ElementAt(0).Country);

            var list7 = from e in CaseList
                            //where e.Country == "USA" && e.Area =="Florida"
                        where e.Country == "BRAZIL" && e.Fatal == "Y"
                        select e;

            Console.WriteLine("{1} Fatal  {0}", list7.Count(), list7.ElementAt(0).Country);

            var list8 = from e in CaseList
                            //where e.Country == "USA" && e.Area =="Florida"
                        where e.Country == "IRAN" && e.Fatal == "Y"
                        select e;

            Console.WriteLine("{1} Fatal  {0}", list8.Count(), list8.ElementAt(0).Country);

            var list9 = from e in CaseList
                            //where e.Country == "USA" && e.Area =="Florida"
                        where e.Fatal == "Y"
                        select e;

            Console.WriteLine("All Fatal {0}", list9.Count());

            var list10 = (from e in CaseList
                              //where e.Country == "USA" && e.Area =="Florida"
                          where e.Country == "USA"
                          select e.Age).Average();

            Console.WriteLine("{1} Average Age  {0}", list10, list5.ElementAt(0).Country);

            var list11 = (from e in CaseList
                              //where e.Country == "USA" && e.Area =="Florida"
                          where e.Country == "IZRAEL"
                          select e.Age).Average();

            Console.WriteLine("IZRAEL Average Age  {0}", list11);

            var list12 = (from e in CaseList
                              //where e.Country == "USA" && e.Area =="Florida"
                          where e.Country == "AUSTRALIA"
                          select e.Age).Average();

            Console.WriteLine("AUSTRALIA Average Age  {0}", list12);


            var list13 = (from e in CaseList
                              //where e.Country == "USA" && e.Area =="Florida"
                          where e.Country == "CHILE"
                          select e.Age).Average();

            Console.WriteLine("CHILE Average Age  {0}", list13);

            var list14 = (from e in CaseList
                              //where e.Country == "USA" && e.Area =="Florida"
                          where e.Country == "SOUTH AFRICA"
                          select e.Age).Average();

            Console.WriteLine("SOUTH AFRICA Average Age  {0}", list14);

            var list15 = (from e in CaseList
                              //where e.Country == "USA" && e.Area =="Florida"
                          where e.Country == "CHINA" && e.Fatal == "Y"
                          select e.Age).Max();

            Console.WriteLine("MAX age fatal china {0}", list15);

            var list16 = (from e in CaseList
                              //where e.Country == "USA" && e.Area =="Florida"
                          where e.Country == "USA" && e.Activity == "Surfing"
                          select e.Age).Min();

            Console.WriteLine("min age USA while surfing {0}", list16);


            var list17 = (from e in CaseList

                          where e.Type == "Provoked"
                          select new { Country = e.Country, Area = e.Area, Age = e.Age, Fatal = e.Fatal });

            Console.WriteLine("Provoked fatal {0}", list17.Count());

            var list18 = (from e in CaseList

                          where e.Type == "Unprovoked" && (e.Country == "USA" || e.Country == "AUSTRALIA")
                          select e);

            Console.WriteLine("Unprovoked fatal in US and AUS {0}", list18.Count());

            var list19 = (from e in CaseList

                          where e.Activity == "Surfing" && e.Age >= 30
                          select e);

            Console.WriteLine("age>=30 surfing {0}", list19.Count());

            var list20 = (from e in CaseList

                          where e.Country == "Brazil"
                          select e);

            IEnumerable<IGrouping<string, Case>>
                list21 = from element in list20
                         group element by element.Activity
                       into empgroup
                         orderby empgroup.Key
                         select empgroup;
            Console.WriteLine("Brazil {0}", list21.Count());
            //foreach (var group in list21)
            //{
            //    foreach (Case e in group)
            //    {
            //        Console.WriteLine(group.Key + " " + e.Activity);
            //    }
            //}

            var list22 = (from e in CaseList

                          where e.Country == "AUSTRALIA" && e.Activity == "Surfing"
                          select e);

            IEnumerable<IGrouping<int?, Case>>
                list23 = from element in list22
                         group element by element.Age
                       into empgroup
                         orderby empgroup.Key
                         select empgroup;
            Console.WriteLine("AUSS {0}", list23.Count());
            foreach (var group in list23)
            {
                foreach (Case e in group)
                {
                    Console.WriteLine(group.Key + " " + e.Age);
                }
            }


            Console.ReadKey();









        }
    }
}
