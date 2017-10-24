//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Lab3
//{
//    class Examples
//    {
//    }
//    class DepartmentClass
//    {
//        public int DepartmentId { get; set; }
//        public string Name { get; set; }
//    }
//    class EmployeeClass
//    {
//        public int EmployeeId { get; set; }
//        public string EmployeeName { get; set; }
//        public int DepartmentId { get; set; }
//        public int YeartoRetitement { get; set; }


//        static void Main(string[] args)
//        {
//            lista obiektow opisujacych dzial
//            List<DepartmentClass> departments = new List<DepartmentClass>();
//            departments.Add(new DepartmentClass { DepartmentId = 1, Name = "Accounting" });
//            departments.Add(new DepartmentClass { DepartmentId = 2, Name = "Sales" });
//            departments.Add(new DepartmentClass { DepartmentId = 3, Name = "Marketing" });
//            lista obiektow pracownikow z id dzialu
//            List<EmployeeClass> employees = new List<EmployeeClass>();
//            employees.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 1, EmployeeName = "William", YeartoRetitement = 40 });
//            employees.Add(new EmployeeClass { DepartmentId = 2, EmployeeId = 2, EmployeeName = "Miley", YeartoRetitement = 5 });
//            employees.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 3, EmployeeName = "Benjamin", YeartoRetitement = 30 });

//            przykład składni
//            string[] wierszyk = { "a", "bc", "def", "gihjk", "kdkd", "sad", "gk" };
//            var lista = from w in wierszyk where (w.Length < 4) select w;
//            var lista = wierszyk.Where(s => s.Length < 4); // składnia lambda równoważna linijce wyżej
//            foreach (var w in lista)
//            {
//                Console.WriteLine(w);
//            }

//            var list = (from e in employees where (e.DepartmentId == 1) select e);
//            var list = employees.Where(el => el.DepartmentId == 1);
//            var list1 = employees.Average(el => el.DepartmentId == 1);
//            foreach (var e in list)
//            {
//                Console.WriteLine(e.EmployeeName);
//            }
//            var list1 = from e in employees
//                        join d in departments on e.DepartmentId // łączenie dwóch list w nową listę 
//    equals d.DepartmentId
//                        select new { EN = e.EmployeeName, DN = d.Name };
//            foreach (var el in list1)
//            {
//                Console.WriteLine("{0} works in {1}", el.EN, el.DN);
//            }

//            grupowanie

//            IEnumerable<IGrouping<int, EmployeeClass>>
//                list = from element in employees
//                       group element by element.YeartoRetitement
//                       into empgroup
//                       orderby empgroup.Key
//                       select empgroup;

//            foreach (var group in list)
//            {
//                foreach (EmployeeClass e in group)
//                {
//                    Console.WriteLine(group.Key + " " + e.EmployeeName);
//                }
//            }


//            var list = (from e in employees where (e.DepartmentId == 1) select e.YeartoRetitement).Average();
//            Console.WriteLine("{0}       {1}", list, list.GetType());

//        }

//    }
//}