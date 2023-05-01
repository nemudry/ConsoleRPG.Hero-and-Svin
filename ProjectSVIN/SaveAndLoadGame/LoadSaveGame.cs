using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static SVINspace.Hero;

namespace SVINspace
{
    public class LoadSaveGame
    {
        public List<Item> GameItems { get; set; }
        public List<Pig> Pigs { get; set; }
        public List<Monster> Monsters { get; set; }


        public LoadSaveGame(List<Item> gameItems, List<Monster> monsters, List<Pig> pigs)
        {
            GameItems = gameItems;
            Monsters = monsters;
            Pigs = pigs;
        }


        public virtual void StartLoading (out Hero LoadedHero, out City LoadedCity, out DayInGame LoadedDay)
        {
            string path = @"C:\Users\user\Desktop\SVINAndHeroSave.dat";

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                LoadedHero = null;
                Hero.statusHero StatusHero = (Hero.statusHero)reader.ReadInt32();
                string Name = reader.ReadString();
                Hero.classHero ClassHero = (Hero.classHero)reader.ReadInt32();
                Hero.raceHero RaceHero = (Hero.raceHero)reader.ReadInt32();

                int Rank = reader.ReadInt32();
                int Level = reader.ReadInt32();
                int Exp = reader.ReadInt32();

                int HP = reader.ReadInt32();
                int Mana = reader.ReadInt32();
                int Attack = reader.ReadInt32();
                int Defence = reader.ReadInt32();
                int Crit = reader.ReadInt32();

                int Money = reader.ReadInt32();


                //снаряжение
                bool isYesImproveWeapon = reader.ReadBoolean();
                Weapon HeroWeapon = null;
                if (!isYesImproveWeapon)
                {
                    string nameWeapon = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameWeapon) { HeroWeapon = (Weapon)item; break; }
                    }
                }
                else
                {
                    string nameWeapon = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameWeapon) { HeroWeapon = (Weapon)item; break; }
                    }
                    HeroWeapon.DegreeOfImprovement = (Equipment.degreeOfImprovement)reader.ReadInt32();
                    HeroWeapon.Bonus = reader.ReadInt32();
                    HeroWeapon.Price = reader.ReadInt32();
                }


                bool isYesImproveShield = reader.ReadBoolean();
                Shield HeroShield = null;
                if (!isYesImproveShield)
                {
                    string nameShield = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameShield) { HeroShield = (Shield)item; break; }
                    }
                }
                else
                {
                    string nameShield = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameShield) { HeroShield = (Shield)item; break; }
                    }
                    HeroShield.DegreeOfImprovement = (Equipment.degreeOfImprovement)reader.ReadInt32();
                    HeroShield.Bonus = reader.ReadInt32();
                    HeroShield.Price = reader.ReadInt32();
                }


                bool isYesImproveHelmet = reader.ReadBoolean();
                Helmet HeroHelmet = null;
                if (!isYesImproveHelmet)
                {
                    string nameHelmet = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameHelmet) { HeroHelmet = (Helmet)item; break; }
                    }
                }
                else
                {
                    string nameHelmet = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameHelmet) { HeroHelmet = (Helmet)item; break; }
                    }
                    HeroHelmet.DegreeOfImprovement = (Equipment.degreeOfImprovement)reader.ReadInt32();
                    HeroHelmet.Bonus = reader.ReadInt32();
                    HeroHelmet.Price = reader.ReadInt32();
                }



                bool isYesImproveArmor = reader.ReadBoolean();
                Armor HeroArmor = null;
                if (!isYesImproveArmor)
                {
                    string nameArmor = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameArmor) { HeroArmor = (Armor)item; break; }
                    }
                }
                else
                {
                    string nameArmor = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameArmor) { HeroArmor = (Armor)item; break; }
                    }
                    HeroArmor.DegreeOfImprovement = (Equipment.degreeOfImprovement)reader.ReadInt32();
                    HeroArmor.Bonus = reader.ReadInt32();
                    HeroArmor.Price = reader.ReadInt32();
                }


                bool isYesImproveAmulet = reader.ReadBoolean();
                Amulet HeroAmulet = null;
                if (!isYesImproveAmulet)
                {
                    string nameAmulet = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameAmulet) { HeroAmulet = (Amulet)item; break; }
                    }
                }
                else
                {
                    string nameAmulet = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameAmulet) { HeroAmulet = (Amulet)item; break; }
                    }
                    HeroAmulet.DegreeOfImprovement = (Equipment.degreeOfImprovement)reader.ReadInt32();
                    HeroAmulet.Bonus = reader.ReadInt32();
                    HeroAmulet.Price = reader.ReadInt32();
                }


                string nameInventory = reader.ReadString();
                Inventory HeroInventory = null;
                foreach (Item item in GameItems)
                {
                    if (item.Name == nameInventory) { HeroInventory = (Inventory)item; break; }
                }


                //Сумки инвентаря
                int countWeaponAndUniform = reader.ReadInt32();
                for (int i = 0; i < countWeaponAndUniform; i++)
                {

                    bool isYesImproveItem = reader.ReadBoolean();
                    if (!isYesImproveItem)
                    {
                        string nameNotImprovedItem = reader.ReadString();
                        foreach (Item item in GameItems)
                        {
                            if (item.Name == nameNotImprovedItem) 
                            { 
                                HeroInventory.WeaponAndUniform.Add((Equipment)item); 
                                break; 
                            }
                        }
                    }
                    else
                    {
                        string nameImprovedItem = reader.ReadString();
                        Equipment itemWeaponAndUniform = null;
                        foreach (Item item in GameItems)
                        {
                            if (item.Name == nameImprovedItem) 
                            {
                                itemWeaponAndUniform = (Equipment)item;
                                itemWeaponAndUniform.DegreeOfImprovement = (Equipment.degreeOfImprovement)reader.ReadInt32();
                                itemWeaponAndUniform.Bonus = reader.ReadInt32();
                                itemWeaponAndUniform.Price = reader.ReadInt32();
                                HeroInventory.WeaponAndUniform.Add(itemWeaponAndUniform);
                                break; 
                            }
                            
                        }
                    }

                }


                int countTrophyBag = reader.ReadInt32();
                for (int i = 0; i < countTrophyBag; i++)
                {
                    string nameItem = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameItem) { HeroInventory.TrophyBag.Add((Trophy)item); break; }
                    }
                }

                int countBuffs = reader.ReadInt32();
                for (int i = 0; i < countBuffs; i++)
                {
                    string nameItem = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameItem) { HeroInventory.Buffs.Add((Buff)item); break; }
                    }
                }

                int countPacks = reader.ReadInt32();
                for (int i = 0; i < countPacks; i++)
                {
                    string nameItem = reader.ReadString();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameItem) { HeroInventory.Packs.Add((Inventory)item); break; }
                    }
                }



                int countAllItems = reader.ReadInt32();
                for (int i = 0; i < countAllItems; i++)
                {
                    bool isYesEquipmentItem = reader.ReadBoolean();
                    if (isYesEquipmentItem)
                    {
                        bool isYesImproveItem = reader.ReadBoolean();
                        if (!isYesImproveItem)
                        {
                            string nameNotImprovedItem = reader.ReadString();
                            foreach (Item item in GameItems)
                            {
                                if (item.Name == nameNotImprovedItem)
                                {
                                    HeroInventory.AllItems.Add(item);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            string nameImprovedItem = reader.ReadString();
                            Equipment itemWeaponAndUniform = null;
                            foreach (Item item in GameItems)
                            {
                                if (item.Name == nameImprovedItem)
                                {
                                    itemWeaponAndUniform = (Equipment)item;
                                    itemWeaponAndUniform.DegreeOfImprovement = (Equipment.degreeOfImprovement)reader.ReadInt32();
                                    itemWeaponAndUniform.Bonus = reader.ReadInt32();
                                    itemWeaponAndUniform.Price = reader.ReadInt32();
                                    HeroInventory.AllItems.Add(itemWeaponAndUniform);
                                    break;
                                }
                                
                            }
                        }


                    }
                    else
                    {
                        string nameItem = reader.ReadString();
                        foreach (Item item in GameItems)
                        {
                            if (item.Name == nameItem) { HeroInventory.AllItems.Add(item); break; }
                        }
                    }
                }



                //cвиньи
                int countPig = reader.ReadInt32();
                List<Pig> HeroPigs = new List<Pig>();
                if (countPig > 0)
                {
                    for (int i = 0; i < countPig; i++)
                    {
                        string PigName = reader.ReadString();
                        string Nickname = reader.ReadString();
                        string Description = reader.ReadString();

                        int LevelPig = reader.ReadInt32();
                        int Fat = reader.ReadInt32();
                        int Appetite = reader.ReadInt32();
                        int PigUrgeToEscape = reader.ReadInt32();


                        Type typePig = null;
                        foreach (Pig p in Pigs)
                        {
                            if (p.Name == PigName) { typePig = p.GetType(); break; }
                        }
                        var constructors = typePig.GetConstructors();
                        object[] consArgs = new object[7] { PigName, Nickname, Description, LevelPig, Fat, Appetite, PigUrgeToEscape };

                        Pig pig = (Pig)constructors[1].Invoke(consArgs);

                        HeroPigs.Add(pig);
                    }
                }


                bool isYesPig = reader.ReadBoolean();
                Pig ActualHeroPig = null;
                if (isYesPig)
                {
                    string PigName = reader.ReadString();
                    string Nickname = reader.ReadString();
                    string Description = reader.ReadString();

                    int LevelPig = reader.ReadInt32();
                    int Fat = reader.ReadInt32();
                    int Appetite = reader.ReadInt32();
                    int PigUrgeToEscape = reader.ReadInt32();


                    Type typePig = null;
                    foreach (Pig p in Pigs)
                    {
                        if (p.Name == PigName) { typePig = p.GetType(); break; }
                    }
                    var constructors = typePig.GetConstructors();
                    object[] consArgs = new object[7] { PigName, Nickname, Description, LevelPig, Fat, Appetite, PigUrgeToEscape };

                    Pig pig = (Pig)constructors[1].Invoke(consArgs);

                    ActualHeroPig = pig;
                }



                //квест
                bool isYesQuest = reader.ReadBoolean();
                Quest ActualHeroQuest = null;
                if (isYesQuest)
                {
                    string nameMonster = reader.ReadString();
                    Monster monster = null;
                    foreach (Monster monst in Monsters)
                    {
                        if (monst.Name == nameMonster) { monster = monst; break; }
                    }

                    int AmountMonster = reader.ReadInt32();

                    int TimeToComplite = reader.ReadInt32();

                    int PrizeMoney = reader.ReadInt32();

                    Item Prizeitem = null;
                    string PrizeitemName = reader.ReadString();
                    foreach (Item it in GameItems)
                    {
                        if (it.Name == PrizeitemName) { Prizeitem = it; break; }
                    }

                    int PrizeExp = reader.ReadInt32();

                    Quest.statusQuest status = (Quest.statusQuest)reader.ReadInt32();

                    int KilledMonstersQuest = reader.ReadInt32();

                    int DayOfDoingQuest = reader.ReadInt32();


                    ActualHeroQuest = new Quest(monster, AmountMonster, TimeToComplite, PrizeMoney, PrizeExp, Prizeitem);
                    ActualHeroQuest.StatusQuest = status;
                    ActualHeroQuest.KilledMonstersQuest = KilledMonstersQuest;
                    ActualHeroQuest.DayOfDoingQuest = DayOfDoingQuest;

                }

                switch (ClassHero)
                {
                    case classHero.Воин:
                        switch (RaceHero)
                        {
                            case raceHero.Человек:
                                LoadedHero = new WarriorMan(Name, Level, Rank, HP, Mana, Exp, Defence, Attack, Crit, Money, StatusHero,
                    HeroInventory, HeroWeapon, HeroShield, HeroHelmet, HeroArmor, HeroAmulet, HeroPigs, ActualHeroPig, ActualHeroQuest);
                               
                                break;
                            case raceHero.Эльф:
                                LoadedHero = new WarriorElf(Name, Level, Rank, HP, Mana, Exp, Defence, Attack, Crit, Money, StatusHero,
                    HeroInventory, HeroWeapon, HeroShield, HeroHelmet, HeroArmor, HeroAmulet, HeroPigs, ActualHeroPig, ActualHeroQuest);
                                break;
                            case raceHero.Гном:
                                LoadedHero = new WarriorGnom(Name, Level, Rank, HP, Mana, Exp, Defence, Attack, Crit, Money, StatusHero,
                    HeroInventory, HeroWeapon, HeroShield, HeroHelmet, HeroArmor, HeroAmulet, HeroPigs, ActualHeroPig, ActualHeroQuest);
                                break;
                            default:
                                break;
                        }
                        break;
                    case classHero.Маг:
                        switch (RaceHero)
                        {
                            case raceHero.Человек:
                                LoadedHero = new MageMan(Name, Level, Rank, HP, Mana, Exp, Defence, Attack, Crit, Money, StatusHero,
                    HeroInventory, HeroWeapon, HeroShield, HeroHelmet, HeroArmor, HeroAmulet, HeroPigs, ActualHeroPig, ActualHeroQuest);
                                break;
                            case raceHero.Эльф:
                                LoadedHero = new MageElf(Name, Level, Rank, HP, Mana, Exp, Defence, Attack, Crit, Money, StatusHero,
                    HeroInventory, HeroWeapon, HeroShield, HeroHelmet, HeroArmor, HeroAmulet, HeroPigs, ActualHeroPig, ActualHeroQuest);
                                break;
                            case raceHero.Гном:
                                LoadedHero = new MageGnom(Name, Level, Rank, HP, Mana, Exp, Defence, Attack, Crit, Money, StatusHero,
                    HeroInventory, HeroWeapon, HeroShield, HeroHelmet, HeroArmor, HeroAmulet, HeroPigs, ActualHeroPig, ActualHeroQuest);
                                break;
                            default:
                                break;
                        }
                        break;
                    case classHero.Вор:
                        switch (RaceHero)
                        {
                            case raceHero.Человек:
                                LoadedHero = new ThiefMan(Name, Level, Rank, HP, Mana, Exp, Defence, Attack, Crit, Money, StatusHero,
                    HeroInventory, HeroWeapon, HeroShield, HeroHelmet, HeroArmor, HeroAmulet, HeroPigs, ActualHeroPig, ActualHeroQuest);
                                break;
                            case raceHero.Эльф:
                                LoadedHero = new ThiefElf(Name, Level, Rank, HP, Mana, Exp, Defence, Attack, Crit, Money, StatusHero,
                    HeroInventory, HeroWeapon, HeroShield, HeroHelmet, HeroArmor, HeroAmulet, HeroPigs, ActualHeroPig, ActualHeroQuest);
                                break;
                            case raceHero.Гном:
                                LoadedHero = new ThiefGnom(Name, Level, Rank, HP, Mana, Exp, Defence, Attack, Crit, Money, StatusHero,
                    HeroInventory, HeroWeapon, HeroShield, HeroHelmet, HeroArmor, HeroAmulet, HeroPigs, ActualHeroPig, ActualHeroQuest);
                                break;
                            default:
                                break;                        }
                        break;
                    default:
                        break;
                }

            

                // магазин
                LoadedCity = new Gotemsvin(GameItems, Monsters);

                LoadedCity.Magazin.AvailableProductsInMagazin.Clear();
                int countAvailableProductsInMagazin = reader.ReadInt32();
                for (int i = 0; i < countAvailableProductsInMagazin; i++)
                {
                    string nameItem = reader.ReadString();
                    int countItem = reader.ReadInt32();
                    foreach (Item item in GameItems)
                    {
                        if (item.Name == nameItem) { LoadedCity.Magazin.AvailableProductsInMagazin.Add(item, countItem); break; }
                    }
                }


                //квесты
                LoadedCity.Guildhall.QuestBoard.Clear();
                int countQuestBoard = reader.ReadInt32();
                for (int i = 0; i < countQuestBoard; i++)
                {
                    Quest quest = null;

                    string nameMonster = reader.ReadString();
                    Monster monster = null;
                    foreach (Monster monst in Monsters)
                    {
                        if (monst.Name == nameMonster) { monster = monst; break; }
                    }

                    int AmountMonster = reader.ReadInt32();

                    int TimeToComplite = reader.ReadInt32();

                    int PrizeMoney = reader.ReadInt32();

                    Item Prizeitem = null;
                    string PrizeitemName = reader.ReadString();
                    foreach (Item it in GameItems)
                    {
                        if (it.Name == PrizeitemName) { Prizeitem = it; break; }
                    }

                    int PrizeExp = reader.ReadInt32();

                    Quest.statusQuest status = (Quest.statusQuest)reader.ReadInt32();

                    int KilledMonstersQuest = reader.ReadInt32();

                    int DayOfDoingQuest = reader.ReadInt32();


                    quest = new Quest(monster, AmountMonster, TimeToComplite, PrizeMoney, PrizeExp, Prizeitem);
                    quest.StatusQuest = status;
                    quest.KilledMonstersQuest = KilledMonstersQuest;
                    quest.DayOfDoingQuest = DayOfDoingQuest;

                    LoadedCity.Guildhall.QuestBoard.Add(quest);
                }
                LoadedCity.GuildhallTimeToRefresh = reader.ReadInt32();


                //свинарники
                foreach (Pigsty pigsty in LoadedCity.PigstyInCity)
                {
                    pigsty.PigsInPigsty.Clear();
                    int countPigs = reader.ReadInt32();
                    List<Pig> pigs = new List<Pig>();
                    if (countPigs > 0)
                    {
                        for (int s = 0; s < countPigs; s++)
                        {
                            string PigName = reader.ReadString();
                            string Nickname = reader.ReadString();
                            string Description = reader.ReadString();

                            int LevelPig = reader.ReadInt32();
                            int Fat = reader.ReadInt32();
                            int Appetite = reader.ReadInt32();
                            int PigUrgeToEscape = reader.ReadInt32();


                            Type typePig = null;
                            foreach (Pig p in Pigs)
                            {
                                if (p.Name == PigName) { typePig = p.GetType(); break; }
                            }
                            var constructors = typePig.GetConstructors();
                            object[] consArgs = new object[7] { PigName, Nickname, Description, LevelPig, Fat, Appetite, PigUrgeToEscape };

                            Pig pig = (Pig)constructors[1].Invoke(consArgs);

                            pigs.Add(pig);
                        }
                        pigsty.PigsInPigsty = pigs;

                    }
                }



                //день
                LoadedDay = new DayInGame(LoadedHero, LoadedCity);
                DayInGame.passedDaysInGame = reader.ReadInt32();
                DayInGame.countActivities = reader.ReadInt32();


            }

            
        }

    }
}
