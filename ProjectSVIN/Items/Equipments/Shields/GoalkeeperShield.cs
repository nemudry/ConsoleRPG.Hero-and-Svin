
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
    public class GoalkeeperShield : Shield
    {
        public GoalkeeperShield()
        {
            Name = "Вратарский щиток";
            Description = "Артефакт, попавший в мир через таинственные врата, точнее, \nчерез защитников этих врат, Ледяных Гигантов, " +
                "\nкоторые не пропускали в уютный мирок демонов Пылающего легиона \nи ловили тяжёлые предметы, которые те пытались закинуть, " +
                "\nвпрочем, не всегда успешно. Понятно, что на такой тяжёлой службе \nих снаряжение быстро изнашивалось, и Гиганты " +
                "\nпросто выбрасывали его подальше, не покидая пост. \nА что гиганту — щиток, то герою — целый щит, за которым можно спрятаться стоя. " +
                "\nДаже поношенные, эти щитки служат хорошую службу героям младших и средних уровней, \nпомогая отбить удары самых свирепых монстров.";
            Price = 700;
            Bonus = 5;
            RareLevel = Rareness.Редкая;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
