using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Magazin
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Item> AllProductsInMagazin { get; set; }

        public Dictionary<Item, int> AvailableProductsInMagazin { get; set; }

        public override string ToString()
        {
            return $"Магазин: {Name}.";
        }


        public virtual void GoToMagazin(Hero hero)
        {
            do
            {
                int answerWhatToDoInMagazin;
                do
                {
                    Color.Cyan("Выберите действие: ");
                    Console.WriteLine("[1] Купить товар. \n[2] Продать товар. \n[3] Открыть инвентарь. \n[-1] Выйти в город.");

                    int.TryParse(Console.ReadLine(), out answerWhatToDoInMagazin);

                    if (answerWhatToDoInMagazin == -1)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerWhatToDoInMagazin < 1 || answerWhatToDoInMagazin > 3)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }


                } while (answerWhatToDoInMagazin < 1 || answerWhatToDoInMagazin > 3);                
                Console.Clear();

                switch (answerWhatToDoInMagazin)
                {
                    case 1: BuyProduct(hero); break;
                    case 2: SellProduct(hero); break;
                    case 3: hero.OpenInventory(); break;
                    default: break;
                }
            } while (true);
        }


        public virtual void SellProduct(Hero hero)
        {
            do
            {
                hero.HeroInventory.InventoryInfo(hero);

                if (!ChooseSellProduct()) return;

            } while (true);


            bool ChooseSellProduct()
            {
                do
                {
                    int answerProductToSell;
                    var productToSell = (from item in hero.HeroInventory.AllItems
                                         where item.Price != 0
                                         select item).ToList();

                    do
                    {
                        Color.Cyan("Выберите товар для продажи: ");

                        foreach (Item item in productToSell)
                        {
                            Console.WriteLine($"[{productToSell.IndexOf(item) + 1}] {item.Name}.");
                        }
                        Console.WriteLine("[-1] Вернуться к выбору действия.");
                        Console.WriteLine("[-2] Продать все трофеи.");
                        Console.WriteLine("[-3] Продать все дешевые вещи.");

                        int.TryParse(Console.ReadLine(), out answerProductToSell);

                        if (answerProductToSell == -1)
                        {
                            Console.Clear();
                            return false;
                        }

                        if (answerProductToSell == -2)
                        {
                            Console.Clear();

                            var trophyProduct = (from item in productToSell
                                                 where item.Category == "Трофей"
                                                 select item).ToList();

                            foreach (Item item in trophyProduct)
                            {
                                Color.Green($"Товар {item.Name} продан за {item.Price} монет.");
                                hero.DeleteItemFromInventory(item);
                                hero.Money += item.Price;
                            }
                            Console.WriteLine();
                            return true;
                        }


                        if (answerProductToSell == -3)
                        {
                            Console.Clear();

                            var trophyAndEquipProduct = (from item in productToSell
                                                         where item.Category != "Зелье"
                                                         where item.RareLevel == Item.Rareness.Обычная || item.RareLevel == Item.Rareness.Редкая
                                                         select item).ToList();


                            var buffProduct = (from item in productToSell
                                               where item.Category == "Зелье"
                                               where item.RareLevel == Item.Rareness.Обычная
                                               select item).ToList();

                            trophyAndEquipProduct.AddRange(buffProduct);

                            foreach (Item item in trophyAndEquipProduct)
                            {
                                Color.Green($"Товар {item.Name} продан за {item.Price} монет.");
                                hero.DeleteItemFromInventory(item);
                                hero.Money += item.Price;
                            }
                            Console.WriteLine();
                            return true;
                        }


                        if (answerProductToSell < 1 || answerProductToSell > productToSell.Count())
                        {
                            Color.Red("Введенное значение неверно.");
                            Console.WriteLine();
                        }

                    } while (answerProductToSell < 1 || answerProductToSell > productToSell.Count());
                    Console.WriteLine();
                    Console.Clear();

                    Item sellItem = productToSell[answerProductToSell - 1];



                    Color.Green($"{sellItem.Name}.");
                    Color.Cyan(sellItem.ToString());
                    Console.WriteLine(sellItem.Description);
                    Console.WriteLine();
                    do
                    {
                        Color.Cyan($"Продать товар?: \n[1] Да \n[2] Нет");

                        int.TryParse(Console.ReadLine(), out answerProductToSell);

                        if (answerProductToSell < 1 || answerProductToSell > 2)
                        {
                            Color.Red("Введенное значение неверно.");
                            Console.WriteLine();
                        }

                    } while (answerProductToSell < 1 || answerProductToSell > 2);
                    Console.Clear();


                    if (answerProductToSell == 1)
                    {

                        Color.Green($"Товар {sellItem.Name} продан за {sellItem.Price} монет.");
                        Console.WriteLine();
                        hero.DeleteItemFromInventory(sellItem);
                        hero.Money += sellItem.Price;


                        bool IsYesProduct = false;
                        foreach (var product in AvailableProductsInMagazin)
                        {
                            if (product.Key.Name == sellItem.Name)
                            {
                                AvailableProductsInMagazin[product.Key] = ++AvailableProductsInMagazin[product.Key];
                                IsYesProduct = true;
                                break;
                            }
                        }
                        if (!IsYesProduct) AvailableProductsInMagazin.Add(sellItem, 1);


                        return true;
                    }
                } while (true);
            }
        }


        public virtual void BuyProduct(Hero hero)
        {
            do
            {
                hero.HeroInventory.InventoryInfo(hero);

                if (!ChooseGroupBuyItem()) return;

            } while (true);


            bool ChooseGroupBuyItem()
            {
                do
                {
                    int answerGroupBuy;
                    var groupBuy = (from product in AvailableProductsInMagazin
                                    where product.Key.Category != "Трофей"
                                    select product.Key.Category).Distinct().ToList();
                    do
                    {
                        Color.Cyan("Выберите категорию товара: ");
                        foreach (var group in groupBuy)
                        {
                            Console.WriteLine($"[{groupBuy.IndexOf(group) + 1}] {group}.");
                        }
                        Console.WriteLine("[-1] Вернуться к выбору действия.");

                        int.TryParse(Console.ReadLine(), out answerGroupBuy);

                        if (answerGroupBuy == -1)
                        {
                            Console.Clear();
                            return false;
                        }

                        if (answerGroupBuy < 1 || answerGroupBuy > groupBuy.Count)
                        {
                            Color.Red("Введенное значение неверно.");
                            Console.WriteLine();
                        }


                    } while (answerGroupBuy < 1 || answerGroupBuy > groupBuy.Count);
                    Console.Clear();

                    BuyItem(groupBuy[answerGroupBuy - 1]);

                } while (true);
            }

            void BuyItem(string category)
            {
                do
                {
                    int answerKindItem;
                    Dictionary<int, Item> numberOfAllItems = new Dictionary<int, Item>();

                    var groupBuy = from d in AvailableProductsInMagazin
                                   where d.Key.Category == category
                                   select d;

                    do
                    {
                        int numberItem = 0;
                        numberOfAllItems.Clear();

                        Color.Cyan($"Выберите {category}: ");
                        foreach (var item in groupBuy)
                        {
                            Color.GreenShort($"Редкость {item.Key.RareLevel}.   ");
                            Console.WriteLine($"[{++numberItem}] {item.Key} \nКоличество на складе - {item.Value}.");
                            numberOfAllItems.Add(numberItem, item.Key);
                        }
                        Console.WriteLine("[-1] Вернуться назад.");

                        int.TryParse(Console.ReadLine(), out answerKindItem);

                        if (answerKindItem == -1)
                        {
                            Console.Clear();
                            return;
                        }

                        if (answerKindItem < 1 || answerKindItem > groupBuy.Count())
                        {
                            Color.Red("Введенное значение неверно.");
                            Console.WriteLine();
                        }

                    } while (answerKindItem < 1 || answerKindItem > groupBuy.Count());
                    Console.Clear();

                    Item chosenItem = numberOfAllItems[answerKindItem];

                    Color.Green($"{chosenItem.Name}.");
                    Color.Cyan(chosenItem.ToString());
                    Console.WriteLine(chosenItem.Description);
                    Console.WriteLine();

                    do
                    {
                        Color.Cyan($"Купить товар?: \n[1] Да \n[2] Нет");

                        int.TryParse(Console.ReadLine(), out answerKindItem);

                        if (answerKindItem < 1 || answerKindItem > 2)
                        {
                            Color.Red("Введенное значение неверно.");
                            Console.WriteLine();
                        }

                    } while (answerKindItem < 1 || answerKindItem > 2);
                    Console.WriteLine();
                    Console.Clear();

                    if (answerKindItem == 1)
                    {
                        if (hero.SpendMoney(chosenItem.Price))
                        {
                            Color.Green($"Вы приобрели {chosenItem.Name} за {chosenItem.Price} монет.");
                            Console.WriteLine();

                            if (AvailableProductsInMagazin[chosenItem] > 1)
                            {
                                AvailableProductsInMagazin[chosenItem] = --AvailableProductsInMagazin[chosenItem];
                            }
                            else AvailableProductsInMagazin.Remove(chosenItem);

                            hero.AddItemToInventory(chosenItem);
                        }
                        else
                        {
                            Color.Red("Денег в кошельке недостаточно! Покупка не совершена.");
                            Console.WriteLine();
                        }
                    }

                } while (true);
            }


        }




    }



}
