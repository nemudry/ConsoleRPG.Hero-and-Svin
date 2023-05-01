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
    public class SheriffStar : Amulet
    {
        public SheriffStar()
        {
            Name = "Звезда шерифа";
            Description = "Звезда шерифа — это очень ценный талисман для героев начальных уровней. \nВ зависимости от характера и заслуг носителя " +
                "\nможет принимать различную форму. Как правило, каждый герой \nокрашивает Звезду в свой любимый цвет при покупке. " +
                "\nВызывает непреодолимое желание постоянно начищать её до блеска. ";
            Price = 50;
            Bonus = 5;
            RareLevel = Rareness.Обычная;
            AmuletImprovementOf = ImprovementOf.Крит;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
