using System;
using System.Collections.Generic;
using System.Text;

namespace WordChainKata.Domain.ExtensionMethods
{
    public static class WordChainKataExtensions
    {
        public static bool IsWordChain(this string str, string comparison)
        {
            if (str.Length != comparison.Length) { return false; }
            char[] comparisonCharArray = comparison.ToCharArray();
            int i = 0, numberOfAlterations = 0;
            foreach (char cha in str.ToCharArray())
            {
                if (cha != comparisonCharArray[i])
                {
                    numberOfAlterations++;
                }
                i++;
            }
            return numberOfAlterations == 1;
        }
    }
}
