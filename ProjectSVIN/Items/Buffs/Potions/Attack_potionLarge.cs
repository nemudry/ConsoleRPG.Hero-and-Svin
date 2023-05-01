using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Attack_potionLarge : Potion
    {
        public Attack_potionLarge()
        {
            Name = "Большое зелье силы";
            Description = "Увеличивает силу следующего удара на 50 пунктов";
            Price = 500;
            RareLevel = Rareness.Эпическая;
        }

        public override void UsePotion(Hero hero)
        {
            hero.Attack += 50;
            Color.Green($"Атака героя увеличена на 50 пунктов и составляет {hero.Attack} пункта.");
            Console.WriteLine();
            hero.BuffsHandler += CanselPotion;

        }

        public override void CanselPotion(Hero hero) 
        { 
            hero.Attack -= 50;
            Color.Red($"Атака героя уменьшена на 50 пунктов и составляет {hero.Attack} пункта.");
            Console.WriteLine();
            hero.BuffsHandler -= CanselPotion;
        }

    }
}
