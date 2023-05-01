using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Workshop
    {
        public string Name { get; set; }
        public string Description { get; set; }



        public override string ToString()
        {
            return $"Мастерская: {Name}.";
        }


        public virtual void GoToWorkshop(Hero hero)
        {
            do
            {
                Color.Green($"У героя {hero.Name} в кошельке звенит {hero.Money} монет.");
                Console.WriteLine();

                Color.Cyan(ToString());
                Console.WriteLine(Description);
                Console.WriteLine();


                int answerWhatToDoInWorkshop;
                do
                {
                    Color.Cyan("Выберите действие: ");
                    Console.WriteLine("[1] Улучшить предмет. \n[2] Открыть инвентарь. \n[-1] Выйти в город.");

                    int.TryParse(Console.ReadLine(), out answerWhatToDoInWorkshop);

                    if (answerWhatToDoInWorkshop == -1)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerWhatToDoInWorkshop < 1 || answerWhatToDoInWorkshop > 2)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }


                } while (answerWhatToDoInWorkshop < 1 || answerWhatToDoInWorkshop > 2);
                Console.Clear();

                switch (answerWhatToDoInWorkshop)
                {
                    case 1: ImproveEquipment(hero); break;
                    case 2: hero.OpenInventory(); break;
                    default: break;
                }
            } while (true);
        }


        public virtual void ImproveEquipment(Hero hero)
        {
            do
            {
                hero.HeroInventory.InventoryInfo(hero);

                if (!ChooseGroopImproveEquipment()) return;

            } while (true);


            bool ChooseGroopImproveEquipment()
            {
                do
                {
                    var allItemsToImprove = (from product in hero.HeroInventory.AllItems
                                             where product.Category == "Снаряжение"
                                             select (Equipment)product).ToList();

                    var groupToImprove = (from item in allItemsToImprove
                                          select item.EquipmentPlace).Distinct().ToList();

                    int answerGroupToImprove;

                    do
                    {
                        Color.Cyan("Перед улучшением снаряжения, его необходимо снять.");
                        Color.Cyan("Выберите категорию товара: ");
                        foreach (var group in groupToImprove)
                        {
                            Console.WriteLine($"[{groupToImprove.IndexOf(group) + 1}] {group}.");
                        }
                        Console.WriteLine("[-1] Вернуться к выбору действия.");

                        int.TryParse(Console.ReadLine(), out answerGroupToImprove);

                        if (answerGroupToImprove == -1)
                        {
                            Console.Clear();
                            return false;
                        }

                        if (answerGroupToImprove < 1 || answerGroupToImprove > groupToImprove.Count)
                        {
                            Color.Red("Введенное значение неверно.");
                            Console.WriteLine();
                        }


                    } while (answerGroupToImprove < 1 || answerGroupToImprove > groupToImprove.Count);                    
                    Console.Clear();

                    Improve(groupToImprove[answerGroupToImprove - 1], allItemsToImprove);

                } while (true);



                void Improve(string category, List<Equipment> allItemsToImprove)
                {
                    do
                    {
                        int answerKindItem;

                        var groupToImprove = (from d in allItemsToImprove
                                              where d.EquipmentPlace == category
                                              select d).ToList();

                        do
                        {
                            int numberItem = 0;

                            Color.Cyan($"Выберите {category}: ");
                            foreach (var item in groupToImprove)
                            {
                                Color.GreenShort($"Редкость {item.RareLevel}.   ");
                                Console.WriteLine($"[{++numberItem}] {item}; Степень улучшения - {item.DegreeOfImprovement}.");
                            }
                            Console.WriteLine("[-1] Вернуться назад.");

                            int.TryParse(Console.ReadLine(), out answerKindItem);

                            if (answerKindItem == -1)
                            {
                                Console.Clear();
                                return;
                            }

                            if (answerKindItem < 1 || answerKindItem > groupToImprove.Count())
                            {
                                Color.Red("Введенное значение неверно.");
                                Console.WriteLine();
                            }

                        } while (answerKindItem < 1 || answerKindItem > groupToImprove.Count());                     
                        Console.Clear();


                        Equipment chosenItem = groupToImprove[answerKindItem - 1];


                        Color.Green($"{chosenItem.Name}.");
                        Color.Cyan(chosenItem.ToString());
                        Console.WriteLine($"Степень улучшения - {chosenItem.DegreeOfImprovement}.");
                        Console.WriteLine(chosenItem.Description);
                        Console.WriteLine();

                        int money = 0;
                        int bonus = 0;
                        do
                        {

                            if (chosenItem.DegreeOfImprovement == Equipment.degreeOfImprovement.НельзяУлучшить || chosenItem.DegreeOfImprovement == Equipment.degreeOfImprovement.Совершенное)
                            {
                                Color.Red($"Снаряжение {chosenItem.Name} нельзя улучшить");
                                return;
                            }

                            if (chosenItem.DegreeOfImprovement == Equipment.degreeOfImprovement.Обычное)
                            {
                                money = chosenItem.Price * 2 + 500;
                                bonus += chosenItem.Bonus / 4;
                                Color.Cyan($"Улучшение cнаряжения {chosenItem.Name} будет стоить {money} монет.");
                                Color.Cyan($"Характеристики cнаряжения увеличатся на {chosenItem.Bonus / 4} пунктов.");
                            }

                            if (chosenItem.DegreeOfImprovement == Equipment.degreeOfImprovement.Улучшенное)
                            {
                                money = chosenItem.Price * 3 + 500;
                                bonus += chosenItem.Bonus / 4;
                                Color.Cyan($"Улучшение cнаряжения {chosenItem.Name} будет стоить {money} монет.");
                                Color.Cyan($"Характеристики cнаряжения увеличатся на {chosenItem.Bonus / 4} пунктов.");
                            }
                            Console.WriteLine();


                            Color.Cyan($"Улучшить снаряжение?: \n[1] Да \n[2] Нет");

                            int.TryParse(Console.ReadLine(), out answerKindItem);

                            if (answerKindItem < 1 || answerKindItem > 2)
                            {
                                Color.Red("Введенное значение неверно.");
                                Console.WriteLine();
                            }

                        } while (answerKindItem < 1 || answerKindItem > 2);                   
                        Console.Clear();


                        if (answerKindItem == 1)
                        {
                            if (hero.SpendMoney(money))
                            {
                                Color.Green($"Вы улучшили {chosenItem.Name} за {money} монет.");
                                Console.WriteLine();
                                hero.DeleteItemFromInventory(chosenItem);
                                var improvedItem = (Equipment)chosenItem.Clone();

                                improvedItem.Bonus += bonus;
                                improvedItem.Price += chosenItem.Price / 2;
                                if (improvedItem.DegreeOfImprovement == Equipment.degreeOfImprovement.Обычное)
                                {
                                    improvedItem.DegreeOfImprovement = Equipment.degreeOfImprovement.Улучшенное;
                                }
                                else improvedItem.DegreeOfImprovement = Equipment.degreeOfImprovement.Совершенное;
                                hero.AddItemToInventory(improvedItem);
                                return;
                            }

                            else
                            {
                                Color.Red("Денег в кошельке недостаточно! Улучшение не совершено.");
                                Console.WriteLine();
                            }
                        }

                    } while (true);


                }
            }


        }

    }


}
