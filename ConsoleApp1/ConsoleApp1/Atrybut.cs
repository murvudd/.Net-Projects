using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Atrybut
    {
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
        public string d { get; set; }
        public string e { get; set; }
        public string f { get; set; }

        public void Metoda()
        {
            string str = nameof(this.a);
            Console.WriteLine(str);
        }
        //public Atrybut(string _a, string _b, string _c, string _d, string _e, string _f)
        //{
        //    a = _a;
        //    b = _b;
        //    c = _c;
        //    d = _d;
        //    e = _e;
        //    f = _f;
        //}

        public List<string> IleWystąpień(char sw)
        {
            List<string> lista = new List<string>();
            switch (sw)
            {
                case 'a':
                    foreach (var e in lista) {
                        if (e != this.a)
                        {
                            lista.Add(this.a);
                            
                        }
                    }
                    break;
                case 'b':
                    foreach (var e in lista)
                    {
                        if (e != this.b)
                        {
                            lista.Add(this.b);
                        }
                    }
                    break;
                case 'c':
                    foreach (var e in lista)
                    {
                        if (e != this.c)
                        {
                            lista.Add(this.c);
                        }
                    }
                    break;
                case 'd':
                    foreach (var e in lista)
                    {
                        if (e != this.e)
                        {
                            lista.Add(this.d);
                        }
                    }

                    break;
                case 'e':
                    foreach (var e in lista)
                    {
                        if (e != this.e)
                        {
                            lista.Add(this.e);
                        }
                    }
                    break;
            }

            return lista;
        }

        public int IleWystąpień(char sw, string x)
        {
            int i = 0;
            switch (sw)
            {
                case 'a':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.a == x) i++;
                    }
                    break;
                case 'b':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.b == x) i++;
                    }
                    break;
                case 'c':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.c == x) i++;
                    }
                    break;
                case 'd':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.d == x) i++;
                    }
                    break;
                case 'e':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.e == x) i++;
                    }
                    break;
            }

            return i;
        }

        public int IleWystąpień(char sw, string x, bool B)
        {
            int i = 0;
            switch (sw)
            {
                case 'a':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.a == x && Convert.ToBoolean(int.Parse(this.f)) == B) i++;
                    }
                    break;
                case 'b':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.b == x && Convert.ToBoolean(int.Parse(this.f)) == B) i++;
                    }
                    break;
                case 'c':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.c == x && Convert.ToBoolean(int.Parse(this.f)) == B) i++;
                    }
                    break;
                case 'd':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.d == x && Convert.ToBoolean(int.Parse(this.f)) == B) i++;
                    }
                    break;
                case 'e':
                    for (int k = 0; k < 8; k++)
                    {
                        if (this.e == x && Convert.ToBoolean(int.Parse(this.f)) == B) i++;
                    }
                    break;
            }

            return i;
        }

        
    }
}
