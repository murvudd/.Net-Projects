using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using System.Threading;
 
 namespace Lab2.Models
 {
     class Czasopismo : Publikacja
     {
         public int Numer { get; set; }
 
         public Czasopismo(int numer, string autor, string tytuł, int rok) : base(autor, tytuł, rok)
         {
             this.Numer = numer;           
 
         }
     }
 }