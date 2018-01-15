using System.Collections.Generic;
using System.Linq;

namespace WordchainKata.Domain.WordProvider
{
    public class WordProvider : IWordProvider
    {
        public List<string> GetWords(string fileLocation, int wordLength)
        {
            List<string> allWords = System.IO.File.ReadAllLines(fileLocation).ToList();
             return allWords.Where(w => w.Length == wordLength || wordLength == 0).ToList(); 
        }
    }

}
