using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Health_potionSmall : Potion
    {
        public Health_potionSmall()
        {
            Name = "Маленькое зелье здоровья";
            Description = "Восстанавливает 20 HP";
            Price = 50;
            RareLevel = Rareness.Обычная;
        }

        public override void UsePotion (Hero hero)
        {
            hero.HP += 20;
            Color.Green($"Здоровье героя увеличено на 20 пунктов и составляет {hero.HP} пункта.");
            Console.WriteLine();
        }

    }
}
