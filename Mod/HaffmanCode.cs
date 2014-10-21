using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod
{
    public static class HaffmanCode
    {

        public static List<string> BuildCode(List<string> splittedText, List<string> dictionary)
        {
            HuffmanTree tree = new HuffmanTree();
            tree.Build(splittedText);
            return tree.Encode(dictionary);
        } 
    }
}
