using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Health_poisonSmall : Poison
    {
        const int CountPoison = 3;
        public int AlreadyPoison { get; set; }
        public Health_poisonSmall()
        {
            Name = "Маленький яд здоровья";
            Description = "Отравляет соперника, наносит 3 урона каждый ход в течение 3 ходов";
            Price = 50;
            RareLevel = Rareness.Обычная;
        }

        public override void UsePoison(Monster monster)
        {
            monster.BuffsHandler += CanselPoison;
        }


        public override void CanselPoison(Monster monster)
        {
            {
                monster.HP -= 3;
                Color.Green($"Монстр {monster.Name} теряет 3 единицы здоровья от яда.");
                Console.WriteLine();

                AlreadyPoison++;
                if (monster.HP < 1 || AlreadyPoison == CountPoison)
                {
                    monster.BuffsHandler -= CanselPoison;
                    Color.Red($"Действие яда прекращено.");
                    Console.WriteLine();
                    AlreadyPoison = 0;
                }
            }
        }



    }
}
