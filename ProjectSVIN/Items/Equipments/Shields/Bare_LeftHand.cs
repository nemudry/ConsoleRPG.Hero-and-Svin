
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
    public class Bare_LeftHand : Shield
    {
        public Bare_LeftHand()
        {
            Name = "Голая левая рука";
            Description = "Голые руки — верхняя конечность человека и \nнекоторых других животных, орган опорно-двигательного аппарата, \n" +
                "одна из главнейших частей тела. С помощью рук человек \nможет выполнять множество действий, основным из которых является \n" +
                "возможность захватывать предметы.";
            Price = 0;
            Bonus = 0;
            RareLevel = Rareness.Обычная;
            DegreeOfImprovement = degreeOfImprovement.НельзяУлучшить;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
