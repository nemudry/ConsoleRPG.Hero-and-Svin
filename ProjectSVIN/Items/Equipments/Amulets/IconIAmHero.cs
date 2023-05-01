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
    public class IconIAmHero : Amulet
    {
        public IconIAmHero()
        {
            Name = "Значок «Я - герой!»";
            Description = "Значок «Я — герой!» выполняется из металла или сплава желтого \nили белого цвета (золота, серебра, мифрила и т. д.) " +
                "\nс красной эмалью и представляет собой красную пентаграмму, с лучом, \nнаправленным вниз, на которой размещено изображение " +
                "\nпрофиля героя в шлеме с плюмажем. Над пентаграммой три языка пламени. \nНижний её луч наклонно пересекается лентой " +
                "\nс девизом «Я — герой!». Оформление знака может значительно меняться. \nГильдии, вручающие знаки своим членам, могут вносить " +
                "\nв дизайн элементы гильдийской символики. ";
            Price = 700;
            Bonus = 10;
            RareLevel = Rareness.Редкая;
            AmuletImprovementOf = ImprovementOf.HP;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
