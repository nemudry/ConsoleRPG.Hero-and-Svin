using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class HomelessBrownie : Monster, IDefendEnhancing
    {
       public HomelessBrownie()
        {
            Name = "Бездомный Домовой";
            Description = "Бездомный Домовой — монстр, обитающий в лесах неподалёку \nот больших городов. Выглядит как несколько одичавший брауни. " +
                "\nПитается крупными лесными зверушками и героями с героинями. \nС добычей расправляется с помощью острых зубов и какого-либо предмета " +
                "\nдомашней утвари. Разговаривать не умеет, все эмоции выражает \nс помощью рычания. Особых способностей не имеет, атакует " +
                "\nисключительно силой. Хорошо устойчив практически ко всем \nвидам оружия, но легко поддаётся магии. ";
            Level = 1;
            HP = 40;
            Attack = 15;
            Crit = 3;
            Defence = 10;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Крепыш.";
        }


        public void UseEnhancing(Monster monster)
        {
            if (monster is IDefendEnhancing monst) monst.UseDefendEnhancing(monster);
        }

        public int AlreadyTimeDefencedIEnhancing { get; set; }
        public bool IsDefencedIEnhancing { get; set; }
    }
}
