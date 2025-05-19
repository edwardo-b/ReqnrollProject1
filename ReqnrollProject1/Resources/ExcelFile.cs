using NPOI.XSSF.UserModel;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytescout.Spreadsheet;

namespace ReqnrollProject1.Variable
{
    internal class ExcelFile

    {
        public void destinationTown()
        {
            Random ran = new Random();
            String[] b = { "DED", "DEL", "DHM", "RDP", "GOI", "GAU", "GWL", "HYD", "JLR", "JAI", "JSA", "AIP" };
            int length = 1;
            String random = "";
            for (int i = 0; i < length; i++)
            {
                int a = ran.Next(b.Length);
                random = random + b.ElementAt(a);
                Console.WriteLine(random);
            }
        }
        //Both codes work the same
        public void arrivalTown()
        {
            String[] airportsNames = { "AGR", "AMD", "KQH", "ATQ", "IXB", "IXG", "BLR", "BHU", "BHO", "IXC", "MAA", "CJB", "DBR" };
            Random rnd = new Random();
            int randAirportIdx = rnd.Next(airportsNames.Length);
            String randomAirportFromElem = airportsNames[randAirportIdx];
            Console.WriteLine(randomAirportFromElem);
        }

        public void tryToImportFromExcel()
        {
            /*string path = @"C:\Users\Edward.Osei-Bonsu\Documents\SpiceJetExcel.xlsx";
            XSSFWorkbook wb = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = wb.GetSheetAt(0);
            var row = sheet.GetRow(0);
            for (int i = 1; i < row.Cells.Count; i++)
            {
                //  value = row.Cells[i].StringCellValue.Trim();
                var value = row.GetCell(i).StringCellValue.Trim();
            */
            string path = @"C:\Users\Edward.Osei-Bonsu\Documents\SpiceJetExcel.xlsx";
            Spreadsheet document = new Spreadsheet();
            document.LoadFromFile(path);
            Worksheet worksheet = document.Workbook.Worksheets[0];
            for (int i = 1; i < 10; i++)
            {
                var value = Convert.ToString(worksheet.Cell(0, i));

                Console.WriteLine(value);

                String[] airportsNames = { value };
                Random rnd = new Random();
                int randAirportIdx = rnd.Next(airportsNames.Length);
                String randomAirportFromElem = airportsNames[randAirportIdx];
                Console.WriteLine(randomAirportFromElem);
            }
            //}
        }
        public void phoneNumber()

        {
            string path = @"C:\Users\Edward.Osei-Bonsu\Documents\SpiceJetExcel.xlsx";
            XSSFWorkbook wb = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = wb.GetSheetAt(1);
            var row = sheet.GetRow(0);
            for (int i = 1; i < row.Cells.Count; i++)
            {
                //  value = row.Cells[i].StringCellValue.Trim();
                var value = Convert.ToString(row.GetCell(i).StringCellValue.Trim());

                Console.WriteLine(value);
            }
        }

        public string GetPhoneNumber()
        {
            string path = @"C:\Users\Edward.Osei-Bonsu\Documents\SpiceJetExcel.xlsx";

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found: " + path);
                return "";
            }

            try
            {
                Spreadsheet document = new Spreadsheet();
                document.LoadFromFile(path);
                Worksheet worksheet = document.Workbook.Worksheets[1]; // Check index

                var value = Convert.ToString(worksheet.Cell(0, 1)); // 1-based
                Console.WriteLine("Phone Number: " + value);
                return value;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return "";
            }
        }



        public string GetPassword()
        {
            string path = @"C:\Users\Edward.Osei-Bonsu\Documents\SpiceJetExcel.xlsx";
            Spreadsheet document = new Spreadsheet();
            document.LoadFromFile(path);
            Worksheet worksheet = document.Workbook.Worksheets[1];

            try
            {
                var value = Convert.ToString(worksheet.Cell(2, 1));
                Console.WriteLine(value);
                return value;
            }
            catch (Exception e) { Console.WriteLine(e.Message); return ""; }
        }

    }
}
