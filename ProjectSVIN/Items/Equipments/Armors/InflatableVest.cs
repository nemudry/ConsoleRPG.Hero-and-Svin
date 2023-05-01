﻿using SVINspace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class InflatableVest : Armor
    {
        public InflatableVest()
        {
            Name = "Надувной жилет";
            Description = "«Не украшает, не защищает. Неудобен. \nНатирает везде, где может натереть. Не подгоняется по размеру. " +
                "\nПри получении малейшего повреждения свистит \nпротивным голосом Монстра Женского Рода. Не имеет карманов. " +
                "\nСтоит как весь твой дневной заработок» — такую характеристику \nспасательному жилету мог бы дать честный торговец, " +
                "\nесли бы он вдруг появился. Никакого отношения \nк резиновым изделиям спасательный жилет не имеет, " +
                "\nсхоже разве что невероятно низкое качество. Изготавливается \nиз сброшенной шкуры Надуванчика с помощью многоножниц " +
                "\n(для скорости и массовости), клея и фломастеров: \nобрезкам шкуры придаётся необходимая форма по шаблону, " +
                "\nкуски наскоро склеиваются, а чуть подсохшее изделие раскрашивается. \nНужно отметить, что шкура Надуванчика " +
                "\nввиду крайне низких потребительских характеристик нигде больше не используется, \nтак как не годится даже на туалетный папирус.";
            Price = 50;
            Bonus = 2;
            RareLevel = Rareness.Обычная;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}