using System;
using Microsoft.Extensions.DependencyInjection;
using WordChainKata.Domain.AvailableWordFinder;
using WordChainKata.Domain.WordController;
using WordChainKata.Domain.WordProvider;

namespace WordChainKata.Domain
{
    public class IoC
    {

        private static IServiceProvider _container;
        public static IServiceProvider Container
        {
            get
            {
                if (_container == null)
                { _container = ServiceCollection.BuildServiceProvider(); }
                return _container;
            }
        }

        /// <summary>
        /// Allows for overriding services within test environment
        /// </summary>
        private static ServiceCollection _serviceCollection;
        public static ServiceCollection ServiceCollection
        {
            get
            {
                if (_serviceCollection == null)
                {
                    _serviceCollection = BuildDefaultServiceCollection();
                }
                return _serviceCollection;
            }
        }

        private static ServiceCollection BuildDefaultServiceCollection()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IWordProvider, WordProvider.WordProvider>();
            services.AddTransient<IWordController, WordController.WordController>();
            services.AddSingleton<IAvailableWordFinder, AvailableWordFinder.AvailableWordFinder>();

            return services;
        }
    }
}
