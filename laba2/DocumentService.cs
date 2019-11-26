using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Net;
using System.IO;
using OfficeOpenXml;
using System.Threading.Tasks;

namespace laba2
{
    class DocumentService
    {
        public static List<Threat> FileUpload()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile("https://bdu.fstec.ru/documents/files/thrlist.xlsx", "TableData.xlsx");

            }
            return Parsexlsx();
        }
        public static List<Threat> Parsexlsx()
        {
            List<string> excelData = new List<string>();
            //byte[] bin = File.ReadAllBytes("C:\\Users\\Admin\\source\\repos\\laba2\\laba2\\bin\\Debug\\TableData.xlsx");
            byte[] bin = File.ReadAllBytes("C:\\Users\\Пушистая булка\\source\\repos\\laba2\\laba2\\bin\\Debug\\TableData.xlsx");
            using (MemoryStream stream = new MemoryStream(bin))
            {
                using (ExcelPackage excelPackage = new ExcelPackage(stream))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.First();
                    for (int i = worksheet.Dimension.Start.Row + 2; i <= worksheet.Dimension.End.Row; i++)
                    {
                        string str = "";
                        for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column - 2; j++)
                        {
                            str += worksheet.Cells[i, j].Value.ToString() + "☭";
                        }
                        excelData.Add(str);
                    }
                }
            }
            return ParseExcelData(excelData);
        }

        public static List<Threat> ParseExcelData(List<string> excelData)
        {
            List<Threat> thr = new List<Threat>();

            for (int i = 0; i < excelData.Count; i++)
            {
                excelData[i] = excelData[i].Replace("_x000d_", "");
            }

            foreach (var item in excelData)
            {
                if (item.Contains('☭'))
                {
                    string[] infoThread = new string[item.Split('☭').Length];
                    infoThread = item.Split('☭');
                    int id = Convert.ToInt32(infoThread[0]);
                    string name = infoThread[1];
                    string description = infoThread[2];
                    string sourceofthreat = infoThread[3];
                    string objectofinfluence = infoThread[4];
                    string privacyViolation = infoThread[5];
                    string integrityViolation = infoThread[6];
                    string accessibility = infoThread[7];
                    Threat threat = new Threat(id, name, description, sourceofthreat, objectofinfluence, privacyViolation, integrityViolation, accessibility);
                    thr.Add(threat);
                }
            }
            return thr;
        }
    }
}


