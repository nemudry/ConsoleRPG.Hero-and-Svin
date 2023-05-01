using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class DamnSciatica : Monster, IHealthСursing
    {
       public DamnSciatica()
        {
            Name = "Проклятый Радикулит";
            Description = "Проклятый Радикулит — злобная скрюченная болотная тварь, \nкоторая гнездится в сырых местах и нападает на прохожих героев, " +
                "\nс целью поработить их и заставить добывать из низких чахлых ёлок еловое масло. \nНикто не знает, удалось ли Проклятому Радикулиту " +
                "\nхоть раз достичь своей цели, но, судя по многочисленным жалобам, он порядком \nвсех достал. Приближающегося Радикулита легко опознать " +
                "\nпо оханью, скрипению, кашлю и прочим признакам существ, \nобитающих в зловонных болотах.  ";
            Level = 2;
            HP = 50;
            Attack = 25;
            Crit = 20;
            Defence = 25;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Ядовитый.";
        }

        public void UseСursing(Hero hero)
        {
            if (this is IHealthСursing monster) monster.UseHealthСursing(hero);
        }

        public int AlreadyTimeHealthСursing { get; set; }
        public bool IsHealthСursing { get; set; }

    }
}
