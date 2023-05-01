using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Inventory : Item
    {

        public override string Category { get; set; } = "Инвентарь";

        public List<Equipment> WeaponAndUniform { get; set; }

        public List<Trophy> TrophyBag { get; set; }

        public List<Buff> Buffs { get; set; }

        public List<Inventory> Packs { get; set; }

        public List<Item> AllItems { get; set; }


        
        public override string ToString()
        {
            return base.ToString() + $" \nМаксимальное количество слотов для снаряжения: {WeaponAndUniform.Capacity}; " +
                $"\nМаксимальное количество слотов для трофеев: {TrophyBag.Capacity}; " +
                $"\nМаксимальное количество слотов для зелий: {Buffs.Capacity}.";
        }



        public virtual void AnalizeItem (Hero hero)
        {
            do
            {
                int answerGroupAnalize;

                List<Item> allItemsToAnalize = new List<Item>();
                allItemsToAnalize.AddRange(AllItems);
                allItemsToAnalize.Add(hero.HeroAmulet);
                allItemsToAnalize.Add(hero.HeroArmor);
                allItemsToAnalize.Add(hero.HeroHelmet);
                allItemsToAnalize.Add(hero.HeroInventory);
                allItemsToAnalize.Add(hero.HeroShield);
                allItemsToAnalize.Add(hero.HeroWeapon);

                var groupAnalize = (from item in allItemsToAnalize
                                    select item.Category).Distinct().ToList();



                do
                {
                    Console.Clear();
                    Color.Cyan("Выберите отсек: ");
                    foreach (var group in groupAnalize)
                    {
                        Console.WriteLine($"[{groupAnalize.IndexOf(group) + 1}] {group}.");
                    }
                    Console.WriteLine("[-1] Вернуться к выбору снаряжения.");

                    int.TryParse(Console.ReadLine(), out answerGroupAnalize);

                    if (answerGroupAnalize == -1)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerGroupAnalize < 1 || answerGroupAnalize > groupAnalize.Count)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }


                } while (answerGroupAnalize < 1 || answerGroupAnalize > groupAnalize.Count);
                Console.Clear();

                Analize(allItemsToAnalize, groupAnalize[answerGroupAnalize - 1]);

            } while (true);


            void Analize(List<Item> allItemsToAnalize, String category)
            {
                do
                {
                    int answerKindItem;

                    var groupAnalize = (from item in allItemsToAnalize
                                        where item.Category == category
                                        select item).ToList();


                    do
                    {
                        Color.Cyan($"Выберите {category}: ");

                        foreach (Item item in groupAnalize)
                        {
                            Console.WriteLine($"[{groupAnalize.IndexOf(item) + 1}] {item.Name}.");
                        }
                        Console.WriteLine("[-1] Вернуться назад.");

                        int.TryParse(Console.ReadLine(), out answerKindItem);

                        if (answerKindItem == -1)
                        {
                            Console.Clear();
                            return;
                        }


                    } while (answerKindItem < 1 || answerKindItem > groupAnalize.Count());
                    Console.Clear();

                    Item chosenItem = groupAnalize[answerKindItem - 1];

                    Color.Green($"{chosenItem.Name}.");
                    Color.Cyan(chosenItem.ToString());
                    Console.WriteLine(chosenItem.Description);
                    Console.WriteLine();

                } while (true);
            }
        }


        public virtual void InventoryInfo(Hero hero)
        {
            Color.Green($"У героя {hero.Name} в кошельке звенит {hero.Money} монет.");
            Console.WriteLine();

            Color.Cyan("Вид инвентаря:");
            Console.WriteLine(hero.HeroInventory);
            Console.WriteLine();

            Color.Cyan("Заполненность инвентаря:");
            Console.WriteLine($"Cумка для снаряжения: {WeaponAndUniform.Count}/{WeaponAndUniform.Capacity}. " +
                $"\nCумка для трофеев: {TrophyBag.Count}/{TrophyBag.Capacity}. " +
                $"\nCумка для зелий: {Buffs.Count}/{Buffs.Capacity}.");
            Console.WriteLine();


            Color.Cyan("Статы героя:");
            Console.WriteLine(hero);
            Console.WriteLine($"Уровень: {hero.Level}; Опыта: {hero.Exp}; Ранк: {hero.Rank}.");
            Console.WriteLine();

            Color.Cyan("Надетые вещи героя:");
            Console.WriteLine(hero.HeroWeapon);
            Console.WriteLine(hero.HeroShield);
            Console.WriteLine(hero.HeroArmor);
            Console.WriteLine(hero.HeroHelmet);
            Console.WriteLine(hero.HeroAmulet);
            Console.WriteLine();
        }
    }
}