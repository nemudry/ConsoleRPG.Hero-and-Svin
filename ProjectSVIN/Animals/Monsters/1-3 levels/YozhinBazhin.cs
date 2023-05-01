using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class YozhinBazhin : Monster, IAttackEnhancing
    {
       public YozhinBazhin()
        {
            Name = "Йожин С Бажин";
            Description = "Большой и страшный болотный монстр, герой одноименной песни \nна чешском, в которой описывается вся жуть и смертоносность " +
                "\nэтого хтонического существа, а также средства борьбы с ним. \nНе стоит путать йожинов и ёжиков, Последние не вылазят ночью из топи, " +
                "\nчтобы рвать и пожирать беспечных путников.";
            Level = 1;
            HP = 40;
            Attack = 15;
            Crit = 3;
            Defence = 10;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Берсерк.";
       }



        
        public void UseEnhancing (Monster monster)
        {
            if (monster is IAttackEnhancing monst) monst.UseAttackEnhancing(monster);
        }

    }
}
