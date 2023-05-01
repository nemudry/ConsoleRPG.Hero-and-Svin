using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class OutdoorActivity
    {

        public List<Item> GameItems { get; set; }


        public virtual List<Item> PrizeTreasure(Animal animal, List<Item> itemsInGame)
        {

            List<Item> treasures = new List<Item>();
            Random random = new Random();
            int rareOfTreasure;


            var usualItems = (from item in itemsInGame
                              where item.RareLevel == Item.Rareness.Обычная
                              where item.Price !=0
                              select item).ToList();

            var rareItems = (from item in itemsInGame
                             where item.RareLevel == Item.Rareness.Редкая
                             select item).ToList();

            var epicItems = (from item in itemsInGame
                             where item.RareLevel == Item.Rareness.Эпическая
                             select item).ToList();

            var legendaryItems = (from item in itemsInGame
                                  where item.RareLevel == Item.Rareness.Легендарная
                                  select item).ToList();



            int amountOfTreasure = animal.Level switch
            {
                < 4 => 2,
                < 7 => 3,
                _ => 5
            };


            for (int i = 0; i < amountOfTreasure; i++)
            {
                rareOfTreasure = random.Next(0, 101);
                switch (amountOfTreasure)
                {
                    case 2:
                        if (rareOfTreasure < 15)
                        {
                            treasures.Add(rareItems?[random.Next(0, rareItems.Count())]);
                        }
                        else
                        {
                            treasures.Add(usualItems?[random.Next(0, usualItems.Count())]);
                        }
                        break;

                    case 3:
                        if (rareOfTreasure < 10)
                        {
                            treasures.Add(epicItems?[random.Next(0, epicItems.Count())]);
                        }
                        else if (rareOfTreasure >= 10 && rareOfTreasure < 45)
                        {
                            treasures.Add(rareItems?[random.Next(0, rareItems.Count())]);
                        }
                        else
                        {
                            treasures.Add(usualItems?[random.Next(0, usualItems.Count())]);
                        }
                        break;

                    case 5:
                        if (rareOfTreasure < 5)
                        {
                            treasures.Add(legendaryItems?[random.Next(0, legendaryItems.Count())]);
                        }
                        else if (rareOfTreasure >= 5 && rareOfTreasure < 20)
                        {
                            treasures.Add(epicItems?[random.Next(0, epicItems.Count())]);
                        }
                        else if (rareOfTreasure >= 20 && rareOfTreasure < 60)
                        {
                            treasures.Add(rareItems?[random.Next(0, rareItems.Count())]);
                        }
                        else
                        {
                            treasures.Add(usualItems?[random.Next(0, usualItems.Count())]);
                        }
                        break;

                    default: break;
                }
            }
            return treasures;
        }

        public virtual int PrizeExp(Hero hero, Animal animal)
        {

            int amountOfExp = animal.Level switch
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
            if (animal is Pig) amountOfExp = 200;

            double factor = (hero.Level - animal.Level) switch
            {
                < -2 => 2.50,
                < -1 => 1.75,
                < 0 => 1.25,
                < 1 => 1.00,
                < 2 => 0.75,
                < 3 => 0.25,
                _ => 0.10
            };
            if (animal is Pig) factor = 1.0;

            int exp = (int)(amountOfExp * factor);

            return exp;
        }

        public virtual int PrizeMoney(Animal animal)
        {

            int amountOfMoney = animal.Level switch
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
            if (animal is Pig) amountOfMoney = 500;

            int money = (int)(amountOfMoney * (double)(new Random()).Next(40, 141) / 100);

            return money;
        }

    }
}
