using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class SizSlug : Monster, IHealthEnhancing, IDefendEnhancing, IAttackСursing, IHealthСursing
    {
       public SizSlug()
        {
            Name = "Сизень";
            Description = "Все знают историю про титана Атланта, который на своих бедных плечах \nдержит небосвод. Мало кто знает про другого титана - " +
                "\nСиза, который прослыл первым и последним гигантом нетрадиционной ориентации. \nБудучи не шибко обеспокоенным своей безопасностью, " +
                "\nтитан этот вел довольно распутный образ жизни и впоследствии прославился \nисключительно сизнями. Сизни - это в бытность свою изначально " +
                "\nобычные венерические слизни, которые нашли пристанище в дубле гиганта. \nСо временем, эти слизни эволюционировали в самых страшных " +
                "\nи непобедимых монстров. Этому способствовало несколько обстоятельсв. \n1. Огромное дупло Сиза, с постоянным потоком свежего воздуха " +
                "\n(дупло открывали ежедневно) с одной стороны, и питательными веществами с другой. \n2. Каждодневное лицезрение различных предметов, " +
                "\nкоторыми проветривалось дупло. 3. Сидячий образ жизни гиганта. \nВ итоге обычные небольшие венерические слизни эволюционировали " +
                "\nв гигантских обезумевших пидор-слизней, то бишь сизней... \nПо вечерам, собравшись вокруг костра, герои, повстречавшие сизней " +
                "\n(и которым посчастливилось пережить эту встречу), печально рассказывают друг другу, \nчто это не вина сизней - в том что они такие. " +
                "\nНикто в здравом уме не останется, если бы в течение лет видел то, что видели \nэти бедные слизни в заду великана. Говорят, " +
                "\nкогда титан ложится спать, целые толпы сизней прорываются сквозь его дупло, \nсбегают по его ногам на землю - и бегут, бегут, бегут - в мир, " +
                "\nуничтожая в своем безумстве все и всех на своем пути.";
            Level = 9;
            HP = 1200;
            Attack = 130;
            Crit = 3;
            Defence = 130;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Эскулап, Крепыш, Изнуряющий, Ядовитый.";
        }

        public void UseEnhancing(Monster monster)
        {
            if (monster is IHealthEnhancing monst) monst.UseHealthEnhancing(monster);
            if (monster is IDefendEnhancing monst2) monst2.UseDefendEnhancing(monster);
        }


        public int AlreadyTimeDefencedIEnhancing { get; set; }
        public bool IsDefencedIEnhancing { get; set; }


        public void UseСursing(Hero hero)
        {
            if (this is IAttackСursing monster) monster.UseAttackСursing(hero);
            if (this is IHealthСursing monster2) monster2.UseHealthСursing(hero);
        }

        public int AlreadyTimeAttackСursing { get; set; }
        public bool IsAttackСursing { get; set; }

        public int AlreadyTimeHealthСursing { get; set; }
        public bool IsHealthСursing { get; set; }
    }
}
