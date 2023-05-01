using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class BikerCrypt : Monster, IAttackEnhancing, IHealthСursing
    {
       public BikerCrypt()
        {
            Name = "Байкер Из Склепа";
            Description = "Непонятно, каким образом в сей мир занесло байкеров, но они \nпрочно обосновались в столь несуразном измерении, " +
                "\nидеально им подходящем. Герою стоит быть крайне осторожным, \nпроходя мимо склепов и фамильных усыпальниц. Если он случайно разбудит " +
                "\nстоль свирепого монстра, то ему придётся несладко. Хотя, герой \nвсегда может выкрутиться и улизнуть под предлогом купить выпить, " +
                "\nибо нет в природе байкера, равнодушного к спиртному. Байкер из склепа \nвсегда небрит, нечёсан, он всегда в плохом настроении, " +
                "\nведь с ним нет его любимого байка.В руке его вечно разбитая бутылка, \nпоэтому он вдвойне в плохом настроении.Узнать байкера из склепа " +
                "\nможно издалека, по перегару, по блестящей заклёпками и зачастую рваной косухе, \nнадетой на голое пузо, что, при этом, не мешает ему спать " +
                "\nхолодными зимними ночами в сыром склепе. Его, наверное, можно понять, \nнедаром он заслужил репутацию опасного монстра. ";
            Level = 6;
            HP = 450;
            Attack = 70;
            Crit = 3;
            Defence = 100;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Берсерк, Ядовитый.";
        }

        public void UseEnhancing(Monster monster)
        {
            if (monster is IAttackEnhancing monst) monst.UseAttackEnhancing(monster);
        }

        public void UseСursing(Hero hero)
        {
            if (this is IHealthСursing monster) monster.UseHealthСursing(hero);
        }

        public int AlreadyTimeHealthСursing { get; set; }
        public bool IsHealthСursing { get; set; }

    }
}
