using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IThiefEffects : IClassEffects
    {
        const int CountThiefEnhancing = 3;
        int AlreadyTimeThiefEnhancing { get; set; }

        public const int ManaThiefHit = 30;
        public const int ManaThiefEnhancing = 90;
        public const int ManaSuperThiefRun = 150;



        void UseThiefHit(Hero hero, Monster monster)
        {
            if (hero.ClassEffect == Hero.heroEffect.МожноЮзать)
            {
                int damage = monster.Defence / 3;
                Color.Green($"Герой незаметно расставил ловушку, монстр {monster.Name} наступил на нее и получает {damage} урона.");
                Console.WriteLine();

                hero.ClassEffect = Hero.heroEffect.НавыкУжеИспользуется;
                monster.HP -= damage;
                hero.ClassEffect = Hero.heroEffect.МожноЮзать;
            }
            else
            {
                Color.Red($"Нельзя использовать несколько навыков одновременно!");
                Console.WriteLine();
            }
        }


        void UseThiefEnhancing(Hero hero)
        {
            if (hero.ClassEffect == Hero.heroEffect.МожноЮзать)
            {
                Color.Green($"Герой использует навык вора - ночное зрение. " +
                $"\nВероятность критического урона героя {hero.Name} будет увеличена на {(int)(hero.MainFeatures.Crit * 0.50)} пункта. Действует в течение 3 ходов.");
                Console.WriteLine();

                hero.ClassEffect = Hero.heroEffect.НавыкУжеИспользуется;
                if (AlreadyTimeThiefEnhancing == 0)
                {
                    hero.Crit += (int)(hero.MainFeatures.Crit * 0.50);
                    hero.BuffsHandler += CanselThiefEnhancing;
                }
            }

            else
            {
                Color.Red($"Нельзя использовать несколько навыков одновременно!");
                Console.WriteLine();
            }
        }
        void CanselThiefEnhancing(Hero hero)
        {

            AlreadyTimeThiefEnhancing++;
            if (hero.StatusHero != Hero.statusHero.Битва || hero.HP < 1 || AlreadyTimeThiefEnhancing == CountThiefEnhancing)
            {
                hero.Crit -= (int)(hero.MainFeatures.Crit * 0.50);
                hero.BuffsHandler -= CanselThiefEnhancing;
                Color.Red($"Действие навыка прекращено.");
                Console.WriteLine();

                AlreadyTimeThiefEnhancing = 0;
                hero.ClassEffect = Hero.heroEffect.МожноЮзать;
            }
        }


        void UseSuperThiefRun(Hero hero)
        {
            if (hero.ClassEffect == Hero.heroEffect.МожноЮзать)
            {
                Color.Green($"Герой использует навык вора - дымовая шашка. Монстр ничего не видит - и герой сбегает. ");
                Console.WriteLine();
                hero.ClassEffect = Hero.heroEffect.НавыкУжеИспользуется;
                hero.StatusHero = Hero.statusHero.БежитИзБитвы;
                hero.ClassEffect = Hero.heroEffect.МожноЮзать;
            }

            else
            {
                Color.Red($"Нельзя использовать несколько навыков одновременно!");
                Console.WriteLine();
            }
        }


    }
}
