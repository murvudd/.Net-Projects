using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;


namespace Lab9
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
            DataSet Lab9DS = new DataSet("Event Set");
            Lab9DS.ExtendedProperties["TimeStamp"] = DateTime.Now;
            Lab9DS.ExtendedProperties["DateSetID"] = Guid.NewGuid();
            try
            {
                FillDataSet(Lab9DS);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                PrintDataSet(Lab9DS);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
        static void FillDataSet(DataSet ds)
        {
            //create datacolumns
            DataColumn IDcolumn = new DataColumn("ID", typeof(int));
            IDcolumn.AllowDBNull = false;
            IDcolumn.ReadOnly = true;
            IDcolumn.Unique = true;
            IDcolumn.AutoIncrement = true;
            IDcolumn.AutoIncrementSeed = 1;
            IDcolumn.AutoIncrementStep = 1;

            DataColumn YearColumn = new DataColumn("Year", typeof(int));
            YearColumn.Caption = "Rok";
            YearColumn.AllowDBNull = true;
            
            

            DataColumn CountryColumn = new DataColumn("Country", typeof(string));
            CountryColumn.Caption = "Kraj";
            
            CountryColumn.AllowDBNull = true;
            
            

            DataColumn AgeColumn = new DataColumn("Age", typeof(int));
            AgeColumn.Caption = "Wiek";
            AgeColumn.AllowDBNull = true;
            
            
            

            // add datacolumns to dataset
            DataTable Lab9Table = new DataTable("Tabela1");
            Lab9Table.Columns.AddRange(new DataColumn[]
                { IDcolumn, YearColumn, CountryColumn, AgeColumn });

           
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

            //adding rows
            DataRow TableRow = Lab9Table.NewRow();
            if (CaseList[0].Year == null) TableRow[YearColumn] = DBNull.Value;
            else TableRow[YearColumn] = CaseList[0].Year;

            if (CaseList[0].Country == null) TableRow[CountryColumn] = DBNull.Value;
            else TableRow[CountryColumn] = CaseList[0].Country;

            if (CaseList[0].Age == null) TableRow[AgeColumn] = DBNull.Value;
            else TableRow[AgeColumn] = CaseList[0].Age;

            Lab9Table.Rows.Add(TableRow);
            for (int j = 1; j < 300; j++)
            {
                //if (CaseList[j].Year != null && CaseList[j].Country != null && CaseList[j].Age != null)
                {

                    TableRow = Lab9Table.NewRow();

                    if (CaseList[j].Year == null) TableRow[YearColumn] = DBNull.Value;
                    else TableRow[YearColumn] = CaseList[j].Year;

                    if (CaseList[j].Country == null) TableRow[CountryColumn] = DBNull.Value;
                    else TableRow[CountryColumn] = CaseList[j].Country;

                    if (CaseList[j].Age == null) TableRow[AgeColumn] = DBNull.Value;
                    else TableRow[AgeColumn] = CaseList[j].Age;

                    Lab9Table.Rows.Add(TableRow);
                }
            }
            TableRow.AcceptChanges();
            // Mark the primary key of this table.
            Lab9Table.PrimaryKey = new DataColumn[] { Lab9Table.Columns[0] };

            ds.Tables.Add(Lab9Table);

        }

        static void PrintDataSet(DataSet ds)
        {
            // Print out the DataSet name and any extended properties.
            Console.WriteLine("DataSet is named: {0}", ds.DataSetName);
            foreach (System.Collections.DictionaryEntry de in ds.ExtendedProperties)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }
            Console.WriteLine();

            // Print out each table.
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("=> {0} Table:", dt.TableName);
                // Print out the column names.
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Columns[curCol].ColumnName + "\t");
                }
                Console.WriteLine("\n----------------------------------");

                // Print the DataTable.
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void RndError(DataSet ds)
        {
            Random rng = new Random();
            rng.Next(1, ds.Tables.Count);
            DataTable tablica = ds.Tables[0];
            
        }
    }
}
