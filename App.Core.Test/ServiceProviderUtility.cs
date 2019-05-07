using System;
using System.Threading.Tasks;
using App.Core.Handlers;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.SharedKernel;
using App.Infrastructure;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Core.Test {
    
    public class ServiceProviderUtility
    {
        public static ServiceProvider GetServiceProvider()
        {

            var services = new ServiceCollection();
            
            // if you have handlers/events in other assemblies
            services.AddMediatR(typeof(AddQuestionHandler).Assembly);
            services.AddDbContextPool<App.Infrastructure.GZContext>(
                options =>
                     options.UseSqlite("Data Source=groceryzen.db", b => b.MigrationsAssembly("App"))
            );
            services.AddScoped<ServiceFactory>(p => p.GetService);
            //Pipeline
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            // Use Scrutor to scan and register all
            // classes as their implemented interfaces.
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IMediator), typeof(BaseEntity))
                .AddClasses()
                .AsImplementedInterfaces());
            var provider = services.BuildServiceProvider();
            return provider;
        }
    }
    
}