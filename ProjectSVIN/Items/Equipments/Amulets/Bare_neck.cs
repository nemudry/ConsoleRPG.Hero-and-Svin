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
    public class Bare_neck : Amulet
    {
        public Bare_neck()
        {
            Name = "Голая шея";
            Description = "Голая шея видна у цыпленка сразу после вылупления, \nпоэтому перепутать его сложно с кем-либо. \n" +
                "На шее птенца полностью отсутствует пух. Обусловлено это тем, \nчто перьевых фолликул у цыплят нет (ямочек, из которых могли бы \n" +
                "появиться пух и перья).";
            Price = 0;
            Bonus = 0;
            RareLevel = Rareness.Обычная;
            AmuletImprovementOf = ImprovementOf.HP;
            DegreeOfImprovement = degreeOfImprovement.НельзяУлучшить;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
