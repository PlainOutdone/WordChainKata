using System;
using System.Collections.Generic;
using System.Text;
using WordChainKata.Domain.ExtensionMethods;

namespace WordChainKata.Domain.AvailableWordFinder
{
    public class AvailableWordFinder : IAvailableWordFinder
    {
   
        public List<string> FindAllAvailableWords(string currentWord, List<string> wordBank)
        {
            List<string> AvailableWords = new List<string>();
            foreach (string word in wordBank)
            {
                if (word.IsWordChain(currentWord)) { AvailableWords.Add(word); }
            }
            return AvailableWords;
        }

    }
}
