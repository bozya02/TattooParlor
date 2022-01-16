using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SpecialRequest     //Обязательно исправить: поля класса публичны, отсутсвует конструктор (Мясников, Сематкин)
    {
        public int IdRequest { get; set; }
        public int IdUser { get; set; }
        public DateTime Date { get; set; }
        public int IdTattoo { get; set; }
        public int IdBodyPart { get; set; }
        public string TattooName => DataAccess.GetTattoo(IdTattoo).Name;
        public string TattooImage => DataAccess.GetTattoo(IdTattoo).Image;
        public string BodyPartName => DataAccess.GetBodyPart(IdBodyPart).Name;
    }
}
