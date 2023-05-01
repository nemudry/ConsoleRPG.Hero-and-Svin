using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class The_paradise_apple_s_core : Trophy
    {
        public The_paradise_apple_s_core()
        {
            Name = "Огрызок райского яблока";
            Description = "Этот артефакт тайным образом был вынесен \nиз райского сада одного неизвестного бога \n" +
                "под фиговым листом прокравшегося туда вора, и впоследствии \nстал значимым элементом новейшей истории мира. \n" +
                "Несмотря на древность огрызка, по всему Годвиллю бродят \nтолпы охотников за этой реликвией. Жадные до наживы герои \n" +
                "готовы убить тысячи монстров лишь бы заполучить эту ценность. \nНаш проверенный источник — пьяный бомж, подтвердил, \n" +
                "что Культ Огрызка райского яблока действительно существует. ";
            Price = 2000;
            RareLevel = Rareness.Легендарная;

        }
    }
}
