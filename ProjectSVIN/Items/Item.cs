using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }       
        public abstract string Category { get; set; }
        public Rareness RareLevel { get; set; }
        public enum Rareness
        {
            Обычная = 1,
            Редкая,
            Эпическая,
            Легендарная
        }

        public int Price { get; set; }

        public override string ToString()
        {
            return $"Предмет: {Name}; Цена: {Price};";
        }


        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
