using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordChainKata.Domain.AvailableWordFinder;
using WordChainKata.Domain.WordProvider;

namespace WordChainKata.Domain.WordController
{
    public class WordController : IWordController
    {
        private IWordProvider _provider;
        private IAvailableWordFinder _finder;
        private List<string> _wordBank;
        private List<string> _completeChains = new List<string>();
        public WordController(IWordProvider provider, IAvailableWordFinder finder)
        {
            _provider = provider;
            _finder = finder;
        }

        bool FoundNewChains = true;
        public List<string> GetAllWordChains(string startWord, string endWord)
        {
            _wordBank = _provider.GetWords("wordlist.txt", startWord.Length);
            List<string> currentChains;
            currentChains = CheckForWordChains(startWord,endWord);

            while (FoundNewChains == true && _completeChains.Count == 0 )
            {
                List<string> newChains = new List<string>();
                foreach (string chain in currentChains)
                {
                    newChains.AddRange(CheckForWordChains(chain,endWord));
                }
                currentChains = newChains;
            }
            return _completeChains;
        }

        public List<string> CheckForWordChains(string chain, string endWord)
        {
            FoundNewChains = false;
            var currentWord = chain.Split(" ").Last();
            List<string> newChains = new List<string>();
            List<string> availableWords = _finder.FindAllAvailableWords(currentWord, _wordBank);

            foreach (string availableWord in availableWords)
            {
                if (!chain.Split(" ").ToList().Contains(availableWord))
                {
                    var newChain = $"{chain} {availableWord}";
                    if (availableWord == endWord)
                    {
                        _completeChains.Add(newChain);
                    }
                    else
                    {
                        newChains.Add(newChain);
                    }
                    FoundNewChains = true;
                }
            }
            return newChains;
        }
    }

    public interface IWordController
    {
        List<string> GetAllWordChains(string word, string endWord);
    }
}
