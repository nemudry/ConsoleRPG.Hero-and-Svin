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
    public class Bag: Inventory
    {
                
        public Bag()
        {
            Name = "Холщевый мешок";
            Description = "Холщовый мешочек применяют для самых разных целей. \nОн входит в состав некоторых крестильных наборов для хранения рубашки, " +
                "\nпеленки и других принадлежностей. В таких мешочках \nпродаются сборы трав, украшения, руны. Кто-то покупает их " +
                "\nпросто для упаковки подарков или для интерьера.";
            RareLevel = Rareness.Обычная;
            Price = 0;

            WeaponAndUniform = new List<Equipment>(10);
            TrophyBag = new List<Trophy>(5);
            Buffs = new List<Buff>(5); 
            Packs = new List<Inventory>();
            AllItems = new List<Item>();


        }


    }
}
