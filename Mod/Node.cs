using System.Collections.Generic;

namespace Mod
{
    class Node
    {
        public string Value { get; set; }
        public int Frequency { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        public List<bool> Traverse(string value, List<bool> data)
        {
            // Leaf
            if (Right == null && Left == null)
            {
                if (value.Equals(Value))
                {
                    return data;
                }
                return null;
            }
            List<bool> left = null;
            List<bool> right = null;

            if (Left != null)
            {
                var leftPath = new List<bool>();
                leftPath.AddRange(data);
                leftPath.Add(false);

                left = Left.Traverse(value, leftPath);
            }

            if (Right != null)
            {
                var rightPath = new List<bool>();
                rightPath.AddRange(data);
                rightPath.Add(true);
                right = Right.Traverse(value, rightPath);
            }

            if (left != null)
            {
                return left;
            }
            return right;
        }
    }
}
