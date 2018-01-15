using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WordChainKata.Domain;
using WordChainKata.Domain.WordController;
using Xunit;

namespace WordChainKata.IntegrationTests
{
    public class WordControllerTests
    {
        [Fact]
        public static void CatToDogIn4Steps()
        {
            IWordController controller = IoC.Container.GetService<IWordController>();
            List<string> expected = new List<string>() { "cat dat dot dog", "cat dat dag dog", "cat cot dot dog", "cat cot cog dog" };
            var actual = controller.GetAllWordChains("cat", "dog");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void LeadToGoldIn4Steps()
        {
            IWordController controller = IoC.Container.GetService<IWordController>();
            List<string> expected = new List<string>() { "lead load goad gold" };
            var actual = controller.GetAllWordChains("lead", "gold");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void RubyIntoCodeIn6Steps()
        {
            IWordController controller = IoC.Container.GetService<IWordController>();
            List<string> expected = new List<string>() { "ruby roby robe rode code", "ruby rudy rude rode code", "ruby rube robe rode code", "ruby rube rude rode code" };

            var actual = controller.GetAllWordChains("ruby", "code");
            Assert.Equal(expected, actual);
        }
    }
}
