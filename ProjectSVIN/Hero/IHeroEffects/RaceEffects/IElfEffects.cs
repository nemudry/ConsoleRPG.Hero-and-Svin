using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IElfEffects : IRaceEffects
    {        

        const int CountAttackEnhancing = 3;
        int AlreadyTimeAttackEnhancing { get; set; }


        void UseAttackEnhancing(Hero hero)
        {
            if (hero.RaceEffect == Hero.heroEffect.МожноЮзать)
            {
                if (AlreadyTimeAttackEnhancing == 0)
                {
                    hero.Attack += (int)(hero.MainFeatures.Attack * 0.20);
                    Color.Green($"Герой использует древнюю силу эльфийских предков - хлещет себя по заду, чтобы разъяриться!" +
                       $"\nАтака героя {hero.Name} увеличена на {(int)(hero.MainFeatures.Attack * 0.20)} пункта. Действует в течение 3 ходов.");
                    Console.WriteLine();
                    hero.RaceEffect = Hero.heroEffect.НавыкУжеИспользуется;
                    hero.BuffsHandler += CanselAttackEnhancing;
                    
                }
            }
            else
            {
                Color.Red($"Нельзя использовать древнюю силу эльфийских предков больше одного раза за битву.");
                Console.WriteLine();
            }

        }
        void CanselAttackEnhancing(Hero hero)
        {

            AlreadyTimeAttackEnhancing++;
            if (hero.StatusHero != Hero.statusHero.Битва || hero.HP < 1 || AlreadyTimeAttackEnhancing == CountAttackEnhancing)
            {
                hero.Attack -= (int)(hero.MainFeatures.Attack * 0.20);
                hero.BuffsHandler -= CanselAttackEnhancing;
                Color.Red($"Действие силы эльфийских предков прекращено.");
                Console.WriteLine();
                AlreadyTimeAttackEnhancing = 0;
            }


        }
    }
}
