using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace SVINspace
{
    public class MedalForAdviceDrowning : Trophy
    {
        public MedalForAdviceDrowning()
        {
            Name = "Медаль «За советы утопающим»";
            Description = "У героев по карманам валяется много всякого барахла, \nещё больше его валяется по лавкам торговцев. " +
                "\nТам есть и склянки, и нахлобучки, и фиговинки, и много \nдругой всячины. Среди всего перечисленного попадаются " +
                "\nмедали «За советы утопающим». ";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
