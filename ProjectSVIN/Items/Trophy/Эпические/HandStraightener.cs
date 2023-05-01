using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class HandStraightener : Trophy
    {
        public HandStraightener()
        {
            Name = "Выпрямитель рук";
            Description = "Первые модели выпрямителей рук напоминали медицинские лубки — \nкусок доски прикручивался саморезами или приматывался " +
                "\nсиней изолентой или пропитанными гипсом бинтами к руке, \nболее поздние изготавливались из металла и напоминали фантастические " +
                "\nажурные конструкции из тяг, струбцин, пружин и динамометров. \nДля привлечения богатых покупателей некоторые модели " +
                "\nпокрывали патиной или позолотой и украшали неонками.  ";
            Price = 700;
            RareLevel = Rareness.Эпическая;

        }
    }
}
