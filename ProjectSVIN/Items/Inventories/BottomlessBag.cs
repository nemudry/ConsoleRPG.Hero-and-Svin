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
    public class BottomlessBag : Inventory
    {

        public BottomlessBag()
        {
            Name = "Бездонная сумка";
            Description = "Один из классических волшебных предметов, «сумка жадности», \nиначе называемая бездонной сумкой " +
                "\nили бездонным мешком — сумка, которая внутри больше, чем снаружи, \nи вес которой остаётся постоянной " +
                "\nвне зависимости от загрузки. Замечательно читерский мешочек. \nСунул слона - нет слона! ";
            RareLevel = Rareness.Легендарная;
            Price = 7000;

            WeaponAndUniform = new List<Equipment>(55);
            TrophyBag = new List<Trophy>(50);
            Buffs = new List<Buff>(30);
            Packs = new List<Inventory>();
            AllItems = new List<Item>();

        }


    }
}
