using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordguesser
{
    public class DictionaryLoad
    {
        // Load word list into memory from txt file
        public static List<string> LoadDictionary(string filePath)
        {
            var wordList = new List<string>();
            string line;
            var file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                wordList.Add(line);
            }
            file.Close();
            
            return wordList;
        }
    }
}
