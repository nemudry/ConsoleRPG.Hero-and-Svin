using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Defence_poisonMedium : Poison
    {
        const int CountPoison = 3;
        public int AlreadyPoison { get; set; }
        public Defence_poisonMedium()
        {
            Name = "Средний яд уязвимости";
            Description = "Отравляет соперника, уменьшает защиту на 15 в течение 3 ходов";
            Price = 200;
            RareLevel = Rareness.Редкая;
        }

        public override void UsePoison(Monster monster)
        {

            monster.Defence -= 15;
            Color.Green($"Защита монстра {monster.Name} уменьшена на 15 пунктов и составляет {monster.Defence} пункта. Действует в течение 3 ходов.");
            Console.WriteLine();

            monster.BuffsHandler += CanselPoison;

        }


        public override void CanselPoison(Monster monster)
        {
            AlreadyPoison++;
            if (monster.HP < 1 || AlreadyPoison == CountPoison)
            {
                monster.Defence += 15;
                monster.BuffsHandler -= CanselPoison;
                Color.Red($"Действие яда уязвимости прекращено.");
                Console.WriteLine();
                AlreadyPoison = 0;
            }
        }

    }
}
