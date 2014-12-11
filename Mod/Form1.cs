using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mod
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dictionary = new List<string>();
            List<string> encodedDictionary;
             
            var encodedText = new List<string>();
            var encodedBuilder = new StringBuilder();
            string decodedText = string.Empty;
            var sourceText = FileManipulator.ReadFile(openFileDialog1);
            int blockLength = (int) numericUpDown1.Value;
            int step = radioButton1.Checked ? blockLength : 1;

            var splittedText = StringManipulator.SplitText(sourceText, step, blockLength, dictionary);

            if (radioButton3.Checked)
            {
                encodedDictionary = SimpleCode.BuildCode(dictionary);
            }
            else
            {
                encodedDictionary = HaffmanCode.BuildCode(splittedText, dictionary);
            }
            for (int m = 0; m < splittedText.Count; m++)
            {
                int index = dictionary.IndexOf(splittedText[m]);
                string stringCode = encodedDictionary[index];
                encodedText.Add(stringCode);
                encodedBuilder.Append(stringCode);
            }
            
            FileManipulator.WriteFile(encodedBuilder.ToString(), "encoded.txt");
            
            int encodedLength = encodedBuilder.ToString().Length;

            int sourceLength = sourceText.ToString().Length;

            float compression = (float)sourceLength / encodedLength;
            MessageBox.Show("Длина исходного текста=" + sourceLength.ToString() + "\nДлина закодированного текста=" + encodedLength.ToString() + "\nКоэфициент сжатия=" + compression.ToString());

            if (radioButton1.Checked)
            {
                for (int k = 0; k < encodedText.Count; k++)
                {
                    int index = encodedDictionary.IndexOf(encodedText[k]);
                    decodedText += dictionary[index];// если меньше 5 глючит
                }
                FileManipulator.WriteFile(decodedText, "decodedBlock.txt");
            }

            if (radioButton2.Checked)
            {
                decodedText += dictionary[encodedDictionary.IndexOf(encodedText[0])];
                for (int i = 1; i < encodedText.Count; i++)
                {
                    int index = encodedDictionary.IndexOf(encodedText[i]);
                    string t = dictionary[index];
                    t = t.Substring(blockLength - 1, 1);
                    decodedText += t;
                }

                FileManipulator.WriteFile(decodedText, "decodedLGramm.txt");
            }
        }
    }
}
