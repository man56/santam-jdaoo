using System;
using System.Collections.Generic;
using System.Linq;

namespace STM.Lang
{
    class English
    {
        public static Dictionary<string, string> GetNames(Type enumType)
        {
            string[] nativeNames = Enum.GetNames(enumType);

            var retDic = nativeNames.ToDictionary(str => str, str => str.Replace("_"," "));

            return retDic;
        }
    }
}
