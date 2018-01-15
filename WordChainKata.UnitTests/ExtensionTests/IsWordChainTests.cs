using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WordChainKata.Domain.ExtensionMethods;
namespace WordChainKata.UnitTests.ExtensionTests
{
    public class IsWordChainTests
    {

        [Fact]
        public static void WhenProvidedNoWordReturnFalse()
        {
            string input = "testy";
            Assert.False(input.IsWordChain(""));
        }

        [Fact]
        public static void WhenProvidedAWordThatIsntAChainReturnFalse()
        {
            string input = "testy";
            Assert.False(input.IsWordChain("teaaa"));
        }

        [Fact]
        public static void WhenProvidedAWordThatIsIdenticalReturnFalse()
        {
            string input = "testy";
            Assert.False(input.IsWordChain("testy"));
        }

        [Fact]
        public static void WhenProvidedAWordthatIsAChainReturnTrue()
        {
            Assert.True("testy".IsWordChain("testo"));
            Assert.True("testo".IsWordChain("tasto"));
            Assert.True("tasto".IsWordChain("wasto"));
            Assert.True("wasto".IsWordChain("wisto"));
        }
    }
}
