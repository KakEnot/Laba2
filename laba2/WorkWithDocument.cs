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
        class WorkWithDocument
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
                byte[] bin = File.ReadAllBytes("C:\\Users\\Admin\\source\\repos\\laba2\\laba2\\bin\\Debug\\TableData.xlsx");//"C:\\Users\\Пушистая булка\\source\\repos\\laba2\\laba2\\bin\\Debug\\TableData.xlsx");
                using (MemoryStream stream = new MemoryStream(bin))
                {
                    using (ExcelPackage excelPackage = new ExcelPackage(stream))
                    {
                        //loop all worksheets - зациклить все листы
                        foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                        {
                            //loop all rows - цикл всех строк
                            for (int i = worksheet.Dimension.Start.Row + 2; i <= worksheet.Dimension.End.Row; i++)
                            {
                                //loop all columns in a row -цикл всех столбцов подряд
                                for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column - 2; j++)
                                {
                                    //add the cell data to the List - добавить данные ячейки в список
                                    if (worksheet.Cells[i, j].Value != null)
                                    {
                                        excelData.Add(worksheet.Cells[i, j].Value.ToString() + "$");
                                    }
                                    else
                                    {
                                        excelData.Add("-");
                                    }

                                }
                                excelData.Add("#");

                            }
                        }
                    }
                }
                return ParseExcelData(excelData);
            }

            public static List<Threat> ParseExcelData(List<string> excelData)
            {
                for (int i = 0; i < excelData.Count; i++)
                {
                    excelData[i] = excelData[i].Replace("_x000d_", "").Replace("\r\n", "").Replace("\n", "");
                }

                List<Threat> thr = new List<Threat>();
                string str = "";
                for (int i = 0; i < excelData.Count; i++)
                {
                    str = str + excelData[i];
                }
                string[] infoForExemplar = new string[str.Split('#').Length];
                infoForExemplar = str.Split('#');


                for (int i = 0; i < infoForExemplar.Length; i++)
                {
                    string str1 = "";
                    for (int j = 0; j < infoForExemplar[i].Length; j++)
                    {
                        str1 = str1 + infoForExemplar[i][j];
                    }

                    string[] infoThread = new string[str1.Split('$').Length];
                    infoThread = str1.Split('$');
                    int id = Convert.ToInt32(infoThread[1]);
                    string name = infoThread[2];
                    string description = infoThread[3];
                    string sourceofthreat = infoThread[4];
                    string objectofinfluence = infoThread[5];
                    string privacyViolation = infoThread[6];
                    string integrityViolation = infoThread[7];
                    string accessibility = infoThread[8];
                    Threat threat = new Threat(id, name, description, sourceofthreat, objectofinfluence, privacyViolation, integrityViolation, accessibility);
                    thr.Add(threat);

                }
                return thr;
            }
        }
    }


