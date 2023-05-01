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
    public class Bare_body : Armor
    {
        public Bare_body()
        {
            Name = "Голый торс";
            Description = "Голый торс - мужчины с обнаженным торсом кричат на весь мир, \nчто если уж в детстве на них не обращали внимания, \n" +
                "то они добьются признания сейчас. И желание раздеться неслучайно \nсвязано с чувством власти, ведь для многих мужчин торс – \n" +
                "способ продемонстрировать силу. Они не уверены в себе, \nно хотят быть любимыми и словно ждут от окружающих похвалы \n" +
                "в адрес пивного живота.";
            Price = 0;
            Bonus = 0;
            RareLevel = Rareness.Обычная;
            DegreeOfImprovement = degreeOfImprovement.НельзяУлучшить;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
