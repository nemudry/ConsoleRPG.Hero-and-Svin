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
    public class Backpack : Inventory
    {

        public Backpack()
        {
            Name = "Ранец";
            Description = "Ранец - cумка для ношения при себе вещей, \nнадеваемая посредством помочей на спину " +
                "\n(у школьников — для книг и учебных принадлежностей, \nв армии — как часть походного снаряжения). ";
            RareLevel = Rareness.Редкая;
            Price = 500;

            WeaponAndUniform = new List<Equipment>(15);
            TrophyBag = new List<Trophy>(10);
            Buffs = new List<Buff>(10);
            Packs = new List<Inventory>();
            AllItems = new List<Item>();

        }


    }
}
