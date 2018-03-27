using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.SqlAndPlsqlParser.LocalParsing;

namespace ConsoleApp29
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)
            (HOST=dbserver.mif.pg.gda.pl)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)
            (SERVICE_NAME=ORACLEMIF)));User Id={0};Password={1};";

            //pobranie loginu i hasla
            Console.WriteLine("Podaj login:");
            string login = Console.ReadLine();
            Console.WriteLine("Podaj hasło:");
            string pass = Console.ReadLine();

            //nadpisanie CS
            cs = String.Format(cs, login, pass);


            OracleConnection oraconn = new OracleConnection(cs);
            try
            {
                oraconn.Open();
                OracleGlobalization og = oraconn.GetSessionInfo();
                Console.WriteLine(og.DateFormat + " " + og.Territory + " " + og.Language);

                string sql = "INSERT INTO";

                // Create command.
                OracleCommand cmd = new OracleCommand();
                // Set connection for command.
                cmd.Connection = oraconn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Row inserted !! ");


                oraconn.Close();
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

        }
    }
}
