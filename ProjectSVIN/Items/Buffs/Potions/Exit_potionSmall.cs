using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Exit_potionSmall : Potion
    {
        public Exit_potionSmall()
        {
            Name = "Зелье невидимости";
            Description = "Делает героя невидимым. Позволяет незаметно ускользнуть с поля боя";
            Price = 500;
            RareLevel = Rareness.Эпическая;
        }

        public override void UsePotion(Hero hero)
        {
            hero.StatusHero = Hero.statusHero.БежитИзБитвы;
            Color.Green($"Герой {hero.Name} становится невидимым. Он сбегает с поля боя.");
            Console.WriteLine();

        }


    }
}
