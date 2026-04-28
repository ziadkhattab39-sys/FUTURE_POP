using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using FUTURE_POP.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FUTURE_POP.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary> 
        public static List<Governorate> AllGovs = new List<Governorate>();
        public static List<Governorate> ExcelReader ()
        {
            using (var workbook = new XLWorkbook("C:\\Users\\LOQ\\source\\repos\\FUTURE_POP\\Unified Form .xlsx"))
            {
                var worksheet = workbook.Worksheet(1);
                var rows = worksheet.RangeUsed().RowsUsed().Skip(2);
                foreach (var row in rows)
                {
                    // Reading Cells
                    string Name = row.Cell(1).GetString(); 
                    string Capital = row.Cell(2).GetString();
                    int Pop2018 = row.Cell(3).GetValue<int>();
                    int Pop2020 = row.Cell(4).GetValue<int>();
                    int Pop2022 = row.Cell(5).GetValue<int>();
                    int Pop2024 = row.Cell(6).GetValue<int>();
                    int Pop2026 = row.Cell(7).GetValue<int>();
                    int Area = row.Cell(8).GetValue<int>();
                    string Type = row.Cell(9).GetString();
                    // Creating Objects
                    Governorate Gov;
                    switch (Type.Trim())
                    {
                        case "Urban":
                            Gov = new Urban (Name, Capital, Pop2018, Pop2020, Pop2022, Pop2024, Pop2026, Area, Type);
                            break;
                        case "Rural":
                            Gov = new Rural (Name, Capital, Pop2018, Pop2020, Pop2022, Pop2024, Pop2026, Area, Type);
                            break;
                        case "Border":
                            Gov = new FUTURE_POP.CORE.Border(Name, Capital, Pop2018, Pop2020, Pop2022, Pop2024, Pop2026, Area, Type);
                            break;
                        case "Mixed":
                            Gov = new Mixed (Name, Capital, Pop2018, Pop2020, Pop2022, Pop2024, Pop2026, Area, Type);
                            break;
                        default:
                            Gov = null;
                            break;
                    }
                    AllGovs.Add(Gov);
                }
            }
            return AllGovs;
        }
        [STAThread]
        static void Main()
        {
            List <Governorate> Govs = ExcelReader();
            foreach (var Gov in Govs)
            {
                Gov.CalculateDensity();
                Gov.CalculateGrowthRate();
                Gov.CalculateAverage();
                Gov.PredictNewPopGrowth();
                Gov.PredictNewPopCount();
                Gov.ServiceRatio();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FuturePop(Govs));
        }
    }
}
