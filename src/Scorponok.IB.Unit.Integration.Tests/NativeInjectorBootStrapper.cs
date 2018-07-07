using System.Data.Entity;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Cqrs.Data.Context;
using Scorponok.IB.Cqrs.Data.EventSourcing;
using Scorponok.IB.Cqrs.Data.Repositories;
using Scorponok.IB.Cqrs.Data.Repositories.EventSourcing;
using Scorponok.IB.Cqrs.Pagamento.Data.UoW;
using Scorponok.IB.Domain.CommandHandlers;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Cross.Cutting.Bus;
using Scorponok.IB.Domain.EventHandlers;
using Scorponok.IB.Domain.Models.Churchs.Events;
using Scorponok.IB.Domain.Models.Churchs.IRespository;
using Scorponok.IB.Domain.Models.Users.Interfaces;
using Scorponok.IB.Cross.Cutting.Identity.Models;

namespace Scorponok.IB.Unit.Integration.Tests
{
    public static class NativeInjectorBootStrapper
    {
        private static ServiceCollection _services;
        private static ServiceProvider _serviceProvider;

        public static ServiceProvider Provider => _serviceProvider;

        public static void Setup()
        {
            _services = new ServiceCollection();
            InMemoryBus.ContainerAccessor = () => _serviceProvider;

            RegistraTodos();

            _serviceProvider = _services.BuildServiceProvider();
        }

        private static void RegistraTodos()
        {
            _services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=DESKTOP-T5U2T7J;Initial Catalog=Scorponok.IB.Db;Integrated Security=True"));

            RegistraRepositorys();
            RegistraCommandHandlers();
            RegistraDomainEvents();
            RegistraServices();
            RegistraBus();


            const string userEmail = "some-email@example.com";
            var context = new DefaultHttpContext { User = new GenericPrincipal(new GenericIdentity(userEmail), null) };
            var mockIHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockIHttpContextAccessor.Setup(x => x.HttpContext).Returns(context);
            var user = new AspNetUser(mockIHttpContextAccessor.Object);

            // ASP.NET HttpContext dependency
            _services.AddSingleton<Mock<IHttpContextAccessor>>(_ => new Mock<IHttpContextAccessor>());

            //// Infra - Identity
            _services.AddScoped<IUser>(_ => new AspNetUser(mockIHttpContextAccessor.Object));
        }

        private static void RegistraCommandHandlers()
        {
            _services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            _services.AddScoped<IHandler<RegisterChurchCommand>, ChurchCommandHandlers>();
        }

        private static void RegistraDomainEvents()
        {
            _services.AddScoped<IHandler<ChurchRegisteredEvent>, ChurchEventHandlers>();
        }

        private static void RegistraServices()
        {

        }

        private static void RegistraBus()
        {
            _services.AddScoped<IBus, InMemoryBus>();
        }

        private static void RegistraRepositorys()
        {
            _services.AddScoped<IUnitOfWork, UnitOfWork>();
            _services.AddScoped<IChurchRepository, ChurchRepository>();

            // Infra - Data EventSourcing
            _services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            _services.AddScoped<IEventStore, EventStore>();
            _services.AddScoped<EventStoreContext>();
        }
    }
}