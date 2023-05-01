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
    public class StraitjacketChainMail : Armor
    {
        public StraitjacketChainMail()
        {
            Name = "Смирительная кольчуга";
            Description = "Защитное снаряжение, часто применяемое для защиты героя от него самого. \nОбладает трехметровыми кольчужными рукавами, " +
                "\nв которых можно надёжно зафиксировать очумелые ручки буйного воителя. \nУ торговцев можно приобрести облачения всех размеров, " +
                "\nа также существует эксклюзивная партия кольчуг розового цвета \nс танцующими единорогами и надписью «Сделай мне хорошо!» на груди.";
            Price = 2000;
            Bonus = 10;
            RareLevel = Rareness.Эпическая;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
