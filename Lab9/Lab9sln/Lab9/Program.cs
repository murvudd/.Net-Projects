using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Threading;


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
            try
            {


                DataSet Lab9DS = new DataSet("Event Set");
                Lab9DS.ExtendedProperties["TimeStamp"] = DateTime.Now;
                Lab9DS.ExtendedProperties["DateSetID"] = Guid.NewGuid();
                try
                {
                    FillDataSet(Lab9DS);
                }
                catch
                {
                    throw;
                }
                try
                {
                    RndError(Lab9DS);
                    PrintDataSet(Lab9DS,"r");
                }
                catch
                {
                    throw;
                }                
                
                try
                {
                    // rngCheck(Lab9DS);
                    HowManyErrors(Lab9DS);
                    Console.WriteLine("\n\n\n###############");
                    //PrintDataSet(Lab9DS, "r");
                    //Console.WriteLine(Lab9DS.HasChanges());
                    //PrintDataSet(Lab9DS.GetChanges());
                    //Console.WriteLine(Lab9DS.GetChanges());
                    NaprawaBłędów(Lab9DS);
                    PrintDataSet(Lab9DS, "t");
                }
                catch
                {
                    throw;
                }
                Console.ReadKey();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void CheckChanges(DataSet ds)
        {
            ds.GetChanges();
        }

        static void rngCheck(DataSet ds)
        {
            Random rng = new Random();
            for (int i =0; i < ds.Tables[0].Rows.Count; i ++ )
            {
                
                Console.WriteLine("i:{0},   rng:{1}",i , rng.Next(0, 2));
            }
        }
        //static void FillErrorSet(DataSet ds, DataSet es)
        //{
        //    DataRow[] er = ds.Tables[0].GetErrors();
        //    DataColumn ErrColumn = new DataColumn("Error", typeof(string));
        //    DataTable ErrTable = new DataTable("Error Table");
        //    ErrTable.Columns.Add(ErrColumn);
            
        //    foreach (var e in er)
        //    {
        //        ErrTable.Rows.Add(e);
        //    };
        //    ErrTable.AcceptChanges();
        //    es.Tables.Add(ErrTable);

        //}

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

            ds.AcceptChanges();

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

        static void PrintDataSet(DataSet ds, string f)
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
                    Console.Write(dt.Columns[curCol].ColumnName + "\t\t");
                }
                Console.Write("Row Error");
                Console.WriteLine("\n------------------------------------------");

                // Print the DataTable.
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Console.Write(dt.Rows[curRow][curCol].ToString() + "\t\t");
                    }
                    Console.Write(dt.Rows[curRow].RowError);
                    Console.WriteLine();
                }
            }
        }

        static void RndError(DataSet ds)
        {
            Random rng = new Random();
            DataRow dr = ds.Tables[0].Rows[0];
            for (int i = 0; i < 40; i++) {
                Thread.Sleep(10);
                dr = ds.Tables[0].Rows[rng.Next(1, ds.Tables[0].Rows.Count)];
                Thread.Sleep(10);
                //if (0 == rng.Next(0, 2)) { dr.RowError = "Rekord Uszkodzony"; dr.RowState = DataRowState  };
                if (0 == rng.Next(0, 2)) dr.RowError = "Rekord Uszkodzony";
                else dr.RowError = "Rekord Nadpisany";
            }
            
        }

        static void HowManyErrors(DataSet ds)
        {
            Console.WriteLine("\n\n\n##############################");
            int i = 0;
            foreach(DataTable dt in ds.Tables)
            {
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    if (dt.Rows[curRow].RowError != "")
                    {
                        i++;
                        Console.WriteLine("Row ID:{0}       Row Error: {1}      Row State:{2}",dt.Rows[curRow]["ID"],dt.Rows[curRow].RowError,
                            dt.Rows[curRow].RowState);

                    }; 
                }
                Console.WriteLine("Łącznie wystąpiło {0} błędów", i);
            }
        }

        static void NaprawaBłędów(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {

                
                int i = 0;
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    if (dt.Rows[curRow].RowError != "")
                    {
                        i++;
                        dt.Rows[curRow].ClearErrors();
                    };
                }
                ds.AcceptChanges();
                Console.WriteLine("Naprawiono {0}  błędów", i);
            }
        }
    }
}
