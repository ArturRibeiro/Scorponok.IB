using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.IB.Core.Bus;
using Scorponok.IB.Core.Events;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.Notifications;
using Scorponok.IB.Cqrs.Pagamento.Data.Context;
using Scorponok.IB.Cqrs.Pagamento.Data.Repositorys;
using Scorponok.IB.Cqrs.Pagamento.Data.UoW;
using Scorponok.IB.Domain.CommandHandlers;
using Scorponok.IB.Domain.Models.Churchs.Commands;
using Scorponok.IB.Cross.Cutting.Bus;
using Scorponok.IB.Domain.EventHandlers;
using Scorponok.IB.Domain.Models.Churchs.Events;
using Scorponok.IB.Domain.Models.Churchs.IRespository;


namespace Scorponok.IB.Unit.Integration.Tests
{
	public static class Ioc 
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
			// churchRepository;
			//IUnitOfWork uow;
			_services.AddScoped<IUnitOfWork, UnitOfWork>();
			_services.AddScoped<IChurchRepository, ChurchRepository>();
		}
	}
}