using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class PerformerEvilRock : Monster, IAttackEnhancing, IDefenceСursing
    {
       public PerformerEvilRock()
        {
            Name = "Исполнитель Злого Рока";
            Description = "Кто повстречал его на пути, видел что-то особенное, что-то своё. \nВедь он многолик! Представая перед героем, " +
                "\nИсполнитель Злого Рока с великой миссией взывал к его божеству. \nИсполнить Злой Рок даже в самых отдаленных уголках мироздания " +
                "\nнесмотря на преграды и препятствия! А что думал? Вот сбежишь, \nи он забудет всё, а нет, он запомнил тебя! Да-да, тебя! Жди, " +
                "\nуже улетел за тобой грозовой тучей! Муа-ха-ха! ";
            Level = 6;
            HP = 300;
            Attack = 90;
            Crit = 3;
            Defence = 80;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Берсерк, Усыпляющий.";
        }


        public void UseEnhancing(Monster monster)
        {
            if (monster is IAttackEnhancing monst) monst.UseAttackEnhancing(monster);
        }


        public void UseСursing(Hero hero)
        {
            if (this is IDefenceСursing monster) monster.UseDefenceСursing(hero);
        }

        public int AlreadyTimeDefenceСursing { get; set; }
        public bool IsDefenceСursing { get; set; }
    }
}
