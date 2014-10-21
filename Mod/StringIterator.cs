using System;

namespace Mod
{
    public class StringIterator
    {
        private readonly String str;

        int position = 0;
        readonly int readSize;
        readonly int step;

        public StringIterator(string str, int step, int readSize) 
        {
            this.str = str;
            this.step = step;
            this.readSize = readSize;
        }

        public string Next()
        {
            string result;
            if (str.Length > position + readSize)
            {
                result = str.Substring(position, readSize);
                
            }
            else
            {
                result = str.Substring(position, str.Length - position);
            }
            position += step;
            
            return result;
        }

        public bool HasNext()
        {
            if (step == 1)
            {
                return str.Length >= position + readSize;
            }
            else
            {
                return str.Length >= position;
            }
            
        }

        public void Reset()
        {
            position = 0;
        }
    }
}
