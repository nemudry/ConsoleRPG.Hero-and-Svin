using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class BuryingAngel : Monster, IDefendEnhancing, IHealthRecoveryEnhancing, IAttackСursing
    {
       public BuryingAngel()
        {
            Name = "Ангел-Хоронитель";
            Description = "Устрашающий монстр Ангел-Хоронитель, в руках которого \nкарательное оружие — божественная лопата, помогающая монстру " +
                "\nне только гасить героя, но и закапывать. Внешне жесток и беспощаден, \nно на самом деле любит белые розы, котят и кефир. Говорят, " +
                "\nкогда-то, ещё до обледенения, Ангелов-Хоронителей создали боги \nдля передачи карательной воли героям. Но после изобретения более быстрых " +
                "\nспособов связи и воздействия Хоронители одичали, \nзаняв нишу в монстрофауне окрестностей мира.  ";
            Level = 8;
            HP = 800;
            Attack = 130;
            Crit = 20;
            Defence = 100;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Крепыш, Регенерирующий, Изнуряющий.";
        }

        public void UseEnhancing(Monster monster)
        {
            if (monster is IDefendEnhancing monst) monst.UseDefendEnhancing(monster);
            if (monster is IHealthRecoveryEnhancing monst2) monst2.UseHealthRecoveryEnhancing(monster);
        }

        public int AlreadyTimeDefencedIEnhancing { get; set; }
        public bool IsDefencedIEnhancing { get; set; }


        public void UseСursing(Hero hero)
        {
            if (this is IAttackСursing monster) monster.UseAttackСursing(hero);
        }

        public int AlreadyTimeAttackСursing { get; set; }
        public bool IsAttackСursing { get; set; }
    }
}
