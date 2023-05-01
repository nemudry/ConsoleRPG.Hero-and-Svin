﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class GrandpaWithPaddle : Monster, IHealthEnhancing
    {
       public GrandpaWithPaddle()
        {
            Name = "Дедушка С Веслом";
            Description = "Дедушка с Веслом — обманчиво тщедушный монстр (материализованный \nпосредством акропетальной индукции торсионных полей дух), " +
                "\nподжидающий героев в границах бассейнов пресных водоемов. \nБудучи в своей молекулярной основе духом, Дедушка С Веслом способен " +
                "\nпринимать различные формы и обличья, чем крайне затрудняет свою идентификацию. \nТаким образом, на западе часто попадается " +
                "\nболее агрессивный подвид данного монстра. Выглядит он как пожилой мужчина \nс нездоровым цветом дряблой сморщенной кожи. " +
                "\nВстречаются особи как обильно покрытые густой растительностью, \nтак и плешивые и даже вовсе полностью лишённые оной. Из одежды " +
                "\nотдают предпочтение стрингам. Обыкновенно стараются подобраться \nк герою сзади и пытаются его проткнуть веслом, наподобие копья, " +
                "\nцеля в нижнее обмундирование. Кроме того, одним своим внешним видом \nмогут оказать катастрофическое воздействие на неокрепшую психику " +
                "\nначинающих героев.";
            Level = 3;
            HP = 120;
            Attack = 50;
            Crit = 20;
            Defence = 30;
            MainFeatures = (HP, Attack, Defence);
            NameMonsterEffects = "Эскулап.";
        }

        public void UseEnhancing(Monster monster)
        {
            if (monster is IHealthEnhancing monst) monst.UseHealthEnhancing(monster);
        }

    }
}