using System;
using System.Collections.Generic;
using System.Text;
using WordchainKata.Domain.WordProvider;
using Xunit;

namespace WordChainKata.UnitTests
{
    public class WordProviderTests
    {

        [Fact]
        public static void WhenProvidedAWordListWithoutALengthReturnAllElements()
        {
            IWordProvider provider = new WordProvider();
            var words = provider.GetWords($"{AppDomain.CurrentDomain.BaseDirectory}testwordlist.txt",0);
            Assert.Equal("I", words[0]);
            Assert.Equal("Am", words[1]);
            Assert.Equal("A", words[2]);
            Assert.Equal("Test", words[3]);
            Assert.Equal("Case", words[4]);
        }

        [Fact]
        public static void WhenProvidedAWordListWithALengthReturnAllWordsOfThatLength()
        {
            IWordProvider provider = new WordProvider();
            var words = provider.GetWords($"{AppDomain.CurrentDomain.BaseDirectory}testwordlist.txt", 3);

            Assert.Equal("Cat", words[0]);
            Assert.Equal("Cot", words[1]);
            Assert.Equal("Cog", words[2]);
            Assert.Equal("Dog", words[3]);
        }
    }
}
