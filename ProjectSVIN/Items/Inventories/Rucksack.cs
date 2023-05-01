using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class Rucksack : Inventory
    {

        public Rucksack()
        {
            Name = "Туристический рюкзак";
            Description = "Предназначен для длительных походов. \nОн вмещает все, что нужно людям, отрезанным на дни и недели " +
                "\nот цивилизации – одежду, кемпинговый спальный мешок, \nпалатку, туристический шатер и коврик, банки с консервами " +
                "\nи пакеты с крупами, покрывало.";
            RareLevel = Rareness.Эпическая;
            Price = 2000;

            WeaponAndUniform = new List<Equipment>(25);
            TrophyBag = new List<Trophy>(20);
            Buffs = new List<Buff>(15);
            Packs = new List<Inventory>();
            AllItems = new List<Item>();

        }


    }
}
