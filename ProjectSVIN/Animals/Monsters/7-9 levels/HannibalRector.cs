using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class HannibalRector : Monster, IAttackEnhancing, IHealthСursing, IDefenceСursing
    {
       public HannibalRector()
        {
            Name = "Ганнибал-ректор";
            Description = "Очень и очень опасный монстр. Может быть узнан по пенсне \nи видавшему виды портфелю. Вооружен указкой. Устраивает засады " +
                "\nна пути героев, развешивая плакаты, схемы и диаграммы, а когда \nпотерявший бдительность и не в меру любопытный герой начинает их " +
                "\nразглядывать, приступает к чтению длиннейшего заклинания, именуемого «лекция», \nкоторое оказывает на слушающего мощное снотворное действие." +
                "\nСон этот никак нельзя назвать здоровым, ибо заканчивается он \nтрагически, а если герою каким-то чудом удается спастись, " +
                "\nто уж вывих челюсти, как следствие зевоты, ему гарантирован. ";
            Level = 7;
            HP = 500;
            Attack = 80;
            Crit = 3;
            Defence = 120;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Берсерк, Ядовитый, Усыпляющий.";
        }

        public void UseEnhancing(Monster monster)
        {
            if (monster is IAttackEnhancing monst) monst.UseAttackEnhancing(monster);
        }


        public void UseСursing(Hero hero)
        {
            if (this is IHealthСursing monster) monster.UseHealthСursing(hero);
            if (this is IDefenceСursing monster2) monster2.UseDefenceСursing(hero);
        }

        public int AlreadyTimeHealthСursing { get; set; }
        public bool IsHealthСursing { get; set; }

        public int AlreadyTimeDefenceСursing { get; set; }
        public bool IsDefenceСursing { get; set; }
    }
}
