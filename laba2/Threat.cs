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
    class Threat
    {
        public static int Count { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SourceOfThreat { get; set; } //Внешний/внутренний или нет вообще
        public string ObjectOfInfluence { get; set; } // Объект воздействия
        public bool IntegrityViolation { get; set; } //Нарушение целостности
        public bool Accessibility { get; set; } //Нарушение доступности
        public bool PrivacyViolation { get; set; } //Нарушение конфиденциальности

        public Threat(int id, string name,string description, string sourceofthreat, string objectofinfluence,bool privacyViolation, bool integrityViolation, bool accessibility)
        {
            Count++;
            Id = id;
            Name = name;
            Description = description;
            SourceOfThreat = sourceofthreat;
            ObjectOfInfluence = objectofinfluence;
            PrivacyViolation = privacyViolation;
            IntegrityViolation = integrityViolation;
            Accessibility = accessibility;

        }
        public static string FileUpload()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile("https://bdu.fstec.ru/documents/files/thrlist.xlsx", "TableData.xlsx");

            }
           return Parsexlsx();
        }
        public static string Parsexlsx()
        {
            List<string> excelData = new List<string>();
            byte[] bin = File.ReadAllBytes("C:\\Users\\Пушистая булка\\source\\repos\\laba2\\laba2\\bin\\Debug\\TableData.xlsx");
            using (MemoryStream stream = new MemoryStream(bin))
            {
                using (ExcelPackage excelPackage = new ExcelPackage(stream))
                {
                    //loop all worksheets - зациклить все листы
                    foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                    {
                        //loop all rows - цикл всех строк
                        for (int i = worksheet.Dimension.Start.Row+2; i <= worksheet.Dimension.End.Row; i++)
                        {
                            //loop all columns in a row -цикл всех столбцов подряд
                            for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column-2; j++)
                            {
                                //add the cell data to the List - добавить данные ячейки в список
                                if (worksheet.Cells[i, j].Value != null)
                                {
                                    excelData.Add(worksheet.Cells[i, j].Value.ToString());
                                }
                                else
                                {
                                    excelData.Add("-");
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < excelData.Count; i++)
            {
                excelData[i]=excelData[i].Replace("_x000d_", "").Replace("\r\n", "").Replace("\n", "");
            }
                
            List<Threat> thr = new List<Threat>();
            while(excelData.Count!=0)
            {
                
            }
           
            return "";
        }


    }
}
