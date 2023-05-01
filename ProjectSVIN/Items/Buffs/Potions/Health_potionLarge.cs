using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Health_potionLarge : Potion
    {
        public Health_potionLarge()
        {
            Name = "Большое зелье здоровья";
            Description = "Восстанавливает 100 HP";
            Price = 500;
            RareLevel = Rareness.Эпическая;
        }

        public override void UsePotion (Hero hero)
        {
            hero.HP += 100;
            Color.Green($"Здоровье героя увеличено на 100 пунктов и составляет {hero.HP} пункта.");
            Console.WriteLine();
        }

    }
}
