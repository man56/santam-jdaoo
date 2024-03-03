using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STM.Lang
{
    class Persian
    {
        private static readonly Dictionary<string, string> persianDic = new Dictionary<string, string>
                                                                   {
                                                                       {"force", "a"},
                                                                       {"extention", "b"},
                                                                       {"stress", "c"},
                                                                       {"strain", "d"},
                                                                       {"tensile", "a"},
                                                                       {"Compressive", "b"},
                                                                       {"Cyclic", "c"},
                                                                       {"Step", "d"},
                                                                       {"Relaxation", "a"},
                                                                       {"Creep", "b"},
                                                                       {"None", "c"},
                                                                       {"SE", "d"},
                                                                       {"SEF", "a"},
                                                                       {"ForceRate", "b"},
                                                                       {"StressRate", "c"},
                                                                       {"TrueStressRate", "d"},
                                                                       {"StrainRate", "b"},
                                                                       {"TrueStrainRate", "c"},
                                                                       {"SpeedControl", "d"},
                                                                       {"Peek", "d"},
                                                                       {"Stop", "d"},
                                                                       {"Continue", "d"},
                                                                   };

        public static Dictionary<string, string> GetNames(Type enumType)
        {
            string[] nativeNames = Enum.GetNames(enumType);
            
            Dictionary<string, string> retDic= nativeNames.ToDictionary(str => str, str => persianDic[str]);

            return retDic;
        }
    }
}
