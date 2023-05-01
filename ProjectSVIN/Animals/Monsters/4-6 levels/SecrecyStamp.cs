using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class SecrecyStamp : Monster, IHealthEnhancing, IAttackСursing
    {
       public SecrecyStamp()
        {
            Name = "Гриф Секретности";
            Description = "Над седым Разминным Полем гордо реет двумерный монохромный объект, \nотдалённо напоминающий стилизованное изображение " +
                "\nхищной птицы с раскинутыми крыльями и растопыренными когтями. \nПоскольку объект практически невесом, восходящие потоки поднимают его " +
                "\nна немыслимую высоту, так что заметить его непросто — а надо бы. \nИ если вам это всё-таки удалось, настоятельно рекомендуем " +
                "\nпореже делать записи в дневнике, отложить до завтра летопись, \nи главное — спрятать подальше газету, трофейные инкунабулы, " +
                "\nрекламные брошюры и любые другие образцы печатного слова. \nСтоит объекту заметить читающего путника (а зрение у него — " +
                "\nдай Рандом каждому!) — свернувшись в трубочку, он со свистом \nринется в атаку, и придется вам свести тесное и весьма неприятное " +
                "\nзнакомство с жестоким и безжалостным Грифом Секретности. ";
            Level = 5;
            HP = 220;
            Attack = 65;
            Crit = 20;
            Defence = 55;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Эскулап, Изнуряющий.";
        }

        public void UseEnhancing(Monster monster)
        {
            if (monster is IHealthEnhancing monst) monst.UseHealthEnhancing(monster);
        }


        public void UseСursing(Hero hero)
        {
            if (this is IAttackСursing monster) monster.UseAttackСursing(hero);
        }

        public int AlreadyTimeAttackСursing { get; set; }
        public bool IsAttackСursing { get; set; }
    }
}
