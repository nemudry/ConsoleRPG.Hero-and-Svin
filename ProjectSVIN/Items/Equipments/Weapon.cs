using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Weapon : Equipment

    {
        public override string EquipmentPlace { get; set; } = "Оружие";
        public override string ToString()
        {
            string desc = $"Оружие: {Name}; Цена: {Price}, Бонус атаки: +{Bonus}; " +
                $"Класс: {ClassWears}; Раса: {RaceWears}; Редкость: {RareLevel}.";
            if(DegreeOfImprovement == degreeOfImprovement.Улучшенное ||
                DegreeOfImprovement == degreeOfImprovement.Совершенное)
            {
                desc += $" {DegreeOfImprovement}.";
            }
            return desc;
        }
    }
}
