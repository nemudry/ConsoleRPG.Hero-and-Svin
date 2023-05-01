using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IDefenceСursing : IMonsterСursing
    {

        const int CountDefenceСursing = 3;
        int AlreadyTimeDefenceСursing { get; set; }
        bool IsDefenceСursing { get; set; }


        void UseDefenceСursing(Hero hero)
        {
            if (AlreadyTimeDefenceСursing == 0)
            {
                Random random = new Random();
                int ds = random.Next(0, 100);
                if (ds < 55)
                {
                    hero.Defence -= (int)(hero.MainFeatures.Defence * 0.20);
                    Color.Red($"Монстр взбешен. Он использует древнюю силу предков - поет колыбельную песню с усыпляющим эффектом! " +
                       $"\nЗащита героя {hero.Name} уменьшена на {(int)(hero.MainFeatures.Defence * 0.20)} пункта. Действует в течение 3 ходов.");
                    Console.WriteLine();
                    hero.BuffsHandler += CanselDefenceСursing;
                    IsDefenceСursing = true;
                }
            }
        }
        void CanselDefenceСursing(Hero hero)
        {
            if (IsDefenceСursing)
            {
                AlreadyTimeDefenceСursing++;
                if (hero.StatusHero != Hero.statusHero.Битва || hero.HP < 1 || AlreadyTimeDefenceСursing == CountDefenceСursing)
                {
                    hero.Defence += (int)(hero.MainFeatures.Defence * 0.20);
                    hero.BuffsHandler -= CanselDefenceСursing;
                    Color.Red($"Действие проклятия прекращено.");
                    Console.WriteLine();
                    AlreadyTimeDefenceСursing = 0;
                    IsDefenceСursing = false;
                }
            }
        }

    }
}
