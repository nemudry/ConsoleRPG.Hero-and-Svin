using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SVINspace.Amulet;

namespace SVINspace
{
    public class BulletproofMonk : Shield
    {
        public BulletproofMonk()
        {
            Name = "Пуленепробиваемый монах";
            Description = "Пуленепробиваемый монах — вид военного защитного снаряжения, \nпредназначенный для отражения атак холодного " +
                "\nили стрелкового оружия. Несмотря на огромное разнообразие форм, \nустройства и расцветок, пуленепробиваемых монахов " +
                "\nопределённо можно разделить на четыре категории: \nпуленепробиваемые монахи лёгкие, пуленепробиваемые монахи круглые, " +
                "\nпуленепробиваемые монахи тяжёлые и большие. ";
            Price = 2000;
            Bonus = 10;
            RareLevel = Rareness.Эпическая;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }

    }
}
