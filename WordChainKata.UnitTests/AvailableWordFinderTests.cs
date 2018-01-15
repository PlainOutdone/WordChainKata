using System;
using WordChainKata.Domain.WordProvider;
using WordChainKata.Domain.AvailableWordFinder;
using Xunit;

namespace WordChainKata.UnitTests
{
   public class AvailableWordFinderTests
    {


        [Fact]
        public static void WhenProvidedAnInputWithNoMatchesReturnAnEmptyString()
        {
            var input = "Something";
            IAvailableWordFinder wordFinder = new AvailableWordFinder();
            IWordProvider provider = new WordProvider();
            var words = provider.GetWords("testwordlist.txt", input.Length);
            string[] expected = { };
            var actual = wordFinder.FindAllAvailableWords(input, words);

            Assert.Equal(expected, actual);
        }
   
    [Fact]
        public static void WhenProvidedAListOfWordsReturnAllWordChains()
        {
            var input = "mat";
            IAvailableWordFinder wordFinder = new AvailableWordFinder();
            IWordProvider provider = new WordProvider();
            var words = provider.GetWords("testwordlist.txt", input.Length);
            string[] expected = { "cat", "hat" };
            var actual = wordFinder.FindAllAvailableWords(input, words);

            Assert.Equal(expected, actual);
        }
    }
}
