using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Doomsday : OutdoorActivity
    {
        public statusDoomsday StatusDoomsday { get; set; }
        public enum statusDoomsday
        {
            Проиграно,
            Впроцессе,
            Выиграно
        }
                
        public Hero Hero { get; set; }     
        public City City { get; set; }
        public List<Monster> Monsters { get; set; }
        public List<Item> GameItems { get; set; }

        public int KilledMonster { get; set; }

        const int MustToKill = 3;


        public Doomsday(Hero hero, City city, List<Monster> monsters, List<Item> gameItems)
        {
            Hero = hero;
            City = city;
            Monsters = monsters;
            GameItems = gameItems;
            KilledMonster = 0;
            StatusDoomsday = statusDoomsday.Впроцессе;
        }


        public virtual void StartDoomsday()
        {
            Random random = new Random();
            Monster huntedMonster = null;
            do
            {
                int odds = random.Next(0, Monsters.Count());
                huntedMonster = (Monster)Monsters[odds].Clone();
            } while (huntedMonster.Level != Hero.Level);

            Console.Clear();
            Color.Red($"\n************** \n***Внимание*** \n**************.");
            Console.WriteLine();
            Color.Red($"На город наступает толпа монстров {huntedMonster.Name}. Администрация города выдвигает героя {Hero.Name} в качестве защитника города");
            Color.Red($"Отказаться герой {Hero.Name} не смеет.");
            Console.WriteLine();

            Console.WriteLine("Нажмите клавишу для начала сражения");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            do
            {
                Monster doomsdayMonster = (Monster)huntedMonster.Clone();
                AttackMonsterOrFeed(doomsdayMonster);
                if (KilledMonster == MustToKill) StatusDoomsday = statusDoomsday.Выиграно;
            } while (StatusDoomsday == statusDoomsday.Впроцессе);

            ResultDomsday(huntedMonster);




            void AttackMonsterOrFeed(Monster huntedMonster)
            {
                Color.Cyan(Hero.ToString());

                Color.GreenShort($"{huntedMonster} ");
                if (huntedMonster.NameMonsterEffects != null) Color.Red(huntedMonster.NameMonsterEffects);
                Console.WriteLine();

                int answerAttackOrFeed;
                do
                {
                    Color.Cyan("Напасть на монстра [1] или скормить ему отравленную свинью [2]?");
                    Color.Cyan("Сбегать в магазин и затовариться зельями [3].");
                    Color.Cyan("Изучить монстра [4].");
                    int.TryParse(Console.ReadLine(), out answerAttackOrFeed);

                    if (answerAttackOrFeed == 4)
                    {
                        Console.WriteLine();
                        huntedMonster.MonsterInfo();
                    }

                    if (answerAttackOrFeed < 1 || answerAttackOrFeed > 3)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }

                } while (answerAttackOrFeed < 1 || answerAttackOrFeed > 3);
                Console.WriteLine();



                if (answerAttackOrFeed == 1)
                {
                    Console.Clear();
                    Battle battle = new Battle(Hero, huntedMonster, GameItems);
                    battle.StartBattle();
                    if (Hero.StatusHero == Hero.statusHero.Жив) KilledMonster++;
                    else if (Hero.StatusHero == Hero.statusHero.БежитИзБитвы) Hero.StatusHero = Hero.statusHero.Жив;
                    else
                    {
                        StatusDoomsday = statusDoomsday.Проиграно;
                        return;
                    }
                }


                if (answerAttackOrFeed == 2)
                {
                    if (Hero.HeroPigs.Count > 0)
                    {
                        Console.Clear();
                        Color.Green($"Герой {Hero.Name} начинил хрюшку {Hero.HeroPigs[0].Name} по кличке {Hero.HeroPigs[0].Nickname} отравой и запустил к монстру.");
                        Color.Green($"Монстр {huntedMonster.Name} съедает хрюшку и корчится в мучениях!");
                        Color.Green($"Герой {Hero.Name} победил!");
                        Console.WriteLine();

                        Pig killedPig = Hero.HeroPigs[0];
                        foreach (Pigsty pigsty in City.PigstyInCity)
                        {
                            if (pigsty.PigsInPigsty.Count > 0)
                            {
                                foreach (Pig pig in pigsty.PigsInPigsty)
                                {
                                    if (pig == killedPig)
                                    {
                                        pigsty.PigsInPigsty.Remove(killedPig);
                                        break;
                                    }
                                }
                            }

                        }
                        Hero.HeroPigs.Remove(killedPig);
                        if (Hero.ActualHeroPig == killedPig) Hero.ActualHeroPig = null;
                        KilledMonster++;
                    }

                    else
                    {
                        Console.Clear();
                        Color.Red($"У героя {Hero.Name} нет хрюшек в свинарниках. Придется сражаться!");
                        Console.WriteLine();

                    }
                }


                if (answerAttackOrFeed == 3)
                {
                    Console.Clear();
                    City.Magazin.GoToMagazin(Hero);
                }



            }

            void ResultDomsday(Monster huntedMonster)
            {
                if (StatusDoomsday == statusDoomsday.Выиграно)
                {
                    Console.Clear();
                    Color.Cyan($"Жители города чрезвычайно благодарны герою {Hero.Name} за спасение!");

                    int money = 5 * PrizeMoney(huntedMonster);
                    Color.Green($"Жители города передают герою {Hero.Name} {money} монет.");

                    int rank = 0;
                    rank += 3 * huntedMonster.Level;
                    Color.Green($"Рейтинг героя увеличен на {rank} пункта!");
                    Console.WriteLine();
                    Hero.Rank += rank;

                    Console.WriteLine("Нажмите клавишу для продолжения.");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Clear();
                }

                else
                {
                    Console.Clear();
                    Color.Red($"Монстры грабят город и издеваются над жителями.");
                    Color.Cyan($"Жители города разочарованы героем {Hero.Name}!");
                    Console.WriteLine();

                    int rank = 0;
                    rank += 3 * huntedMonster.Level;
                    Color.Red($"Рейтинг героя уменьшен на {rank} пунктов!");
                    Console.WriteLine();
                    Hero.Rank -= rank;

                    Console.WriteLine("Нажмите клавишу для продолжения.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
    }
}
