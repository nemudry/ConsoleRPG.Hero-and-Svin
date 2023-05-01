using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Guildhall
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Quest> QuestBoard { get; set; }

        public List<Item> QuestPrizeItems { get; set; }

        public List<Monster> QuestTargetMonsters { get; set; }

        public override string ToString()
        {
            return $"Ратуша: {Name}.";
        }

        public virtual void GoToGuildhall(DayInGame dayInGame, Hero hero)
        {
            do
            {
                Color.Green($"У героя {hero.Name} в кошельке звенит {hero.Money} монет.");
                Console.WriteLine();

                Color.Cyan(ToString());
                Console.WriteLine(Description);
                Console.WriteLine();


                int answerWhatToDoInGuildhall;
                do
                {
                    Color.Cyan("Выберите действие: ");
                    Console.WriteLine("[1] Взять квест. \n[2] Выполнить квест. \n[3] Отменить взятый квест. \n[-1] Выйти в город.");

                    int.TryParse(Console.ReadLine(), out answerWhatToDoInGuildhall);

                    if (answerWhatToDoInGuildhall == -1)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerWhatToDoInGuildhall < 1 || answerWhatToDoInGuildhall > 3)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }


                } while (answerWhatToDoInGuildhall < 1 || answerWhatToDoInGuildhall > 3);
                Console.Clear();

                switch (answerWhatToDoInGuildhall)
                {
                    case 1: TakeQuest(dayInGame, hero); break;
                    case 2: CompliteQuest(dayInGame, hero); break;
                    case 3: LeaveQuest(dayInGame, hero); break;
                    default: break;
                }
            } while (true);
        }


        public virtual void TakeQuest(DayInGame dayInGame, Hero hero)
        {
            if (hero.ActualHeroQuest != null)
            {
                Color.Red("У вас уже есть квест в работе!");
                Console.WriteLine();
            }

            else
            {
                int answerQuest;
                do
                {
                    Color.Cyan("Выберите квест: ");

                    foreach (Quest quest in QuestBoard)
                    {
                        Console.WriteLine($"[{QuestBoard.IndexOf(quest) + 1}] {quest}");
                        Console.WriteLine();
                    }
                    Console.WriteLine("[-1] Вернуться к выбору действия.");

                    int.TryParse(Console.ReadLine(), out answerQuest);

                    if (answerQuest == -1)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerQuest < 1 || answerQuest > QuestBoard.Count())
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }

                } while (answerQuest < 1 || answerQuest > QuestBoard.Count());
                Console.Clear();

                hero.ActualHeroQuest = QuestBoard[answerQuest - 1];
                hero.ActualHeroQuest.StatusQuest = Quest.statusQuest.ВпроцессеВыполнения;              
                QuestBoard.Remove(hero.ActualHeroQuest);


                Color.Green($"Квест на монстра {hero.ActualHeroQuest.Target.Name} взят!");
                Console.WriteLine();
            }
        }


        public virtual void LeaveQuest(DayInGame dayInGame, Hero hero)
        {
            if (hero.ActualHeroQuest == null)
            {
                Color.Red("У вас нет квеста в работе!");
                Console.WriteLine();
            }

            else
            {
                Color.Green($"Квест на монстра {hero.ActualHeroQuest.Target.Name} отменен!");
                Console.WriteLine();
                dayInGame.DayHeroEventHandler -= hero.ActualHeroQuest.TickTackQuest;
                hero.ActualHeroQuest = null;
            }
        }


        public virtual void CompliteQuest(DayInGame dayInGame, Hero hero)
        {
            if (hero.ActualHeroQuest == null)
            {
                Color.Red("У вас нет квеста в работе!");
                Console.WriteLine();
            }

            else
            {
                if (hero.ActualHeroQuest.StatusQuest != Quest.statusQuest.Выполнено)
                {
                    Color.Red("Квест не выполнен!");
                    Console.WriteLine();
                }

                else
                {
                    Color.Green($"Герой {hero.Name} выполнил квест! Он забирает награду:");
                    Console.WriteLine();

                    Color.Cyan($"{hero.ActualHeroQuest.PrizeItem.Name}. {hero.ActualHeroQuest.PrizeItem}");
                    hero.AddItemToInventory(hero.ActualHeroQuest.PrizeItem);

                    Color.Cyan($"И получает {hero.ActualHeroQuest.PrizeExp} опыта и {hero.ActualHeroQuest.PrizeMoney} монет.");
                    Console.WriteLine();

                    hero.Exp += hero.ActualHeroQuest.PrizeExp;
                    hero.Money += hero.ActualHeroQuest.PrizeMoney;         
                    dayInGame.DayHeroEventHandler -= hero.ActualHeroQuest.TickTackQuest;
                    hero.ActualHeroQuest = null;
                }
            }
        }


    }



}
