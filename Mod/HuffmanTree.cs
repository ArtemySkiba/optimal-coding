using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mod
{
    class HuffmanTree
    {
        public List<Node> nodes = new List<Node>();
        public Node Root { get; set; }
        public Dictionary<string, int> Frequencies = new Dictionary<string, int>();
        public Dictionary<string, double> d = new Dictionary<string, double>();

        public void Build(List<string> source)
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                {
                    Frequencies.Add(source[i], 0);
                }

                Frequencies[source[i]]++;
            }

            for (int i = 0; i < source.Count; i++)
            {
                double a = Frequencies[source[i]] / (double)(source.Count);
                if (!d.ContainsKey(source[i]))
                {
                    d.Add(source[i], a);
                }
            }
            
            foreach (KeyValuePair<string, int> value in Frequencies)
            {
                nodes.Add(new Node() { Value = value.Key, Frequency = value.Value });
            }

            while (nodes.Count > 1)
            {
                List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();
                
                if (orderedNodes.Count >= 2)
                {
                    // Take first two items
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                    // Create a parent node by combining the frequencies
                    Node parent = new Node()
                    {
                        Value = "*",
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        Left = taken[0],
                        Right = taken[1]
                    };

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }

                Root = nodes.FirstOrDefault();
                
            }

        }

        double b = 0;
        double c = 0;
        public List<string> Encode(List<string> dictionary)
        {
            var result = new List<string>();
            for (int i = 0; i < dictionary.Count; i++)
            {
                List<bool> encodedSymbol = Root.Traverse(dictionary[i], new List<bool>());
                result.Add(StringManipulator.BitToString(new BitArray(encodedSymbol.ToArray())));


                b += result[i].ToString().Length * d[dictionary[i]];
                c += d[dictionary[i]];
            }
            MessageBox.Show("Средняя длинна кодового слова: " + b.ToString());
           

            return result;
        }

        public string Decode(BitArray bits)
        {
            Node current = this.Root;
            string decoded = "";

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }

                if (IsLeaf(current))
                {
                    decoded += current.Value;
                    current = this.Root;
                }
            }

            return decoded;
        }

        public bool IsLeaf(Node node)
        {
            return (node.Left == null && node.Right == null);
        }
    }
}
