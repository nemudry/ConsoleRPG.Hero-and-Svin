using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract partial class Hero
    {

        private Inventory heroInventory;
        public Inventory HeroInventory
        {
            get => heroInventory;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    heroInventory = value;
                }
                else
                {
                    if (heroInventory == null) heroInventory = value;
                    else
                    {
                        Inventory oldInvent = HeroInventory;
                        heroInventory = value;

                        HeroInventory.TrophyBag.AddRange(oldInvent.TrophyBag);
                        HeroInventory.Buffs.AddRange(oldInvent.Buffs);
                        HeroInventory.WeaponAndUniform.AddRange(oldInvent.WeaponAndUniform);
                        HeroInventory.Packs.AddRange(oldInvent.Packs);
                        HeroInventory.AllItems.AddRange(oldInvent.AllItems);

                        oldInvent.TrophyBag.Clear();
                        oldInvent.Buffs.Clear();
                        oldInvent.WeaponAndUniform.Clear();
                        oldInvent.Packs.Clear();
                        oldInvent.AllItems.Clear();
                    }
                }
            }
        }


        private Weapon heroWeapon;
        public Weapon HeroWeapon
        {
            get => heroWeapon;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    heroWeapon = value;
                }
                else
                {
                    if (heroWeapon == null) heroWeapon = value;
                    MainFeatures = (HP, Mana, Attack - HeroWeapon.Bonus, Defence, Crit);
                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                    heroWeapon = value;
                    MainFeatures = (HP, Mana, Attack + value.Bonus, Defence, Crit);
                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                }
            }
        }


        private Shield heroShield;
        public Shield HeroShield
        {
            get => heroShield;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    heroShield = value;
                }
                else
                {
                    if (heroShield == null) heroShield = value;
                    MainFeatures = (HP, Mana, Attack, Defence - HeroShield.Bonus, Crit);
                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                    heroShield = value;
                    MainFeatures = (HP, Mana, Attack, Defence + value.Bonus, Crit);
                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                }
            }
        }


        private Helmet heroHelmet;
        public Helmet HeroHelmet
        {
            get => heroHelmet;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    heroHelmet = value;
                }
                else
                {
                    if (heroHelmet == null) heroHelmet = value;
                    MainFeatures = (HP, Mana, Attack, Defence - HeroHelmet.Bonus, Crit);
                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                    heroHelmet = value;
                    MainFeatures = (HP, Mana, Attack, Defence + value.Bonus, Crit);
                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                }
            }
        }


        private Armor heroArmor;
        public Armor HeroArmor
        {
            get => heroArmor;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    heroArmor = value;
                }
                else
                {
                    if (heroArmor == null) heroArmor = value;
                    MainFeatures = (HP, Mana, Attack, Defence - HeroArmor.Bonus, Crit);
                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                    heroArmor = value;
                    MainFeatures = (HP, Mana, Attack, Defence + value.Bonus, Crit);
                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                }
            }
        }


        private Amulet heroAmulet;
        public Amulet HeroAmulet
        {
            get => heroAmulet;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    heroAmulet = value;
                }
                else
                {
                    if (heroAmulet != null)
                    {
                        switch (HeroAmulet.AmuletImprovementOf)
                        {
                            case Amulet.ImprovementOf.HP:
                                {
                                    MainFeatures = (HP - HeroAmulet.Bonus, Mana, Attack, Defence, Crit);
                                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                                    break;
                                }
                            case Amulet.ImprovementOf.Крит:
                                {
                                    MainFeatures = (HP, Mana, Attack, Defence, Crit - HeroAmulet.Bonus);
                                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                                    break;
                                }
                            case Amulet.ImprovementOf.Защита:
                                {
                                    MainFeatures = (HP, Mana, Attack, Defence - HeroAmulet.Bonus, Crit);
                                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                                    break;
                                }
                            case Amulet.ImprovementOf.Атака:
                                {
                                    MainFeatures = (HP, Mana, Attack - HeroAmulet.Bonus, Defence, Crit);
                                    (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                                    break;
                                }
                        }
                    }

                    switch (value.AmuletImprovementOf)
                    {
                        case Amulet.ImprovementOf.HP:
                            {
                                if (heroAmulet == null)
                                {
                                    heroAmulet = value;
                                    break;
                                }
                                heroAmulet = value;
                                MainFeatures = (HP + value.Bonus, Mana, Attack, Defence, Crit);
                                (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                                break;
                            }
                        case Amulet.ImprovementOf.Крит:
                            {
                                if (heroAmulet == null)
                                {
                                    heroAmulet = value;
                                    break;
                                }
                                heroAmulet = value;
                                MainFeatures = (HP, Mana, Attack, Defence, Crit + value.Bonus);
                                (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                                break;
                            }
                        case Amulet.ImprovementOf.Защита:
                            {
                                if (heroAmulet == null)
                                {
                                    heroAmulet = value;
                                    break;
                                }
                                heroAmulet = value;
                                MainFeatures = (HP, Mana, Attack, Defence + value.Bonus, Crit);
                                (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                                break;
                            }
                        case Amulet.ImprovementOf.Атака:
                            {
                                if (heroAmulet == null)
                                {
                                    heroAmulet = value;
                                    break;
                                }
                                heroAmulet = value;
                                MainFeatures = (HP, Mana, Attack + value.Bonus, Defence, Crit);
                                (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                                break;
                            }

                    }

                }
            }
        }


        public virtual void OpenInventory()
        {
            do
            {
                HeroInventory.InventoryInfo(this);

                Color.Cyan("Снаряжение в рюкзаке:");
                foreach (var item in HeroInventory.WeaponAndUniform)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                if (!ChangeWeaponAndUniform()) break;

            } while (true);
        }

        public virtual void AddItemToInventory(Item newItem)
        {
            switch (newItem)
            {
                case Equipment item:
                    if (HeroInventory.WeaponAndUniform.Count < HeroInventory.WeaponAndUniform.Capacity)
                    {
                        HeroInventory.WeaponAndUniform.Add(item);
                        HeroInventory.AllItems.Add(item);
                    }
                    else
                    {
                        Color.Red($"Рюкзак заполнен! Освободите место, чтобы вложить новый предмет. Снаряжение {item.Name} выброшено.");
                        Console.WriteLine();
                    }
                    break;
                case Trophy item:
                    if (HeroInventory.TrophyBag.Count < HeroInventory.TrophyBag.Capacity)
                    {
                        HeroInventory.TrophyBag.Add(item);
                        HeroInventory.AllItems.Add(item);
                    }
                    else
                    {
                        Color.Red($"Рюкзак заполнен! Освободите место, чтобы вложить новый предмет. Снаряжение {item.Name} выброшено.");
                        Console.WriteLine();
                    }
                    break;
                case Buff item:
                    if (HeroInventory.Buffs.Count < HeroInventory.Buffs.Capacity)
                    {
                        HeroInventory.Buffs.Add(item);
                        HeroInventory.AllItems.Add(item);
                    }
                    else
                    {
                        Color.Red($"Рюкзак заполнен! Освободите место, чтобы вложить новый предмет. Снаряжение {item.Name} выброшено.");
                        Console.WriteLine();
                    }
                    break;
                case Inventory item:
                    HeroInventory.Packs.Add(item);
                    HeroInventory.AllItems.Add(item);
                    break;
                default: break;
            }
        }

        public virtual void DeleteItemFromInventory(Item chosenItemToSell)
        {
            switch (chosenItemToSell)
            {
                case Equipment item:
                    HeroInventory.WeaponAndUniform.Remove(item);
                    HeroInventory.AllItems.Remove(item);
                    break;
                case Trophy item:
                    HeroInventory.TrophyBag.Remove(item);
                    HeroInventory.AllItems.Remove(item);
                    break;
                case Buff item:
                    HeroInventory.Buffs.Remove(item);
                    HeroInventory.AllItems.Remove(item);
                    break;
                case Inventory item:
                    HeroInventory.Packs.Remove(item);
                    HeroInventory.AllItems.Remove(item);
                    break;
                default: break;
            }
        }

        public virtual bool ChangeWeaponAndUniform()
        {
            int answerWeaponAndUniform;
            do
            {
                Color.Cyan("Выберите снаряжение: ");

                foreach (var item in HeroInventory.WeaponAndUniform)
                {
                    Console.WriteLine($"[{HeroInventory.WeaponAndUniform.IndexOf(item) + 1}] {item}");
                }
                Console.WriteLine("[-1] Не менять и выйти из инвентаря.");
                Console.WriteLine("[-2] Изучить вещи в инвентаре подробнее.");
                Console.WriteLine("[-3] Изменить вид инветаря.");


                int.TryParse(Console.ReadLine(), out answerWeaponAndUniform);

                if (answerWeaponAndUniform == -1)
                {
                    Console.Clear();
                    return false;
                }

                if (answerWeaponAndUniform == -2)
                {
                    HeroInventory.AnalizeItem(this);
                    Console.WriteLine();
                    return true;
                }

                if (answerWeaponAndUniform == -3)
                {
                    ChangeInventory();
                    Console.WriteLine();
                    return true;
                }

                if (answerWeaponAndUniform < 1 || answerWeaponAndUniform > HeroInventory.WeaponAndUniform.Count())
                {
                    Color.Red("Введенное значение неверно.");
                    Console.WriteLine();
                }

            } while (answerWeaponAndUniform < 1 || answerWeaponAndUniform > HeroInventory.WeaponAndUniform.Count());           
            Console.Clear();

            Equipment dressItem = HeroInventory.WeaponAndUniform[answerWeaponAndUniform - 1];



            if (dressItem.RaceWears != RaceHero &&
                dressItem.RaceWears != raceHero.Любая)
            {
                Color.Red($"Снаряжение {dressItem.Name} не надето, так как ваша раса не подходит.");
                Color.Red($"Только {dressItem.RaceWears} может одеть данное снаряжение.");
                Console.WriteLine();
                return false;
            }

            else if (dressItem.ClassWears != ClassHero &&
                dressItem.ClassWears != classHero.Любая)
            {
                Color.Red($"Снаряжение {dressItem.Name} не надето, так как ваш класс не подходит.");
                Color.Red($"Только {dressItem.ClassWears} может одеть данное снаряжение.");
                Console.WriteLine();
                return false;
            }

            else
            {
                switch (HeroInventory.WeaponAndUniform[answerWeaponAndUniform - 1])
                {
                    case Weapon item:
                        Item pastWeapon = HeroWeapon;
                        HeroWeapon = item;
                        DeleteItemFromInventory(item);
                        AddItemToInventory(pastWeapon);
                        Color.Green($"Оружие {item.Name} надето.");
                        Console.WriteLine();
                        break;

                    case Shield item:
                        var pastShield = HeroShield;
                        HeroShield = item;
                        DeleteItemFromInventory(item);
                        AddItemToInventory(pastShield);
                        Color.Green($"Щит {item.Name} надет.");
                        Console.WriteLine();
                        break;

                    case Armor item:
                        var pastArmor = HeroArmor;
                        HeroArmor = item;
                        DeleteItemFromInventory(item);
                        AddItemToInventory(pastArmor); ;
                        Color.Green($"Броня {item.Name} надета.");
                        Console.WriteLine();
                        break;

                    case Helmet item:
                        var pastHelmet = HeroHelmet;
                        HeroHelmet = item;
                        DeleteItemFromInventory(item);
                        AddItemToInventory(pastHelmet);
                        Color.Green($"Шлем {item.Name} надет.");
                        Console.WriteLine();
                        break;

                    case Amulet item:
                        var pastAmulet = HeroAmulet;
                        HeroAmulet = item;
                        DeleteItemFromInventory(item);
                        AddItemToInventory(pastAmulet);
                        Color.Green($"Амулет {item.Name} надет.");
                        Console.WriteLine();
                        break;

                    default: break;
                }
            }
            return true;
        }

        public virtual void ChangeInventory()
        {

            int answerInventory;
            do
            {
                Console.Clear();
                Color.Cyan("Выберите вид инвентаря: ");

                foreach (var item in HeroInventory.Packs)
                {
                    Console.WriteLine($"[{HeroInventory.Packs.IndexOf(item) + 1}] {item}");
                    Console.WriteLine();
                }
                Console.WriteLine("[-1] Не менять и выйти.");


                int.TryParse(Console.ReadLine(), out answerInventory);

                if (answerInventory == -1)
                {
                    Console.Clear();
                    Console.WriteLine();
                    return;
                }


                if (answerInventory < 1 || answerInventory > HeroInventory.Packs.Count())
                {
                    Color.Red("Введенное значение неверно.");
                    Console.WriteLine();
                }

            } while (answerInventory < 1 || answerInventory > HeroInventory.Packs.Count());
            Console.Clear();


            Inventory oldInventory = HeroInventory;
            Inventory newInventory = HeroInventory.Packs[answerInventory - 1];
            DeleteItemFromInventory(newInventory);
            HeroInventory = newInventory;
            AddItemToInventory(oldInventory);
            Color.Green($"Инвентарь {newInventory.Name} надет.");
        }



        




    }
}
