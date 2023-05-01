using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    public class TreasureHunting : OutdoorActivity
    {

        public virtual Hero Hero { get; set; }
        public List<Pig> Pigs { get; set; }
        public List<Monster> Monsters { get; set; }

        public TreasureHunting(Hero hero, List<Pig> pigs, List<Monster> monsters, List<Item> gameItems)          
        {
            Hero = hero;
            Pigs = pigs;
            Monsters = monsters;
            GameItems = gameItems;  
        }


        public virtual void StartTreasureHunting()
        {

            Random random = new Random();
            int odds = random.Next(0, 100);

            string resultHunt = odds switch
            {
                < 10 => "Вы откопали свинью.",
                < 40 => "Вы откопали предмет.",
                < 50 => "Вы откопали монстра.",
                _ => "Вы копали - но ничего не нашли."

            };
            Color.Red(resultHunt);

            switch (resultHunt)
            {
                case "Вы откопали свинью.":
                    {
                        odds = random.Next(0, Pigs.Count());
                        Pig huntedPig = (Pig)Pigs[odds].Clone();

                        Color.Green(huntedPig.ToString());
                        Console.WriteLine();
                                                
                        Console.WriteLine("Нажмите на клавишу для продолжения.");
                        Console.ReadKey();

                        Console.Clear();
                        Hunt hunt = new Hunt(Hero, huntedPig, GameItems);
                        hunt.StartHunt();
                        break;
                    }

           

                case "Вы откопали монстра.":
                    {
                        odds = random.Next(0, Monsters.Count());
                        Monster huntedMonster = (Monster)Monsters[odds].Clone();

                        Color.GreenShort($"{huntedMonster} ");
                        if (huntedMonster.NameMonsterEffects != null) Color.Red(huntedMonster.NameMonsterEffects);
                        Console.WriteLine();

                        Console.WriteLine("Нажмите на клавишу для продолжения.");
                        Console.WriteLine();    
                        Console.ReadKey();


                        Console.Clear();
                        Battle battle = new Battle(Hero, huntedMonster, GameItems);
                        battle.StartBattle();
                        if (Hero.StatusHero == Hero.statusHero.БежитИзБитвы) Hero.StatusHero = Hero.statusHero.Жив;
                        break;
                    }

                case "Вы откопали предмет.":
                    {
                        var Items = (from item in GameItems
                                          where item.Price != 0
                                          select item).ToList();


                        odds = random.Next(0, Items.Count());
                        Item huntedItem = Items[odds];

                        Color.GreenShort($"{huntedItem.Name}.");
                        if (huntedItem is Equipment || huntedItem is Inventory || huntedItem is Buff)
                        {
                            Color.Cyan($" {huntedItem}");
                        }
                        if (huntedItem is Trophy item3) Color.Cyan($" Трофей!");
                        Console.WriteLine();

                        Hero.AddItemToInventory(huntedItem);

                        break;
                    }

                default: break;
            };


        }


    }
}
