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
    public class UraniumKeychain : Amulet
    {
        public UraniumKeychain()
        {
            Name = "Урановый брелок";
            Description = "Однажды чей-то герой (или героиня) в поисках развлечения, \nну, или чтобы руки занять, занимался (занималась) крафтингом. " +
                "\nТо есть брал(а) две ненужные вещи и делал(а) из них одну, обычно тоже ненужную, \nтаким образом сокращая число ненужных вещей " +
                "\nво вселенной. Но на этот раз после соединения обычного \nбрелка-висюльки из ближайшего магазина и случайно подвернувшегося куска урана " +
                "\nу нашего героя (или героини, как мы уже упоминали) получился Урановый Брелок. \nВещь получилась достаточно красивой и вполне пригодной " +
                "\nв качестве талисмана. ";
            Price = 7000;
            Bonus = 30;
            RareLevel = Rareness.Легендарная;            
            AmuletImprovementOf = ImprovementOf.HP;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
