using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SVINspace
{
    public class Health_poisonMedium : Poison
    {
        const int CountPoison = 3;
        public int AlreadyPoison { get; set; }
        public Health_poisonMedium()
        {
            Name = "Средний яд здоровья";
            Description = "Отравляет соперника, наносит 5 урона каждый ход в течение 3 ходов";
            Price = 200;
            RareLevel = Rareness.Редкая;
        }


        public override void UsePoison(Monster monster)
        {
            monster.BuffsHandler += CanselPoison;
        }


        public override void CanselPoison(Monster monster)
        {
            {
                monster.HP -= 5;
                Color.Green($"Монстр {monster.Name} теряет 5 единицы здоровья от яда.");
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
