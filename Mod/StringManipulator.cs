using System;
using System.Collections;
using System.Collections.Generic;

namespace Mod
{
    public  static class StringManipulator
    {
        public static List<string> SplitText(string sourceText, int step, int blockLength, List<string> dictionary)
        {
            var result = new List<string>();
            var iterator = new StringIterator(sourceText, step, blockLength);
            while (iterator.HasNext())
            {
                string current = iterator.Next();
                result.Add(current);
                if (!dictionary.Contains(current))
                {
                    dictionary.Add(current);
                }
            }
            return result;
        }

        public static string BitToString(BitArray code, int length)
        {
            String result = String.Empty;
            for (int i = 0; i < code.Count; i++)
            {
                result += code[i] ? '1' : '0';
            }
            return result.Substring(0, length);
        }
        public static string BitToString(BitArray code)
        {
            String result = String.Empty;
            for (int i = 0; i < code.Count; i++)
            {
                result += code[i] ? '1' : '0';
            }
            return result;
        }
    }
}