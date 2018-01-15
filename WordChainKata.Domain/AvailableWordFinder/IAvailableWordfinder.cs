using System.Collections.Generic;

namespace WordChainKata.Domain.AvailableWordFinder
{
    public interface IAvailableWordFinder
    {
        List<string> FindAllAvailableWords(string currentWord, List<string> availableWords);
    }
}
