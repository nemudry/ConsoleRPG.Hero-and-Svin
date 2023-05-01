using SVINspace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static SVINspace.Hero;
using System.Xml.Linq;

namespace SVINspace
{
    public class GameMenu
    {
        public statusGame StatusGame { get; set; }
        public enum statusGame
        {
            НоваяИгра,
            ИграНачата,
            СохранениеЗагружено,
            ИграЗакончена
        }
        

        public GameMenu ()
        {
            StatusGame = statusGame.НоваяИгра;
        }


        public virtual void StartGameMenu()
        {

            RPG_SVIN newRPG_SVIN = new RPG_SVIN();
            do
            {
                int answerWhatToDoInGameMenu;
                do
                {

                    Color.Green("***SVIN And Hero***");
                    Console.WriteLine();


                    Color.Cyan("Выберите действие?");
                    Console.WriteLine("[1] Начать новую игру \n[2] Продолжить игру \n[3] Сохранить игру  " +
                        "\n[4] Загрузить игру \n[-1] Выйти без сохранения");
                    int.TryParse(Console.ReadLine(), out answerWhatToDoInGameMenu);

                    if (answerWhatToDoInGameMenu == -1)
                    {
                        StatusGame = statusGame.ИграЗакончена;
                        Color.Green("Выход выполнен.");
                        return;
                    }

                    if (answerWhatToDoInGameMenu < 1 || answerWhatToDoInGameMenu > 4)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }

                } while (answerWhatToDoInGameMenu < 1 || answerWhatToDoInGameMenu > 4);


                if (answerWhatToDoInGameMenu == 1)
                {
                    Console.Clear();
                    Hero newHero = CreateHero();
                    newRPG_SVIN = new RPG_SVIN(newHero);
                    StatusGame = statusGame.ИграНачата;

                    Color.Green("***Нажмите клавишу для начала игры***");
                    Console.ReadKey();
                    Console.Clear();

                    newRPG_SVIN.StartGame();
                }

                if (answerWhatToDoInGameMenu == 2)
                {
                    if (StatusGame == statusGame.СохранениеЗагружено || StatusGame == statusGame.ИграНачата)
                    {
                        Color.Green("***Нажмите клавишу для начала игры***");
                        Console.ReadKey();
                        Console.Clear();

                        newRPG_SVIN.StartGame();
                    }
                    else
                    {
                        Console.Clear();
                        Color.Red("Отсутствует загруженная игра. Загрузите сохранение.");
                        Console.WriteLine();
                    }

                }

                if (answerWhatToDoInGameMenu == 3)
                {
                    if (StatusGame != statusGame.НоваяИгра)
                    {
                        Console.Clear();
                        CreateSaveGame saveGame = new CreateSaveGame(newRPG_SVIN.Hero, newRPG_SVIN.GotemsvinCity, newRPG_SVIN.DayInGame);
                        saveGame.StartSaving();
                        Color.Green("Игра сохранена.");
                        Console.WriteLine();
                    }

                    else
                    {
                        Console.Clear();
                        Color.Red("Отсутствует игра для сохранения. Начните новую игру или загрузите сохранение.");
                        Console.WriteLine();
                    }

                }

                if (answerWhatToDoInGameMenu == 4)
                {
                    Console.Clear();
                    LoadSaveGame loadGame = new LoadSaveGame(newRPG_SVIN.GameItems, newRPG_SVIN.Monsters, newRPG_SVIN.Pigs);
                    loadGame.StartLoading(out Hero hero, out City gotemsvinCity, out DayInGame dayInGame);

                    newRPG_SVIN.Hero = hero;           
                    newRPG_SVIN.GotemsvinCity = gotemsvinCity;
                    newRPG_SVIN.DayInGame = dayInGame;
                    

                    StatusGame = statusGame.СохранениеЗагружено;

                    Color.Green("Игра загружена.");
                    Console.WriteLine();
                }

            } while (StatusGame != statusGame.ИграЗакончена);



            Hero CreateHero()
            {
                int chosenClass;
                do
                {
                    Color.Green("***Создание героя***");
                    Console.WriteLine();

                    Color.Cyan("Выберите класс:");
                    Console.WriteLine("Маги прекрасно атакуют, но слабы здоровьем и защитой." +
                        "\nВоры слабо атакуют и хилые, но умеючи наносят критические удары исподтишка." +
                        "\nВоин сбалансированы, не имеют сильных и слабых сторон.");
                    Console.WriteLine();

                    Color.Cyan("Выберите класс:");

                    for (int i = 0; i < (int)Hero.classHero.Любая - 1;)
                    {
                        Console.WriteLine($"[{++i}] {(Hero.classHero)i}.");
                    }

                    int.TryParse(Console.ReadLine(), out chosenClass);

                    if (chosenClass < 1 || chosenClass >= (int)Hero.classHero.Любая)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }

                } while (chosenClass < 1 || chosenClass >= (int)Hero.classHero.Любая);

                Hero.classHero heroClass = (Hero.classHero)(chosenClass);
                Console.WriteLine();

                int chosenRace;
                do
                {
                    Color.Cyan("Выберите расу:");

                    Console.WriteLine("Эльфы прекрасно атакуют, но слабы защитой." +
                        "\nГномы живучи, но медлительны, и поэтому слабо атакуют." +
                        "\nЛюди сбалансированы, не имеют сильных и слабых сторон.");
                    Console.WriteLine();

                    for (int i = 0; i < (int)Hero.raceHero.Любая - 1;)
                    {
                        Console.WriteLine($"[{++i}] {(Hero.raceHero)i}.");
                    }

                    int.TryParse(Console.ReadLine(), out chosenRace);

                    if (chosenRace < 1 || chosenRace >= (int)Hero.raceHero.Любая)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }

                } while (chosenRace < 1 || chosenRace >= (int)Hero.raceHero.Любая);

                Hero.raceHero heroRace = (Hero.raceHero)(chosenRace);
                Console.WriteLine();

                string heroName;
                do
                {
                    Color.Cyan("Выберите имя вашего героя:");

                    heroName = Console.ReadLine();

                    if (heroName?.Length < 3)
                    {
                        Color.Red("Введенное значение неверно.");
                        Color.Red("Имя должно состоять как менее из 3 символов.");
                        Console.WriteLine();
                    }

                } while (heroName?.Length < 3);
                Console.WriteLine();



                Hero newHero = null;
                switch (heroClass)
                {
                    case classHero.Воин:
                        switch (heroRace)
                        {
                            case raceHero.Человек:
                                newHero = new WarriorMan(heroName);
                                break;
                            case raceHero.Эльф:
                                newHero = new WarriorElf(heroName);
                                break;
                            case raceHero.Гном:
                                newHero = new WarriorGnom(heroName);
                                break;
                            default:
                                break;
                        }
                        break;
                    case classHero.Маг:
                        switch (heroRace)
                        {
                            case raceHero.Человек:
                                newHero = new MageMan(heroName);
                                break;
                            case raceHero.Эльф:
                                newHero = new MageElf(heroName);
                                break;
                            case raceHero.Гном:
                                newHero = new MageGnom(heroName);
                                break;
                            default:
                                break;
                        }
                        break;
                    case classHero.Вор:
                        switch (heroRace)
                        {
                            case raceHero.Человек:
                                newHero = new ThiefMan(heroName);
                                break;
                            case raceHero.Эльф:
                                newHero = new ThiefElf(heroName);
                                break;
                            case raceHero.Гном:
                                newHero = new ThiefGnom(heroName);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                return newHero;
            }
        }


        



    }
}
