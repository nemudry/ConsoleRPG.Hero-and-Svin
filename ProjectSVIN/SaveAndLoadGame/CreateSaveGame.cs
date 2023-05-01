using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class CreateSaveGame
    {

        public Hero Hero { get; set; }
        public DayInGame DayInGame { get; set; }
        public City City { get; set; }

        public CreateSaveGame (Hero hero, City city, DayInGame dayInGame)
        {
            Hero = hero;
            City = city;
            DayInGame = dayInGame;
        }

        public virtual void StartSaving ()
        {
            string path = @"C:\Users\user\Desktop\SVINAndHeroSave.dat";
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                //Характеристики героя
                writer.Write((int)Hero.StatusHero);
                writer.Write(Hero.Name);
                writer.Write((int)Hero.ClassHero);
                writer.Write((int)Hero.RaceHero);

                writer.Write(Hero.Rank);
                writer.Write(Hero.Level);                
                writer.Write(Hero.Exp);

                writer.Write(Hero.HP);
                writer.Write(Hero.Mana);
                writer.Write(Hero.Attack);
                writer.Write(Hero.Defence);
                writer.Write(Hero.Crit);

                writer.Write(Hero.Money);



                //Снаряжение
                if (Hero.HeroWeapon.DegreeOfImprovement == Equipment.degreeOfImprovement.Улучшенное ||
                    Hero.HeroWeapon.DegreeOfImprovement == Equipment.degreeOfImprovement.Совершенное)
                {
                    writer.Write(true);
                    writer.Write(Hero.HeroWeapon.Name);
                    writer.Write((int)Hero.HeroWeapon.DegreeOfImprovement);
                    writer.Write(Hero.HeroWeapon.Bonus);
                    writer.Write(Hero.HeroWeapon.Price);
                }
                else
                {
                    writer.Write(false);
                    writer.Write(Hero.HeroWeapon.Name);
                }


                if (Hero.HeroShield.DegreeOfImprovement == Equipment.degreeOfImprovement.Улучшенное ||
                    Hero.HeroShield.DegreeOfImprovement == Equipment.degreeOfImprovement.Совершенное)
                {
                    writer.Write(true);
                    writer.Write(Hero.HeroShield.Name);
                    writer.Write((int)Hero.HeroShield.DegreeOfImprovement);
                    writer.Write(Hero.HeroShield.Bonus);
                    writer.Write(Hero.HeroShield.Price);
                }
                else
                {
                    writer.Write(false);
                    writer.Write(Hero.HeroShield.Name);
                }


                if (Hero.HeroHelmet.DegreeOfImprovement == Equipment.degreeOfImprovement.Улучшенное ||
                    Hero.HeroHelmet.DegreeOfImprovement == Equipment.degreeOfImprovement.Совершенное)
                {
                    writer.Write(true);
                    writer.Write(Hero.HeroHelmet.Name);
                    writer.Write((int)Hero.HeroHelmet.DegreeOfImprovement);
                    writer.Write(Hero.HeroHelmet.Bonus);
                    writer.Write(Hero.HeroHelmet.Price);
                }
                else
                {
                    writer.Write(false);
                    writer.Write(Hero.HeroHelmet.Name);
                }


                if (Hero.HeroArmor.DegreeOfImprovement == Equipment.degreeOfImprovement.Улучшенное ||
                    Hero.HeroArmor.DegreeOfImprovement == Equipment.degreeOfImprovement.Совершенное)
                {
                    writer.Write(true);
                    writer.Write(Hero.HeroArmor.Name);
                    writer.Write((int)Hero.HeroArmor.DegreeOfImprovement);
                    writer.Write(Hero.HeroArmor.Bonus);
                    writer.Write(Hero.HeroArmor.Price);
                }
                else
                {
                    writer.Write(false);
                    writer.Write(Hero.HeroArmor.Name);
                }

                if (Hero.HeroAmulet.DegreeOfImprovement == Equipment.degreeOfImprovement.Улучшенное ||
                    Hero.HeroAmulet.DegreeOfImprovement == Equipment.degreeOfImprovement.Совершенное)
                {
                    writer.Write(true);
                    writer.Write(Hero.HeroAmulet.Name);
                    writer.Write((int)Hero.HeroAmulet.DegreeOfImprovement);
                    writer.Write(Hero.HeroAmulet.Bonus);
                    writer.Write(Hero.HeroAmulet.Price);
                }
                else
                {
                    writer.Write(false);
                    writer.Write(Hero.HeroAmulet.Name);
                }

                writer.Write(Hero.HeroInventory.Name);




                writer.Write(Hero.HeroInventory.WeaponAndUniform.Count);
                foreach (Equipment item in Hero.HeroInventory.WeaponAndUniform)
                {
                    if (item.DegreeOfImprovement == Equipment.degreeOfImprovement.Улучшенное ||
                        item.DegreeOfImprovement == Equipment.degreeOfImprovement.Совершенное)
                    {
                        writer.Write(true);
                        writer.Write(item.Name);
                        writer.Write((int)item.DegreeOfImprovement);
                        writer.Write(item.Bonus);
                        writer.Write(item.Price);
                    }
                    else
                    {
                        writer.Write(false);
                        writer.Write(item.Name);
                    }
                }

                writer.Write(Hero.HeroInventory.TrophyBag.Count);
                foreach (Item item in Hero.HeroInventory.TrophyBag)
                {
                    writer.Write(item.Name);
                }
                writer.Write(Hero.HeroInventory.Buffs.Count);
                foreach (Item item in Hero.HeroInventory.Buffs)
                {
                    writer.Write(item.Name);
                }
                writer.Write(Hero.HeroInventory.Packs.Count);
                foreach (Item item in Hero.HeroInventory.Packs)
                {
                    writer.Write(item.Name);
                }


                writer.Write(Hero.HeroInventory.AllItems.Count);
                foreach (Item item in Hero.HeroInventory.AllItems)
                {
                    if(item is Equipment equipment)
                    {
                        writer.Write(true);
                        if (equipment.DegreeOfImprovement == Equipment.degreeOfImprovement.Улучшенное ||
                            equipment.DegreeOfImprovement == Equipment.degreeOfImprovement.Совершенное)
                        {
                            writer.Write(true);
                            writer.Write(equipment.Name);
                            writer.Write((int)equipment.DegreeOfImprovement);
                            writer.Write(equipment.Bonus);
                            writer.Write(equipment.Price);
                        }
                        else
                        {
                            writer.Write(false);
                            writer.Write(item.Name);
                        }
                    }

                    else
                    {
                        writer.Write(false);
                        writer.Write(item.Name);
                    }
                }


                foreach (Equipment item in Hero.HeroInventory.WeaponAndUniform)
                {


                }

                //cвиньи

                writer.Write(Hero.HeroPigs.Count);
                if (Hero.HeroPigs.Count != 0)
                {
                    foreach (Pig pig in Hero.HeroPigs)
                    {
                        writer.Write(pig.Name);
                        writer.Write(pig.Nickname);
                        writer.Write(pig.Description);
                        writer.Write(pig.Level);
                        writer.Write(pig.Fat);
                        writer.Write(pig.Appetite);
                        writer.Write(pig.PigUrgeToEscape);
                    }
                }


                if (Hero.ActualHeroPig != null)
                {
                    writer.Write(true);
                    writer.Write(Hero.ActualHeroPig.Name);
                    writer.Write(Hero.ActualHeroPig.Nickname);
                    writer.Write(Hero.ActualHeroPig.Description);
                    writer.Write(Hero.ActualHeroPig.Level);
                    writer.Write(Hero.ActualHeroPig.Fat);
                    writer.Write(Hero.ActualHeroPig.Appetite);
                    writer.Write(Hero.ActualHeroPig.PigUrgeToEscape);
                }
                else writer.Write(false);


                if (Hero.ActualHeroQuest != null)
                {
                    writer.Write(true);
                    writer.Write(Hero.ActualHeroQuest.Target.Name);
                    writer.Write(Hero.ActualHeroQuest.AmountMonster);
                    writer.Write(Hero.ActualHeroQuest.TimeToComplite);
                    writer.Write(Hero.ActualHeroQuest.PrizeMoney);
                    writer.Write(Hero.ActualHeroQuest.PrizeItem.Name);
                    writer.Write(Hero.ActualHeroQuest.PrizeExp);
                    writer.Write((int)Hero.ActualHeroQuest.StatusQuest);
                    writer.Write(Hero.ActualHeroQuest.KilledMonstersQuest);
                    writer.Write(Hero.ActualHeroQuest.DayOfDoingQuest);
                }
                else writer.Write(false);






                //Магазин
                writer.Write(City.Magazin.AvailableProductsInMagazin.Count);
                foreach (var item in City.Magazin.AvailableProductsInMagazin)
                {
                    writer.Write(item.Key.Name);
                    writer.Write(item.Value);
                }

                //квесты 

                writer.Write(City.Guildhall.QuestBoard.Count);
                if (City.Guildhall.QuestBoard.Count != 0)
                {
                    foreach (Quest quest in City.Guildhall.QuestBoard)
                    {
                        writer.Write(quest.Target.Name);
                        writer.Write(quest.AmountMonster);
                        writer.Write(quest.TimeToComplite);
                        writer.Write(quest.PrizeMoney);
                        writer.Write(quest.PrizeItem.Name);
                        writer.Write(quest.PrizeExp);
                        writer.Write((int)quest.StatusQuest);
                        writer.Write(quest.KilledMonstersQuest);
                        writer.Write(quest.DayOfDoingQuest);
                    }
                }
                writer.Write(City.GuildhallTimeToRefresh);
                

                //cвинарники
                foreach (Pigsty pigsty in City.PigstyInCity)
                {
                    writer.Write(pigsty.PigsInPigsty.Count);
                    if (pigsty.PigsInPigsty.Count != 0)
                    {
                        foreach (Pig pig in pigsty.PigsInPigsty)
                        {
                            writer.Write(pig.Name);
                            writer.Write(pig.Nickname);
                            writer.Write(pig.Description);
                            writer.Write(pig.Level);
                            writer.Write(pig.Fat);
                            writer.Write(pig.Appetite);
                            writer.Write(pig.PigUrgeToEscape);
                        }
                    }
                }


                //день
                writer.Write(DayInGame.passedDaysInGame);
                writer.Write(DayInGame.countActivities);

            }

        }

    }
}
