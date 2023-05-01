using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IAttackСursing : IMonsterСursing
    {

        const int CountAttackСursing = 3;
        int AlreadyTimeAttackСursing { get; set; }
        bool IsAttackСursing { get; set; }


        void UseAttackСursing(Hero hero)
        {
            if (AlreadyTimeAttackСursing == 0)
            {
                Random random = new Random();
                int ds = random.Next(0, 100);
                if (ds < 15)
                {
                    hero.Attack -= (int)(hero.MainFeatures.Attack * 0.20);
                    Color.Red($"Монстр взбешен. Он использует древнюю силу предков - изнуряет героя саркастическими шутками о его оружии и умении сражаться. " +
                       $"\nАтака героя {hero.Name} уменьшена на {(int)(hero.MainFeatures.Attack * 0.20)} пункта. Действует в течение 3 ходов.");
                    Console.WriteLine();
                    hero.BuffsHandler += CanselAttackСursing;
                    IsAttackСursing = true;
                }
            }
        }

        void CanselAttackСursing(Hero hero)
        {
            if (IsAttackСursing)
            {
                AlreadyTimeAttackСursing++;
                if (hero.StatusHero != Hero.statusHero.Битва || hero.HP < 1 || AlreadyTimeAttackСursing == CountAttackСursing)
                {
                    hero.Attack += (int)(hero.MainFeatures.Attack * 0.20);
                    hero.BuffsHandler -= CanselAttackСursing;
                    Color.Red($"Действие проклятия прекращено.");
                    Console.WriteLine();
                    AlreadyTimeAttackСursing = 0;
                    IsAttackСursing = false;
                }
            }
        }

    }
}
