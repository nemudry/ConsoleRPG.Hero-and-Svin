using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IHealthСursing : IMonsterСursing
    {

        const int CountHealthСursing = 3;
        int AlreadyTimeHealthСursing { get; set; }
        bool IsHealthСursing { get; set; }


        void UseHealthСursing(Hero hero)
        {
            if (AlreadyTimeHealthСursing == 0)
            {
                Random random = new Random();
                int ds = random.Next(0, 100);
                if (ds < 15)
                {
                    Color.Red($"Монстр взбешен. Он использует древнюю силу предков - ядовитую отдышку. " +
                        $"\nГерой {hero.Name} теряет {(int)(hero.MainFeatures.HP * 0.05)} единиц здоровья в течение 3 ходов");
                    Console.WriteLine();
                    hero.BuffsHandler += CanselHealthСursing;
                    IsHealthСursing = true;
                }
            }
        }

        void CanselHealthСursing(Hero hero)
        {
            if (IsHealthСursing)
            {
                hero.HP -= (int)(hero.MainFeatures.HP * 0.05);
                Color.Red($"Герой {hero.Name} теряет {(int)(hero.MainFeatures.HP * 0.05)} единиц здоровья.");
                Console.WriteLine();

                
                AlreadyTimeHealthСursing++;
                if (hero.StatusHero != Hero.statusHero.Битва || hero.HP < 1 || AlreadyTimeHealthСursing == CountHealthСursing)
                {
                    hero.BuffsHandler -= CanselHealthСursing;
                    Color.Red($"Действие проклятия прекращено.");
                    Console.WriteLine();
                    AlreadyTimeHealthСursing = 0;
                    IsHealthСursing = false;
                }
            }
        }

    }
}
