using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    public class Text
    {
        string path;
        string outputPath;
        
        public Text (string path, string outputPath)
        {
            this.path = path;
            this.outputPath = outputPath;
        }

        public List<string> readTheFile ()
        {
            char[] separators = { ' ', '.', ',', ';', ':', '"', '!', '?', '{', '}', '(', ')' };
            List<string> words = File.ReadAllText(path, Encoding.Default).ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            return words;
        }

        public List<string> transformText (List<string> words)
        {
            words.Sort();
            List<string> wordsCopy = new List<string>();
            List<int> wordsCounter = new List<int>();
            foreach (string word in words.Select(x => x.ToLower()))
            {
                if (!wordsCopy.Contains(word))
                {
                    wordsCopy.Add(word);
                    wordsCounter.Add(1);
                }
                else wordsCounter[wordsCopy.IndexOf(word)]++;
                
            }
            words.Clear();
            foreach (string word in wordsCopy)
            {
                if (!words.Contains(word[0].ToString()))
                {
                    words.Add(word[0].ToString());
                }
                words.Add(word + " - " + wordsCounter.ElementAt(wordsCopy.IndexOf(word)));
            }
            return words;
        }

        public void writeTheFile (List<string> words)
        {
            File.AppendAllLines(outputPath, words);
        }
    }
}
