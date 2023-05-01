using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class BipolarBear : Monster, IDefendEnhancing, IDefenceСursing
    {
       public  BipolarBear ()
        {
            Name = "Биполярный медведь";
            Description = "Биполярный Медведь — хищный монстр семейства медвежьих, родственник полярного медведя. " +
                "Мабританское название «Ursus Ultrices» переводится как «медведь электрический». Характер — нордический. " +
                "Весит он 400–450 кг, длина тела 200–250 см, высота в холке до 130–150 см. Биполярного Медведя от других медведей " +
                "отличают длинная шея, плоская голова и густой мех, натирая который о земную ось, он может вырабатывать электричество. " +
                "Кроме того, у биполярных медведей вдоль всего тела и по периметру передних лап расположены почкообразные электрические органы, " +
                "способные накапливать большое количество электроэнергии. Подошвы ног подбиты шерстью, чтобы вырабатывать электричество " +
                "даже во время ходьбы. Передняя часть лап оторочена жёсткими щетинками, с помощью которых монстр, в случае необходимости, " +
                "может заземляться. Правая сторона тела и лапа соответствует аноду и имеет значение «+», а левая, соответственно, " +
                "является катодом и имеет значение «-». Когти и клыки редуцированы. ";
            Level = 4;
            HP = 250;
            Attack = 50;
            Crit = 3;
            Defence = 60;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Крепыш, Усыпляющий.";
        }

        public void UseEnhancing(Monster monster)
        {
            if (monster is IDefendEnhancing monst) monst.UseDefendEnhancing(monster);
        }

        public int AlreadyTimeDefencedIEnhancing { get; set; }
        public bool IsDefencedIEnhancing { get; set; }



        public void UseСursing(Hero hero)
        {
            if (this is IDefenceСursing monster) monster.UseDefenceСursing(hero);
        }

        public int AlreadyTimeDefenceСursing { get; set; }
        public bool IsDefenceСursing { get; set; }
    }
}
