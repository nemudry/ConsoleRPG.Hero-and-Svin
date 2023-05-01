using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Defence_potionMedium : Potion
    {
        const int CountDefence = 3;
        public int AlreadyDefenced { get; set; }
        public Defence_potionMedium()
        {
            Name = "Среднее зелье защиты";
            Description = "Увеличивает защиту героя на 30 пунктов в течение 3 ходов";
            Price = 200;
            RareLevel = Rareness.Редкая;
        }

        public override void UsePotion (Hero hero)
        {
            if (AlreadyDefenced == 0)
            {
                hero.Defence += 30;
                Color.Green($"Защита героя увеличена на 30 пунктов и составляет {hero.Defence} пункта.");
                Console.WriteLine();
            }

            hero.BuffsHandler += CanselPotion;         

        }

        public override void CanselPotion(Hero hero)
        {
            AlreadyDefenced++;

            if (hero.HP < 1 || AlreadyDefenced == CountDefence)
            {
                hero.BuffsHandler -= CanselPotion;
                hero.Defence -= 30;
                Color.Red($"Действие зелья защиты прекращено.");
                Console.WriteLine();
                AlreadyDefenced = 0;
            }
        }
    }
}
