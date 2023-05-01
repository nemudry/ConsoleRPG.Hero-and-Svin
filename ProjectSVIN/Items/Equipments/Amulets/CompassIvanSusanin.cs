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
    public class CompassIvanSusanin : Amulet
    {
        public CompassIvanSusanin()
        {
            Name = "Компас «Иван Сусанин»";
            Description = "Компас «Иван Сусанин» — совсем нередкая вещь. Это весьма \nценный талисман, позволяющий бродить по самым дальним уголкам " +
                "\nбез боязни заблудиться. Ибо этот компас — самый лучший компас в мире — \nведёт так же верно, как и знаменитый Иван Сусанин. " +
                "\nИногда, в качестве бесплатного бонуса к такой ценной и незаменимой вещи, \nторговцы предлагают дырявые носки. Особенно эффективен " +
                "\nв сочетании с магнитом или большим топором, подложенным под него. ";
            Price = 2000;
            Bonus = 20;
            RareLevel = Rareness.Эпическая;
            AmuletImprovementOf = ImprovementOf.Атака;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
