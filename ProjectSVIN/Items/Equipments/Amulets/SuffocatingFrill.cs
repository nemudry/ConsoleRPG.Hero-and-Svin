using SVINspace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class SuffocatingFrill : Amulet
    {
        public SuffocatingFrill()
        {
            Name = "Душащее жабо";
            Description = "Душащее жабо (друидиш. jabot — «зоб птицы») — деталь платья или рубашки, \nтакже разновидность воротника. " +
                "\nИзготавливается из ткани или кружев в виде оборки. \nЯвляется прекрасным украшением и незаменимым элементом снаряжения. " +
                "\nПо легенде первое душащее жабо задумано членами одной \nочень прижимистой на расходы гильдии, как символ их жадности и скупости. " +
                "\nНесмотря на то, что душащее жабо так и не стало их символом, \nшколу жизни в гильдии оно прошло суровую. И навсегда запомнило, " +
                "\nчто расходы надо резать. Вместе с теми, кто их создаёт. ";
            Price = 50;
            Bonus = 5;
            RareLevel = Rareness.Обычная;
            AmuletImprovementOf = ImprovementOf.Защита;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
