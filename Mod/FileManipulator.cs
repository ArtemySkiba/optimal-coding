using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mod
{
    public static class FileManipulator
    {
        public static void WriteFile(string decodedText, string fileName)
        {
            var sw1 = new StreamWriter("./" + fileName);
            sw1.Write("{0}", decodedText);
            sw1.Close();
        }

        public static string ReadFile(OpenFileDialog openFileDialog1)
        {
            StreamReader reader;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                reader = new StreamReader(openFileDialog1.FileName);
            }
            else
            {
                throw new Exception("Файл не выбран.");
            }
            string sourceText = string.Empty;
            String buffer = string.Empty;
            while ((buffer = reader.ReadLine()) != null)
            {
                sourceText += buffer;
            }
            return sourceText;
        }
    }
}
