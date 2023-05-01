using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Shield : Equipment

    {
        public override string EquipmentPlace { get; set; } = "Щит";
        public override string ToString()
        {
            string desc = $"Щит: {Name}; Цена: {Price}, Бонус защиты: +{Bonus}; " +
                $"Класс: {ClassWears}; Раса: {RaceWears}; Редкость: {RareLevel}.";
            if (DegreeOfImprovement == degreeOfImprovement.Улучшенное ||
                DegreeOfImprovement == degreeOfImprovement.Совершенное)
            {
                desc += $" {DegreeOfImprovement}.";
            }
            return desc;
        }
    }
}

