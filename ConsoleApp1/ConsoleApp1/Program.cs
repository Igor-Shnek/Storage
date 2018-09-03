using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string allText = File.ReadAllText(@"H:\input.txt", Encoding.Default);
            char[] separators = {' ', '.', ',', ';', ':', '"', '!', '?', '{', '}', '(', ')'};
            string[] words = allText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> wordsList = words.ToList();
            wordsList.Sort();
            List<string> wordsListCopy = new List<string>();
            List<int> wordsCounter = new List<int>();
            foreach (string word in wordsList.Select(x => x.ToLower()))
            {
                if (!wordsListCopy.Contains(word))
                {
                    wordsListCopy.Add(word);
                    wordsCounter.Add(1);
                }
                else wordsCounter[wordsListCopy.IndexOf(word)]++;
            }
            wordsList.Clear();
            foreach (string word in wordsListCopy)
            {
                if (!wordsList.Contains(word[0].ToString()))
                {
                    wordsList.Add(word[0].ToString());
                }
                wordsList.Add(word + " - " + wordsCounter.ElementAt(wordsListCopy.IndexOf(word)));
            }
            File.AppendAllLines(@"H:\output.txt", wordsList);
            Console.Read(); 
        }
    }
}
