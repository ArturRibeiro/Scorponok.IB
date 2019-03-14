using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Cqrs.Data.EventSourcing;
using Scorponok.IB.Cqrs.Data.Repositories;
using Scorponok.IB.Cqrs.Data.Repositories.EventSourcing;
using Scorponok.IB.Cqrs.Data.UoW;
using Scorponok.IB.Cross.Cutting.Bus;
using Scorponok.IB.Cross.Cutting.Identity.Models;
using Scorponok.IB.Domain.CommandHandlers;
using Scorponok.IB.Domain.EventHandlers;
using Scorponok.IB.Domain.Interfaces;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Domain.Models.Churchs.Events;
using Scorponok.IB.Domain.Models.Churchs.IRepository;
using Scorponok.IB.Domain.Models.Contributions.Commands;
using Scorponok.IB.Domain.Models.Contributions.Events;
using Scorponok.IB.Domain.Models.Contributions.IRepository;
using Scorponok.IB.Domain.Models.Members.IRepository;
using Scorponok.IB.Domain.Models.Users.Interfaces;

namespace Scorponok.IB.Cross.Cutting.Ioc
{
    public static class NativeInjectionDependency
    {
        internal static IServiceProvider _container;

        public static T GetInstance<T>()
        {
            var instance = (T)_container.GetService(typeof(T));
            return instance;
        }

        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            RegisterAutoMapper(services);
            RegistraRepositorys(services);

            #region Register domain events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<ChurchRegisteredEvent>, ChurchEventHandlers>();
            services.AddScoped<INotificationHandler<ChurchUpdatedEvent>, ChurchEventHandlers>();
            services.AddScoped<INotificationHandler<ChurchDeletedEvent>, ChurchEventHandlers>();
            
            services.AddScoped<INotificationHandler<ContributionRegisterNameMemberEvent>, ContributionEventHandlers>(); 
            #endregion
            
            #region Register domain Command's
            services.AddScoped<IRequestHandler<RegisterChurchCommand, Unit>, ChurchCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateChurchCommand, Unit>, ChurchCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteChurchCommand, Unit>, ChurchCommandHandler>(); 


            services.AddScoped<IRequestHandler<RegisterContributionCommand, Unit>, ContributionCommandHandler>(); 
            #endregion
            
            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, EventStore>();
            //services.AddScoped<EventStoreContext>();

            //InMemoryBus
            services.AddScoped<IBus, InMemoryBus>();
            InMemoryBus.ContainerAccessor = services.BuildServiceProvider;

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();

            _container = services.BuildServiceProvider();

        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            //var config = Mapper.Configuration;
            //services.AddSingleton(config);
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }

        private static void RegistraRepositorys(IServiceCollection services)
        {
            //Repositorys
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChurchRepository, ChurchRepository>();
            services.AddScoped<IContributionRepository, ContributionRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
        }
    }
}
