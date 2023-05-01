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
    public class ChainMailOfPaperClips : Armor
    {
        public ChainMailOfPaperClips()
        {
            Name = "Кольчуга канцелярских скрепок";
            Description = "В незапамятные времена, когда большинство офисных работников \nещё были одичалыми и ходили в шкурах первобытных монстров, " +
                "\nуже существовали те, кто старался сделать свою жизнь более комфортной, \nуютной и безопасной. Пойдя по пути прогресса, " +
                "\nони начали изобретать орудия труда и обороны урожая \nот возможных посягательств товарищей по несчастью. До сих пор не ясно " +
                "\nчто послужило началом всеобщего помешательства на доспехах \nсамых разных форм и размеров, однако большинство археологов-протестантов " +
                "\nуверены, что именно развитие канцелярии стало причиной \nрезкого увеличения оборонительного потенциала первых героев.";
            Price = 700;
            Bonus = 5;
            RareLevel = Rareness.Редкая;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
