using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Amulet : Equipment

    {
        public override string EquipmentPlace { get; set; } = "Амулет";
        public enum ImprovementOf
        {
            Защита,
            HP,
            Атака,
            Крит
        }

        public ImprovementOf AmuletImprovementOf {get; set;}

        public override string ToString()
        {
            string desc = $"Амулет: {Name}; Цена: {Price}, Бонус {AmuletImprovementOf}: +{Bonus}; " +
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
