using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Equipment : Item
    {
        public override string Category { get; set; } = "Снаряжение";
        public virtual string EquipmentPlace { get; set; }
        public Hero.raceHero RaceWears { get; set; }
        public Hero.classHero ClassWears { get; set; }


        public int Bonus { get; set; }
        public degreeOfImprovement DegreeOfImprovement { get; set; }
        public enum degreeOfImprovement
        {
            Обычное,
            Улучшенное,
            Совершенное,
            НельзяУлучшить
        }


        public override string ToString()
        {
            return $"Предмет: {Name}; Цена: {Price}.";
        }


    }
}