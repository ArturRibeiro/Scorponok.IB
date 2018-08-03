using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Cqrs.Data.Context;
using Scorponok.IB.Cqrs.Data.EventSourcing;
using Scorponok.IB.Cqrs.Data.Repositories;
using Scorponok.IB.Cqrs.Data.Repositories.EventSourcing;
using Scorponok.IB.Cqrs.Pagamento.Data.UoW;
using Scorponok.IB.Cross.Cutting.Bus;
using Scorponok.IB.Cross.Cutting.Identity.Models;
using Scorponok.IB.Domain.CommandHandlers;
using Scorponok.IB.Domain.EventHandlers;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Domain.Models.Churchs.Events;
using Scorponok.IB.Domain.Models.Churchs.IRespository;
using Scorponok.IB.Domain.Models.Users.Interfaces;

namespace Scorponok.IB.Cross.Cutting.Ioc
{
    public static class Setup
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper();

            RegisterAutoMapper(services);

            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<ChurchRegisteredEvent>, ChurchEventHandlers>();

            //Commands
            services.AddScoped<IHandler<RegisterChurchCommand>, ChurchCommandHandlers>();
            
            
            //Repositorys
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChurchRepository, ChurchRepository>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<EventStoreContext>();

            //InMemoryBus
            services.AddScoped<IBus, InMemoryBus>();
            InMemoryBus.ContainerAccessor = services.BuildServiceProvider;

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();

        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            var config = Mapper.Configuration;
            services.AddSingleton(config);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }

        private static void RegistraRepositorys()
        {

        }
    }
}
