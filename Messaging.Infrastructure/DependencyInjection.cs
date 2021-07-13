using Messaging.Domain.AggregatesModel.MessageAggregate;
using Messaging.Domain.SharedKernel;
using Messaging.Infrastructure.Models;
using Messaging.Infrastructure.Models.DbConfig;
using Messaging.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            return services;
        }
    }
}
