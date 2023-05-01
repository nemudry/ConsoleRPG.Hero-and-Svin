using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class NoLongerBuddha : Monster, IHealthRecoveryEnhancing, IHealthСursing
    {
       public NoLongerBuddha()
        {
            Name = "Больше Не Будда";
            Description = "Жил когда-то монстр… Нет, не жил, а спал. Хорошо, качественно дрых на подстилке из листьев лавровых, гоферовых и денежных " +
                "\nдеревьев. И снился ему мир весь, с Администраторами, ковчегами, лопатами и грибами в том числе. Но вот, в результате громкого крика, " +
                "\nстука и топота в каком-то гильдсовете или операционной некие декабристы хирурги разбудили его-таки. И совершенно зря. Ведь если бы " +
                "\nмонстр этот ещё мог немножечко поспать, то уж точно бы выспался, и тогда было бы в его сновидениях полное счастье — нужные запчасти " +
                "\nлаборантам, вечные гаранты, и, конечно, никаких проигрышей на Арене и пиратства. Однако история, как мы знаем, сослагательного наклонения не ведает. ";
            Level = 4;
            HP = 180;
            Attack = 40;
            Crit = 10;
            Defence = 70;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Регенерирующий, Ядовитый.";
        }


        public void UseСursing(Hero hero)
        {
            if (this is IHealthСursing monster) monster.UseHealthСursing(hero);
        }

        public int AlreadyTimeHealthСursing { get; set; }
        public bool IsHealthСursing { get; set; }


        public void UseEnhancing(Monster monster)
        {
            if (monster is IHealthRecoveryEnhancing monst) monst.UseHealthRecoveryEnhancing(monster);
        }
    }
}
