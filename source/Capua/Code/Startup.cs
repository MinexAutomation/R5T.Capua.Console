﻿using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Argumentos;
using R5T.Argumentos.Standard;
using R5T.Capua.Standard;
using R5T.Dacia;
using R5T.Dacia.Extensions;
using R5T.Palembang;
using R5T.Richmond;
using R5T.Ujung;

using Capua.Services;


namespace Capua
{
    class Startup : StartupBase
    {
        public Startup(ILogger<StartupBase> logger)
            : base(logger)
        {
        }

        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services
                .AddDeployBuiltBinariesAction(
                    new ServiceAction<IBuildConfigurationNameProvider>(() => services.AddSingleton<IBuildConfigurationNameProvider, BuildConfigurationNameProvider>()),
                    new ServiceAction<IProjectNameProvider>(() => services.AddSingleton<IProjectNameProvider, ProjectNameProvider>()),
                    new ServiceAction<ISolutionDirectoryPathProvider>(() => services.AddSingleton<ISolutionDirectoryPathProvider, SolutionDirectoryPathProvider>()),
                    new ServiceAction<ITargetFrameworkNameProvider>(() => services.AddSingleton<ITargetFrameworkNameProvider, TargetFrameworkNameProvider>())
                    )
                .AddServices(serviceCollection =>
                {
                    if(DummyCommandLineArgumentsProvider.UseDummyCommandLineArguments)
                    {
                        serviceCollection.AddSingleton<ICommandLineArgumentsProvider, DummyCommandLineArgumentsProvider>();
                    }
                    else
                    {
                        serviceCollection.AddCommandLineArgumentsProvider<ICommandLineArgumentsProvider>();
                    }
                })
                ;
        }
    }
}
