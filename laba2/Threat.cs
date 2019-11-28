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
    public class Threat
    {
        public static int Count { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SourceOfThreat { get; set; } //Внешний/внутренний или нет вообще
        public string ObjectOfInfluence { get; set; } // Объект воздействия
        public string IntegrityViolation { get; set; } //Нарушение целостности
        public string Accessibility { get; set; } //Нарушение доступности
        public string PrivacyViolation { get; set; } //Нарушение конфиденциальности

        public Threat(int id, string name,string description, string sourceofthreat, string objectofinfluence,string privacyViolation, string integrityViolation, string accessibility)
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
       
    }
}
