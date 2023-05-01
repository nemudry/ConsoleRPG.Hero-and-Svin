using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Attack_potionSmall : Potion
    {
        public Attack_potionSmall()
        {
            Name = "Маленькое зелье силы";
            Description = "Увеличивает силу следующего удара на 15 пунктов";
            Price = 50;
            RareLevel = Rareness.Обычная;
        }

        public override void UsePotion(Hero hero)
        {
            hero.Attack += 15;
            Color.Green($"Атака героя увеличена на 15 пунктов и составляет {hero.Attack} пункта.");
            Console.WriteLine();
            hero.BuffsHandler += CanselPotion;

        }

        public override void CanselPotion(Hero hero) 
        { 
            hero.Attack -= 15;
            Color.Red($"Атака героя уменьшена на 15 пунктов и составляет {hero.Attack} пункта.");
            Console.WriteLine();
            hero.BuffsHandler -= CanselPotion;
        }

    }
}
