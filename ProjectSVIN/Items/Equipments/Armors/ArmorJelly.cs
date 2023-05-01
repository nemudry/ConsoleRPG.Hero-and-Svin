using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class ArmorJelly : Armor
    {
        public ArmorJelly()
        {
            Name = "Бронежеле";
            Description = "Бронежеле — одно из наиболее эффективных и одновременно \nредких защитных снаряжений. Неопытные герои часто принимают \n" +
                "искушенного воителя облаченного в этот высокотехнологичный доспех \nза бомжка, только что вылезшего из бочки с вареньем. \n" +
                "Данный визуально-ароматический эффект обусловлен особой \nэластичностью материала бронежеле, который плотно облегает торс героя, \n" +
                "надежно защищая жизненно важные органы, \nа также плодово-ягодным ароматом и цветом брони. ";
            Price = 7000;
            Bonus = 15;
            RareLevel = Rareness.Легендарная;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }

}

