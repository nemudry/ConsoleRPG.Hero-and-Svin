using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class GhostCommunism : Monster, IDefenceСursing
    {
       public GhostCommunism()
        {
            Name = "Призрак Коммунизма";
            Description = "Призрак Коммунизма — не очень сильный, но странный монстр, \nмстящий за погибший коммунизм. Имеет алый окрас, слабую " +
                "\nрасплывчатость, полупрозрачен. Очертаниями напоминает очень худого человека \nв комбинезоне, сапогах и кепке. Иногда является героям, " +
                "\nзакутавшись в плащ. Оставляет за собой характерный след, \nобесцвечивающий поверхность. На спине и груди расположены соответственно серп " +
                "\nи молот, которые на правильных углах обзора образуют одну из забытых \nкультовых эмблем страны Демо-н-кратии. Советуется смотреть " +
                "\nна призрака ровно спереди или сзади, иначе символ видится \nне так, как надо, и фантом негодует. ";
            Level = 3;
            HP = 150;
            Attack = 30;
            Crit = 3;
            Defence = 50;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Усыпляющий.";
        }

        public void UseСursing(Hero hero)
        {
            if (this is IDefenceСursing monster) monster.UseDefenceСursing(hero);
        }

        public int AlreadyTimeDefenceСursing { get; set; }
        public bool IsDefenceСursing { get; set; }

    }
}
