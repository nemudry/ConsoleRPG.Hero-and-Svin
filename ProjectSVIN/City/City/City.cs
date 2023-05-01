using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class City
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public Magazin Magazin { get; set; }

        public Workshop Workshop { get; set; }

        public List<Pigsty> PigstyInCity { get; set; }

        public Guildhall Guildhall { get; set; }

        public int GuildhallTimeToRefresh { get; set; }


        public override string ToString()
        {
            return $"Город: {Name}.";
        }


        public virtual void GoToCity(DayInGame dayInGame, Hero hero)
        {
            do
            {
                int answerWhatToDoInCity;
                do
                {
                    dayInGame.DayInfo();

                    Color.Cyan($"Вы находитесь в славном городе {Name}!");
                    Console.WriteLine(Description);
                    Console.WriteLine();

                    Color.Cyan("Куда пойти: ");
                    Console.WriteLine("[1] Магазин. \n[2] Свинарники. \n[3] Ратуша. \n[4] Мастерская. \n[-1] Выйти из города.");

                    int.TryParse(Console.ReadLine(), out answerWhatToDoInCity);

                    if (answerWhatToDoInCity == -1)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerWhatToDoInCity < 1 || answerWhatToDoInCity > 4)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }


                } while (answerWhatToDoInCity < 1 || answerWhatToDoInCity > 4);
                Console.Clear();

                switch (answerWhatToDoInCity)
                {
                    case 1: dayInGame = dayInGame.TikTak(hero, this); Magazin.GoToMagazin(hero); break;
                    case 2: dayInGame = dayInGame.TikTak(hero, this); ChoosePigsty(hero); break;
                    case 3: dayInGame = dayInGame.TikTak(hero, this); Guildhall.GoToGuildhall(dayInGame, hero); break;
                    case 4: dayInGame = dayInGame.TikTak(hero, this); Workshop.GoToWorkshop(hero); break;
                    default: break;
                }
            } while (true);
        }

        public virtual void ChoosePigsty(Hero hero)
        {
            do
            {
                int answerChoosePigsty;
                do
                {
                    Color.Cyan("Выберите cвинарник: ");
                    foreach (Pigsty pigsty in PigstyInCity)
                    {
                        Console.WriteLine($"[{PigstyInCity.IndexOf(pigsty) + 1}] {pigsty.Name}");
                    }
                    Console.WriteLine("[-1] Вернуться в город.");

                    int.TryParse(Console.ReadLine(), out answerChoosePigsty);

                    if (answerChoosePigsty == -1)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerChoosePigsty < 1 || answerChoosePigsty > PigstyInCity.Count())
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }


                } while (answerChoosePigsty < 1 || answerChoosePigsty > PigstyInCity.Count());                
                Console.Clear();

                PigstyInCity[answerChoosePigsty - 1].GoToPigsty(hero);

            } while (true);
        }



        public virtual void NewDayInCity(City city)
        {
            Color.Cyan($"Товары в магазине обновились. Спешите за покупками!");
            city.RefreshMagazin();
            Console.WriteLine();

            GuildhallTimeToRefresh++;
            if (GuildhallTimeToRefresh == 5)
            {
                Color.Cyan($"В ратуше появились новые квесты!");
                city.RefreshGuildhall();
                Console.WriteLine();
                GuildhallTimeToRefresh = 0;
            }
        }

        public virtual void RefreshMagazin()
        {
            Magazin.AvailableProductsInMagazin.Clear();

            List<Item> availableRareProduct = new List<Item>();
            List<Item> availableEpicProduct = new List<Item>();

            foreach (var item in Magazin.AllProductsInMagazin)
            {
                if (item.RareLevel == Item.Rareness.Обычная) Magazin.AvailableProductsInMagazin.Add(item, 5);
                if (item.RareLevel == Item.Rareness.Редкая) availableRareProduct.Add(item);
                if (item.RareLevel == Item.Rareness.Эпическая) availableEpicProduct.Add(item);                
            }


            Random random = new Random();
            for (int i = 0; i < 3; )
            {
                int item = random.Next(0, availableRareProduct.Count);
                if (!Magazin.AvailableProductsInMagazin.ContainsKey(availableRareProduct[item]))
                {
                    Magazin.AvailableProductsInMagazin.Add(availableRareProduct[item], 1);
                    i++;
                }
            }

            for (int i = 0; i < 1;)
            {
                int item = random.Next(0, availableEpicProduct.Count);
                if (!Magazin.AvailableProductsInMagazin.ContainsKey(availableEpicProduct[item]))
                {
                    Magazin.AvailableProductsInMagazin.Add(availableEpicProduct[item], 1);
                    i++;
                }
            }

        }

        public virtual void RefreshGuildhall()
        {
            Guildhall.QuestBoard.Clear();

            Monster target;
            int amountMonster;
            int timeToComplite;
            int prizeMoney;
            int prizeExp;
            Item prizeItem;
            Random random = new Random();

            while (Guildhall.QuestBoard.Count != Guildhall.QuestBoard.Capacity)
            {
                int i = random.Next(0, Guildhall.QuestTargetMonsters.Count);
                target = Guildhall.QuestTargetMonsters[i];

                amountMonster = random.Next(3, 5);
                timeToComplite = random.Next(10, 21);

                prizeExp = 2 * amountMonster * target.Level switch
                {
                    < 2 => 10,
                    < 3 => 25,
                    < 4 => 50,
                    < 5 => 80,
                    < 6 => 130,
                    < 7 => 200,
                    < 8 => 250,
                    < 9 => 350,
                    _ => 500
                };

                prizeMoney = 4 * amountMonster * target.Level switch
                {
                    < 2 => 25,
                    < 3 => 50,
                    < 4 => 80,
                    < 5 => 130,
                    < 6 => 200,
                    < 7 => 250,
                    < 8 => 350,
                    < 9 => 500,
                    _ => 1000
                };


                var epicItems = (from item in Guildhall.QuestPrizeItems
                                 where item.RareLevel == Item.Rareness.Эпическая
                                 select item).ToList();

                var legendaryItems = (from item in Guildhall.QuestPrizeItems
                                      where item.RareLevel == Item.Rareness.Легендарная
                                      select item).ToList();

                prizeItem = target.Level switch
                {
                    < 4 => epicItems[random.Next(0, epicItems.Count)],
                    < 7 => legendaryItems[random.Next(0, legendaryItems.Count)],
                    _ => legendaryItems[random.Next(0, legendaryItems.Count)]
                };

                Quest quest = new Quest(target, amountMonster, timeToComplite, prizeMoney, prizeExp, prizeItem);
                Guildhall.QuestBoard.Add(quest);
            }
        }

    }
}
