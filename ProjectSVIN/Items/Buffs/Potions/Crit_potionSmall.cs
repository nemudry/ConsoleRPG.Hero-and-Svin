using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Crit_potionSmall : Potion
    {
        public Crit_potionSmall()
        {
            Name = "Маленькое зелье критического удара";
            Description = "Единоразово увеличивает шанс критического удара на 15 пунктов";
            Price = 50;
            RareLevel = Rareness.Обычная;
        }

        public override void UsePotion(Hero hero)
        {
            hero.Crit += 15;
            Color.Green($"Шанс критического удара героя увеличен на 15 пунктов и составляет {hero.Crit}%.");
            Console.WriteLine();
            hero.BuffsHandler += CanselPotion;

        }

        public override void CanselPotion(Hero hero) 
        { 
            hero.Crit -= 15;
            Color.Red($"Шанс критического удара героя уменьшен на 15 пунктов и составляет {hero.Crit}%.");
            Console.WriteLine();
            hero.BuffsHandler -= CanselPotion;
        }

    }
}
