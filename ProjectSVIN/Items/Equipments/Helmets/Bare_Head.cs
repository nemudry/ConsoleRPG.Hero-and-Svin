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
    public class Bare_Head : Helmet
    {
        public Bare_Head()
        {
            Name = "Волосы на голове";
            Description = "Волосы (лат. pili, др.-греч. τρίχες) — придатки кожи, \nпроизводные из эпидермиса, представляющие собой многослойные \n" +
                "нитеообразные структуры из эпителиальных клеток (кератиноциты, \nмеланоциты) ороговевающих по мере удаления из точки роста \n" +
                "в волосяных фолликулах и образующих наружный \nпокров кожи млекопитающих. ";
            Price = 0;
            Bonus = 0;
            RareLevel = Rareness.Обычная;
            DegreeOfImprovement = degreeOfImprovement.НельзяУлучшить;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
