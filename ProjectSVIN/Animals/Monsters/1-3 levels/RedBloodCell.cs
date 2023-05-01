using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class RedBloodCell : Monster, IAttackСursing
    {
       public RedBloodCell()
        {
            Name = "Красный Кровяной Телец";
            Description = "Давным-давно существовал монстр таких впечатляющих размеров, \nчто кислород по его крови переносили на тележечках " +
                "\nКрасные Кровяные Тельцы. И бился с ним даже не богатырь, \nа самый настоящий бог, и шла эта битва три дня и три ночи. И пал монстр, " +
                "\nи вытекла кровь его, и разбежались Тельцы, посбрасывав свои тележечки. \nС тех пор нападают они на героев, и убивают их герои, " +
                "\nа если кому посчастливится убить Тельца с тележечкой, то на дне её \nон непременно найдёт особо жирный трофей.  ";
            Level = 2;
            HP = 80;
            Attack = 20;
            Crit = 3;
            Defence = 30;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Изнуряющий.";
        }

        public void UseСursing(Hero hero)
        {
            if (this is IAttackСursing monster) monster.UseAttackСursing(hero);
        }

        public int AlreadyTimeAttackСursing { get; set; }
        public bool IsAttackСursing { get; set; }

    }
}
