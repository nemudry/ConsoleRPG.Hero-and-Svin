using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace SVINspace
{
    public class RPG_SVIN
    {
        public List<Monster> Monsters { get; set; }
        public List<Pig> Pigs { get; set; }
        public List<Item> GameItems { get; set; }
        public City GotemsvinCity { get; set; }
        public DayInGame DayInGame { get; set; }
        public Hero Hero { get; set; }

        public statusRPG_SVIN StatusRPG_SVIN { get; set; }
        public enum statusRPG_SVIN
        {
            ИграПродолжается,
            ИграЗакончена
        }      


        public RPG_SVIN()
        {
            StatusRPG_SVIN = statusRPG_SVIN.ИграПродолжается;
            Monsters = new List<Monster>()
            {
                new YozhinBazhin(),
                new DamnSciatica(),
                new GhostCommunism(),
                new GrandpaWithPaddle(),
                new HomelessBrownie(),
                new RedBloodCell(),


                new BikerCrypt(),
                new BipolarBear(),
                new NoLongerBuddha(),
                new PerformerEvilRock(),
                new SecrecyStamp(),
                new VargPeople(),


                new BuryingAngel(),
                new HannibalRector(),
                new SizSlug(),
            };

            Pigs = new List<Pig>()
            {
                new AngryPig(),
                new LazyPig(),
                new RappingPig(),
                new YellingPig(),
                new СunningPig(),
            };

            List<Item> gameBuffs = new List<Item>()
            {
                new Attack_poisonLarge (),
                new Attack_poisonMedium (),
                new Attack_poisonSmall (),
                new Defence_poisonLarge (),
                new Defence_poisonMedium (),
                new Defence_poisonSmall (),
                new Health_poisonLarge (),
                new Health_poisonMedium (),
                new Health_poisonSmall (),

                new Attack_potionLarge (),
                new Attack_potionMedium (),
                new Attack_potionSmall (),
                new Crit_potionLarge (),
                new Crit_potionMedium (),
                new Crit_potionSmall (),
                new Defence_potionLarge (),
                new Defence_potionMedium (),
                new Defence_potionSmall (),
                new Exit_potionSmall (),
                new Health_potionLarge (),
                new Health_potionMedium (),
                new Health_potionSmall (),
                new Mana_potionLarge (),
                new Mana_potionMedium (),
                new Mana_potionSmall (),

            };

            List<Item> gameEquipments = new List<Item>()
            {
                new Bare_neck(),
                new CompassIvanSusanin (),
                new GarlicChain (),
                new IconIAmHero (),
                new NecklaceGalaxy (),
                new PortraitOfPresident (),
                new SheriffStar (),
                new SuffocatingFrill (),
                new UraniumKeychain (),


                new ArmorJelly (),
                new Bare_body (),
                new ChainMailOfPaperClips (),
                new InflatableVest (),
                new StraitjacketChainMail (),


                new Bare_Head (),
                new ChessCrown (),
                new CrownOfNazgul (),
                new PapalTiara (),
                new PinkGlasses (),


                new AbsorbingElement (),
                new Bare_LeftHand (),
                new BulletproofMonk (),
                new GoalkeeperShield (),
                new IroningBoard (),


                new Bare_RightHand (),
                new DiamondWoodenSword (),
                new Kotopult (),
                new Lovelasso (),
                new PlasticFork (),


                new Backpack (),
                new Bag (),
                new BottomlessBag (),
                new Rucksack (),

            };

            List<Item> gameTropheis = new List<Item>()
            {
                new The_paradise_apple_s_core (),
                new WrongHoney (),


                new HandStraightener (),
                new HutEgg (),
                new OobserverEye (),
                new YoshkinCode (),


                new AbstractTrophy (),
                new AmuletTransmigrationShower (),
                new BottleGhostShip (),
                new BrokenPixel (),
                new ChillingDrink (),
                new FleaHorseshoe (),
                new OlegThings (),
                new PieceGraniteScience (),


                new BactericidalPsalter (),
                new BookAttackLazinessAndPunishment (),
                new BottleExpiredGenie (),
                new BottleStationeryTape (),
                new DeckVideoCards (),
                new DiagonalMonitor (),
                new DieHard (),
                new InflatableDrinkingCompanion (),
                new MastersYodaQuotesCollection (),
                new MedalForAdviceDrowning (),
                new NotesMadman (),
                new PackChewingTar (),
                new PaperPassword (),
                new SilentBob (),
                new SizeFiveBunch (),
                new WirelessCableMeter (),
            };

            GameItems = new List<Item>();
            GameItems.AddRange(gameBuffs);
            GameItems.AddRange(gameEquipments);
            GameItems.AddRange(gameTropheis);

            GotemsvinCity = new Gotemsvin(GameItems, Monsters);

            DayInGame = new DayInGame();
        }

        public RPG_SVIN(Hero hero)
            : this()
        {
            Hero = hero;
            DayInGame = new DayInGame(hero, GotemsvinCity);
        }



        public void StartGame()
        {
            do
            {
                int answerWhatToDo;
                do
                {
                    IsEndGame();
                    if (StatusRPG_SVIN == statusRPG_SVIN.ИграЗакончена) return;

                    if (Hero.StatusHero == Hero.statusHero.Вдолгах)
                    {
                        Hero.PayDebts(Pigs, Monsters, GameItems);

                        if (Hero.StatusHero == Hero.statusHero.Мертв)
                        {
                            Hero.WaitRebornHero(DayInGame, GotemsvinCity);
                        }
                    }

                    if (Hero.StatusHero == Hero.statusHero.СражениеСудногоДня)
                    {
                        Doomsday doomsday = new Doomsday(Hero, GotemsvinCity, Monsters, GameItems);
                        doomsday.StartDoomsday();


                        if (Hero.StatusHero == Hero.statusHero.Мертв)
                        {
                            Hero.WaitRebornHero(DayInGame, GotemsvinCity);
                        }

                        if (Hero.Rank > 299) StatusRPG_SVIN = statusRPG_SVIN.ИграЗакончена;
                    }






                    DayInGame.DayInfo();

                    if (Hero.ActualHeroQuest != null)
                    {
                        Color.Green("Взятый квест:");
                        Console.WriteLine(Hero.ActualHeroQuest);
                        Color.Cyan($"День выполнения: {Hero.ActualHeroQuest.DayOfDoingQuest}/{Hero.ActualHeroQuest.TimeToComplite}.");
                        Color.Cyan($"Монстров убито: {Hero.ActualHeroQuest.KilledMonstersQuest}/{Hero.ActualHeroQuest.AmountMonster}.");
                        if (Hero.ActualHeroQuest.StatusQuest == Quest.statusQuest.Провалено) Color.Red("Провалено!");
                        if (Hero.ActualHeroQuest.StatusQuest == Quest.statusQuest.Выполнено) Color.Green("Выполнено!");
                        Console.WriteLine();
                    }


                    Color.Cyan("Выберите действие?");
                    Console.WriteLine("[1] Начать охоту \n[2] Открыть инвентарь \n[3] Пойти в город " +
                        "\n[4] Отправиться на поиски клада  \n[5] Ждать 1 день \n[-1] Выйти в главное меню игры");
                    int.TryParse(Console.ReadLine(), out answerWhatToDo);

                    if (answerWhatToDo == -1)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerWhatToDo < 1 || answerWhatToDo > 5)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }

                } while (answerWhatToDo < 1 || answerWhatToDo > 5);
                Console.Clear();




                if (answerWhatToDo == 1)
                {

                    Field field = new Field(Hero, Monsters, Pigs, GameItems);
                    do
                    {
                        Console.Clear();

                        DayInGame.DayInfo();

                        field.GoFindMonstersAndPigs();

                        DayInGame = DayInGame.TikTak(Hero, GotemsvinCity);

                        if (Hero.StatusHero == Hero.statusHero.Мертв)
                        {
                            Hero.WaitRebornHero(DayInGame, GotemsvinCity);
                        }

                        if (!IsContinueOutdoorActivity()) break;
                    } while (true);
                }



                if (answerWhatToDo == 2)
                {
                    Hero.OpenInventory();
                }



                if (answerWhatToDo == 3)
                {
                    GotemsvinCity.GoToCity(DayInGame, Hero);
                    DayInGame = DayInGame.TikTak(Hero, GotemsvinCity);
                }



                if (answerWhatToDo == 4)
                {
                    TreasureHunting treasureHunting = new TreasureHunting(Hero, Pigs, Monsters, GameItems);

                    do
                    {
                        Console.Clear();

                        DayInGame.DayInfo();

                        treasureHunting.StartTreasureHunting();

                        DayInGame = DayInGame.TikTak(Hero, GotemsvinCity);

                        if (!IsContinueOutdoorActivity()) break;
                    } while (true);
                }



                if (answerWhatToDo == 5)
                {
                    Hero.WaitOneDay(DayInGame, GotemsvinCity);
                }





                bool IsContinueOutdoorActivity()
                {
                    int answerIsContinueHunt;
                    do
                    {
                        Color.Cyan("Продолжить [1] или закончить [2]?");
                        int.TryParse(Console.ReadLine(), out answerIsContinueHunt);

                        if (answerIsContinueHunt < 1 || answerIsContinueHunt > 2)
                        {
                            Color.Red("Введенное значение неверно.");
                            Console.WriteLine();
                        }

                    } while (answerIsContinueHunt < 1 || answerIsContinueHunt > 2);
                    Console.Clear();

                    if (answerIsContinueHunt == 1) return true;
                    else return false;
                }



                void IsEndGame()
                {
                    int answerWhatToDo = 0;
                    if (StatusRPG_SVIN == statusRPG_SVIN.ИграЗакончена)
                    {
                        Console.Clear();
                        Color.Green($"\n************** \n***Внимание*** \n**************.");
                        Console.WriteLine();
                        Color.Cyan($"Герой {Hero.Name} достиг 300 ранга!");
                        Color.Cyan($"В качестве признательности за заслуги граждане пожизненно вносят героя {Hero.Name} в совет города.");
                        Color.Cyan($"Герой {Hero.Name} сложил оружие. Всю последующую жизнь он провел, пытаясь выиграть в турнире на самую толстую хрюшку.");
                        Color.Cyan($"Но это уже другая история...");
                        Console.WriteLine();


                        Color.Red("Конец игры.");
                        Console.WriteLine();

                        do
                        {
                            Color.Cyan("Выберите действие?");
                            Console.WriteLine("[-1] Выйти в главное меню игры");

                            int.TryParse(Console.ReadLine(), out answerWhatToDo);

                            if (answerWhatToDo == -1)
                            {
                                Console.Clear();
                                return;

                            }

                            if (answerWhatToDo < 1 || answerWhatToDo > 1)
                            {
                                Color.Red("Введенное значение неверно.");
                                Console.WriteLine();
                            }

                        } while (answerWhatToDo < 1 || answerWhatToDo > 1);
                        Console.Clear();

                    }

                }

            } while (true);
        }







     }








    
}
