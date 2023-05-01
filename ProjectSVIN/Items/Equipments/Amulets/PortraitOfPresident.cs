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
    public class PortraitOfPresident : Amulet
    {
        public PortraitOfPresident()
        {
            Name = "Портрет президента";
            Description = "Сей предмет снаряжения можно приобрести в любой сувенирной лавке. \nВроде простенький с первого взгляда портретик \n" +
                "на поле боя приобретает совершенно невероятные свойства. \nМало того, что монстры перестают бить Героя, боясь попасть \n" +
                "загребущей немытой лапой в «несравненного», \nтак иные из особо трусливых тварей пускаются наутёк, \n" +
                "едва завидев суровый взгляд нарисованного «гаранта конституции».";
            Price = 2000;
            Bonus = 20;
            RareLevel = Rareness.Эпическая;
            AmuletImprovementOf = ImprovementOf.Защита;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
