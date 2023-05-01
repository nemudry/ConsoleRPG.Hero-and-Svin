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
    public class GarlicChain : Amulet
    {
        public GarlicChain()
        {
            Name = "Чеснок на цепочке";
            Description = "Данный талисман помогает герою в двух случаях: \n1) Помогает избегать различных вопросов от неугодных торговцев;" +
                "\n2) Не мешает класть пачками монстров с высокими \nобонятельными способностями в радиусе нескольких столбов. Во всех остальных " +
                "\nслучаях он ничем не хуже любых других талисманов. ";
            Price = 700;
            Bonus = 10;
            RareLevel = Rareness.Редкая;
            AmuletImprovementOf = ImprovementOf.Атака;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
