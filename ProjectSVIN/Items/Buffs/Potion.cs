using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Potion : Buff
    {
        public virtual void UsePotion(Hero hero) { }
        public virtual void CanselPotion(Hero hero) { }


    }



}
