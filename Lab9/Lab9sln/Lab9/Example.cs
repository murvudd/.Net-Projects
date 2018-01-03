using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Lab9
{
    class Example
    {
        static void Main1(string[] args)
        {
            DataSet carsInvDS = new DataSet("Car Inv");
            carsInvDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
            carsInvDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            carsInvDS.ExtendedProperties["Company"] = "Mikko’s Hot Tub Super Store";

            Console.ReadLine();
        }
        static void FillDataSet(DataSet ds)
        {
            // Create data columns that map to the
            // "real" columns in the Inventory table
            // of the AutoLot database.
            DataColumn carIDColumn = new DataColumn("CarID", typeof(int));
            carIDColumn.Caption = "Car ID";
            carIDColumn.ReadOnly = true;
            carIDColumn.AllowDBNull = false;
            carIDColumn.Unique = true;
            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
            carPetNameColumn.Caption = "Pet Name";

            // Now add DataColumns to a DataTable.
            DataTable inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new DataColumn[]
            { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });
        }
    }
}
