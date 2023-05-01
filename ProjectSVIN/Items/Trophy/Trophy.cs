using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Trophy : Item
    {
        public override string Category { get; set; } = "Трофей";

    }
}
