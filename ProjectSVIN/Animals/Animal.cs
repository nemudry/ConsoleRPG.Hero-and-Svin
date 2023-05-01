using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Animal : ICloneable
    {

        public virtual string Name { get; set; }  

        public virtual string Description { get; set; }

        public virtual int Level { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
