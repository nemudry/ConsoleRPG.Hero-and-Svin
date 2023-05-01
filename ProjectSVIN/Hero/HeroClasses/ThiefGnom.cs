using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SVINspace
{
    public class ThiefGnom : Hero, IGnomEffects, IThiefEffects
    {

        public ThiefGnom(string name)
        {
            StatusHero = statusHero.Жив;
            Name = name;

            ClassHero = Hero.classHero.Вор;
            RaceHero = Hero.raceHero.Гном;

            Level = 1;
            Rank = 0;
            HP = 30;
            Mana = 10;
            Exp = 0;
            Defence = 10;
            Attack = 5;
            MainFeatures = (HP, Mana, Attack, Defence, Crit);
            Crit = 10;
            Money = 700;

            HeroInventory = new Bag();

            HeroWeapon = new Bare_RightHand();
            HeroShield = new Bare_LeftHand();
            HeroHelmet = new Bare_Head();
            HeroArmor = new Bare_body();
            HeroAmulet = new Bare_neck();

            HeroPigs = new List<Pig>();
            ActualHeroPig = null;
            ActualHeroQuest = null;

            RaceEffect = Hero.heroEffect.МожноЮзать;
            ClassEffect = Hero.heroEffect.МожноЮзать;
        }


        public ThiefGnom(string name, int level, int rank, int hp, int mana, int exp, int defence, int attack, int crit, int money, Hero.statusHero status,
            Inventory inventory, Weapon weapon, Shield shield, Helmet helmel, Armor armor, Amulet amulet,
            List<Pig> pigs, Pig actualPig, Quest actualQuest)            
        {
            StatusHero = statusHero.Загружен;
            Name = name;

            ClassHero = Hero.classHero.Вор;
            RaceHero = Hero.raceHero.Гном;

            Level = level;
            Exp = exp;
            Rank = rank;


            HP = hp;
            Mana = mana;
            Defence = defence;
            Attack = attack;
            Crit = crit;
            MainFeatures = (HP, Mana, Attack, Defence, Crit);

            Money = money;

            HeroWeapon = weapon;
            HeroShield = shield;
            HeroHelmet = helmel;
            HeroArmor = armor;
            HeroAmulet = amulet;
            HeroInventory = inventory;

            HeroPigs = pigs;
            ActualHeroPig = actualPig;
            ActualHeroQuest = actualQuest;

            StatusHero = status;

            RaceEffect = Hero.heroEffect.МожноЮзать;
            ClassEffect = Hero.heroEffect.МожноЮзать;
        }

        private int level;
        public override int Level
        {
            get => level;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    level = value;
                }
                else
                {
                    level = value;
                    if (Level != 1)
                    {
                        Color.Red("***Внимание!***");
                        Color.Green($"Герой {Name} поднял уровень! Уровень героя - {Level}.");
                        Console.WriteLine();

                        MainFeatures = (HP + 30, Mana + 10, Attack + 2, Defence + 5, Crit + 1);
                        (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                    }
                }
            }
        }

        public void UseRaceEffect(Hero hero)
        {
            if (hero is IGnomEffects h) h.UseDefendEnhancing(hero);
        }
        public int AlreadyTimeDefencedIEnhancing { get; set; }

        public int AlreadyTimeThiefEnhancing { get; set; }
    }
}
