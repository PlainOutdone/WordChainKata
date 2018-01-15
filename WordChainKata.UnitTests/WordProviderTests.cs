using System;
using WordChainKata.Domain.WordProvider;
using Xunit;

namespace WordChainKata.UnitTests
{
    public class WordProviderTests
    {

        [Fact]
        public static void WhenRequestingWordsWithoutALengthReturnAllElements()
        {
            IWordProvider provider = new WordProvider();
            var words = provider.GetWords($"{AppDomain.CurrentDomain.BaseDirectory}testwordlist.txt",0);
            Assert.Equal("i", words[0]);
            Assert.Equal("am", words[1]);
            Assert.Equal("a", words[2]);
            Assert.Equal("test", words[3]);
            Assert.Equal("case", words[4]);
        }

        [Fact]
        public static void WhenRequestingWordsWithALengthReturnAllWordsOfThatLength()
        {
            IWordProvider provider = new WordProvider();
            var words = provider.GetWords($"{AppDomain.CurrentDomain.BaseDirectory}testwordlist.txt", 3);

            Assert.Equal("cat", words[0]);
            Assert.Equal("cot", words[1]);
            Assert.Equal("cog", words[2]);
            Assert.Equal("dog", words[3]);
        }

        [Fact]
        public static void WhenRequestingWordsMakeSureThereAreNoDuplicates()
        {
            IWordProvider provider = new WordProvider();
            var words = provider.GetWords($"{AppDomain.CurrentDomain.BaseDirectory}testwordlist.txt", 3);

            Assert.Equal("dog", words[3]);
            Assert.NotEqual("dog", words[4]);
        }
    }
}
