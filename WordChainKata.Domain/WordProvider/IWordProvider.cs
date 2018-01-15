using System.Collections.Generic;

namespace WordChainKata.Domain.WordProvider
{
   public interface IWordProvider
    {
        List<string> GetWords(string fileLocation, int wordLength);
    }

}
