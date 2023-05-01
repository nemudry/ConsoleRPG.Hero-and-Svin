using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Poison : Buff
    {
        public virtual void UsePoison(Monster monster) { }
        public virtual void CanselPoison(Monster monster) { }


    }



}
