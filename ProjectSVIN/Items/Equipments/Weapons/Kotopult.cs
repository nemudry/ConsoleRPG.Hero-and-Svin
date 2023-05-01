using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Kotopult : Weapon
    {
        public Kotopult()
        {
            Name = "Котопульта";
            Description = "Котопульта — страшное, но очень няшное \nкошкометательное оружие ручного ношения. Котопульта — излюбленное оружие \n" +
                "представителей гринписа, в котором изящно выдержан \nбаланс геройской суровости и няшности. Как известно, \n" +
                "котопульта стреляет боевыми снарядами, назваными в народе \n«котопулями». По информации учёных — в ближайшем времени \n" +
                "все снаряды-«котопули» должны будут пройти сертификацию \nи отвечать по всей строгости закона ГОСТу.";
            Price = 7000;
            Bonus = 120;
            RareLevel = Rareness.Легендарная;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }

}

