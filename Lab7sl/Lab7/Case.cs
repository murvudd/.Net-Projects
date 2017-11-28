using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    interface IMyComparer<T>
    {
        int CompareType(T obj0, T obj1);
        int CompareCountry(T obj0, T obj1);
        int CompareArea(T obj0, T obj1);
    }
    class Case :IComparable<Case>, IMyComparer<Case>
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

        public int CompareTo(Case that) {
            if (this.Year > that.Year) return -1;
            if (this.Year == that.Year) return 0;
            return 1;
        }
           public int CompareType(Case a, Case b)
        {
            if (a.Type == b.Type) return 1;
            return 0;
        }

        public int CompareArea(Case a, Case b)
        {
            if (a.Area == b.Area) return 1;
            return 0;
        }

        public int CompareCountry(Case a, Case b)
        {
            if (a.Country == b.Country) return 1;
            return 0;
        }

    }

}
