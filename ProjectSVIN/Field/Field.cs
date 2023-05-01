using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Field
    {

        public Hero Hero { get; set; }
        public List<Monster> Monsters { get; set; }

        public List<Pig> Pigs { get; set; }

        public List<Item> GameItems { get; set; }


        public Field(Hero hero, List<Monster> monsters, List<Pig> pigs, List<Item> gameItems)
        {
            Hero = hero;
            Monsters = monsters;
            Pigs = pigs;
            GameItems = gameItems;
        }


        public void GoFindMonstersAndPigs()
        {
            Random random = new Random();
            int odds = random.Next(0, 100);

            string resultHunt = odds switch
            {
                < 5 => "Вы нашли свинью.",
                < 50 => "Вы нашли монстра.",
                _ => "Вы ничего не нашли."

            };
            Color.Red(resultHunt);

            switch (resultHunt)
            {
                case "Вы нашли свинью.": HuntPig(); break;
                case "Вы нашли монстра.": AttackMonsterOrRun(); break;
                default: break;
            };

        }


        public void AttackMonsterOrRun()
        {
            Color.Cyan(Hero.ToString());

            Random random = new Random();
            int odds = random.Next(0, Monsters.Count());
            Monster huntedMonster = (Monster)Monsters[odds].Clone();

            Color.GreenShort($"{huntedMonster} ");
            if (huntedMonster.NameMonsterEffects != null) Color.Red(huntedMonster.NameMonsterEffects);
            Console.WriteLine();

            int answerAttackOrRun;
            do
            {
                Color.Cyan("Напасть на монстра [1] или убежать [2]?");
                Color.Cyan("Изучить монстра [3].");
                int.TryParse(Console.ReadLine(), out answerAttackOrRun);

                if (answerAttackOrRun == 3)
                {
                    Console.WriteLine();
                    huntedMonster.MonsterInfo();
                }

                if (answerAttackOrRun < 1 || answerAttackOrRun > 3)
                {
                    Color.Red("Введенное значение неверно.");
                    Console.WriteLine();
                }

            } while (answerAttackOrRun < 1 || answerAttackOrRun > 2);
            Console.WriteLine();

            if (answerAttackOrRun == 1)
            {
                Console.Clear();
                Battle battle = new Battle(Hero, huntedMonster, GameItems);
                battle.StartBattle();
                if (Hero.StatusHero == Hero.statusHero.БежитИзБитвы) Hero.StatusHero = Hero.statusHero.Жив;
            }

            else
            {
                Console.Clear();
                Color.Red("Вы убежали, поджав хвост.");
                Console.WriteLine();
            }

        }

        public void HuntPig()
        {
            Color.Cyan("Вы раздвинули кустики и увидели вдали хрюшку. Она счастливо копается в грязи. " +
                "Хрюшка вас не заметила.");
            Random random = new Random();
            int odds = random.Next(0, Pigs.Count());
            Pig huntedPig = (Pig)Pigs[odds].Clone();

            Color.Green(huntedPig.ToString());
            Console.WriteLine();

            Hunt hunt = new Hunt(Hero, huntedPig, GameItems);
            hunt.StartHunt();
        }





    }
}
