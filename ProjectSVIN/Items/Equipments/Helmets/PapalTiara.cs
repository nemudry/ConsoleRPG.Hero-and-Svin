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
    public class PapalTiara : Helmet
    {
        public PapalTiara()
        {
            Name = "Папская тиара";
            Description = "Неизвестно, чем думают герои, покупающие тиары у торговцев \nсомнительной добропорядочности. В таком обмундировании " +
                "\nбудет удобно воевать только при приведении головы к форме идеального яйца, \nи только тогда этот покрытый облупившейся позолотой " +
                "\nи разноцветными стразиками псевдошлем не слетит с головы героя. \nНо изо дня в день всё новые герои покупаются на призывные вопли " +
                "\nторговцев, обещающих уникальное дополнение к вашему образу. \nВ любом случае, герой, надевший тиару, будет чувствовать себя особой, " +
                "\nприближённой к богу, и это несоизмеримо потешит его ЧСВ. \nЕсли, конечно, она не слетит с его головы во время боя и не ударит " +
                "\nпо неприкрытой бронесапогом ноге. ";
            Price = 2000;
            Bonus = 10;
            RareLevel = Rareness.Эпическая;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
