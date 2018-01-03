using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using Lab8.Models;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnect a = new DBConnect();
            /* TODO
             
             *  dodać w aplikacji konsolowej loopa z casem od wybierania przez użytkownika kolejnego kroku
             *  
             */
            
            {
                while (true)
                {
                    Console.WriteLine("Witaj w InterFejsie bazy danych, co chesz zrobić?");
                    Console.WriteLine("\n1.Dodaj Zdarzenie\n2.Usuń zdarzenie\n3.Zmiana Zdarzenia\n4.Wyświetl n pierwszych zdarzeń\n5.Wybierz Zdarzenia gdzie Siła > n\n0.Wyjście z Programu");
                    int opcja = int.Parse(Console.ReadLine());
                    switch (opcja)
                    {
                        case 1:
                            DodajZdarzenie(a);
                            break;

                        case 2:
                            UsuńZdarzenie(a);
                            break;

                        case 3:
                            ZmianaZdarzenia(a);
                            break;

                        case 4:
                            Wyświetl(a);
                            break;

                        case 5:
                            Wybierz(a);
                            break;


                        case 0:
                            Console.WriteLine("Do zobaczenia\n");
                            System.Environment.Exit(1);
                            break;

                        default:
                            Console.WriteLine("Zły wybór");
                            Console.Clear();
                            break;
                    }
                }
            }


        }

        static void DodajZdarzenie(DBConnect a)
        {
            Console.Clear();
            Console.WriteLine("Dodaj Nowe Zdarzenie\n\n");
            Console.WriteLine("Rok:");
            int Rok = int.Parse(Console.ReadLine());
            Console.WriteLine("Miejsce:");
            string Miejsce= Console.ReadLine();
            Console.WriteLine("Kraj:");
            string Kraj = Console.ReadLine();
            Console.WriteLine("Siła:");
            string Siła = Console.ReadLine();

            a.InsertEarthquake(Rok, Miejsce, Kraj, Siła);
        }

        static void UsuńZdarzenie(DBConnect a)
        {
            Console.Clear();
            Console.WriteLine("Wybierz ID zdarzenia które chcesz usunąć");
            a.DeleteID(int.Parse(Console.ReadLine()));
        }
        
        static void ZmianaZdarzenia(DBConnect a)
        {
            Console.Clear();
            Console.WriteLine("Zmiana Siły Zdarzenia\nWybierz ID:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Wstaw siłę: ");
            a.Update(id,int.Parse(Console.ReadLine()));
        }

        static void Wyświetl(DBConnect a)
        {
            Console.Clear();
            Console.WriteLine("Wybierz n pierwszych Zdarzeń\nWprowadź n");
            DBConnect.PrintList(a.SelectAll(), int.Parse(Console.ReadLine()));
        }

        static void Wybierz(DBConnect a)
        {
            Console.Clear();
            Console.WriteLine("Wybierz wszystkie Zdarzenia o Sile większej niż n\nWprowadź n");
            DBConnect.PrintList(a.SelectWhereMagnitude((decimal)double.Parse(Console.ReadLine())));
        }
    }
}
