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
    public class DiamondWoodenSword : Weapon
    {
        public DiamondWoodenSword()
        {
            Name = "Алмазно-деревянный меч";
            Description = "Редкое сочетание двух убойных материй, порождённое сумрачным \nгением неизвестного мебельщика-ювелира. " +
                "\nСостоит из рукояти самого дешёвого алмаза и клинка \nиз редчайшей красной породы дерева гофер. Алмазно - деревянный меч " +
                "\nстанет мощным орудием в руках опытного Героя на пути \nпринуждения монстров к миру. Побочные эффекты: гордыня, галлюцинации, " +
                "\nзлатые глаза.";
            Price = 2000;
            Bonus = 40;
            RareLevel = Rareness.Эпическая;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
