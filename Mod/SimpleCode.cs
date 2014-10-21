using System;
using System.Collections;
using System.Collections.Generic;

namespace Mod
{
    public static  class SimpleCode
    {
        public static List<string> BuildCode(List<string> dictionary)
        {
            var encodedDictionary = new List<string>();
            int codeLength = (int) Math.Ceiling(Math.Log(dictionary.Count, 2));
            for (int j = 0; j < dictionary.Count; j++)
            {
                var code = new BitArray(BitConverter.GetBytes(j));
                String stringCode = StringManipulator.BitToString(code, codeLength);
                if (!encodedDictionary.Contains(stringCode))
                {
                    encodedDictionary.Add(stringCode);
                }
            }
            return encodedDictionary;
        }
    }
}