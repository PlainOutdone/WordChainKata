using System.Collections.Generic;

namespace WordchainKata.Domain.WordProvider
{
   public interface IWordProvider
    {
        List<string> GetWords(string fileLocation, int wordLength);
    }

}
