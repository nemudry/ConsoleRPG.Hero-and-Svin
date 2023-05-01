using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class IroningBoard : Shield
    {
        public IroningBoard()
        {
            Name = "Гладильная доска";
            Description = "Гладильная доска — эффективное и простое защитное средство. \nИзначально создавалось для бытовых целей, \n" +
                "но ввиду своей практичности используется и в военной промышленности. \nСпособность раскладываться компенсирует громоздкую конструкцию. \n" +
                "Высокие боевые характеристики щита первыми заметили сельчанки: \nво время нападений монстров на деревни. \n" +
                "Как ни странно, гладильную доску они использовали \nтолько в качестве активного щита: били ею монстров по головам. \n" +
                "И это оказывалось довольно эффективно. ";
            Price = 50;
            Bonus = 2;
            RareLevel = Rareness.Обычная;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }

}

