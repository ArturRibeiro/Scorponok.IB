using System;
using System.Net;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Scorponok.IB.Core.Interfaces;
using Scorponok.IB.Core.ValueObjects;
using Scorponok.IB.Cross.Cutting.Ioc;
using Scorponok.IB.Domain.Models.Churchs;
using Scorponok.IB.Domain.Models.Churchs.IRespository;
using Scorponok.IB.Web.Api.Churchs.Views;

namespace Scorponok.IB.Unit.Integration.Tests
{
    [TestFixture]
    public class ChurchControllerTests
    {
        [TestCase("scorponok", "scorponok@gmail.com", "scorponok.jpg", 21, 55, "27605555", "999999999")]
        public void Register(string name, string email, string photo, byte prefix, byte region, string telephoneFixed, string mobileTelephone)
        {
            //Arrang's
            var requestMessage = new ChurchRegisteringMessageRequest()
            {
                Name = name,
                Email = email,
                Photo = photo,
                Prefix = prefix,
                Region = region,
                TelephoneFixed = telephoneFixed,
                MobileTelephone = mobileTelephone
            };

            //Act
            var response = BaseIntegrationTest.PostAsync(requestMessage, "Church/register");
            response.Wait();

            //Assert's
            response.Result.Should().NotBeNull();
            response.Result.IsSuccessStatusCode.Should().BeTrue();
            response.Result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void Update_church()
        {
            //Arrang's
            var churchId = CreateChurch();

            var requestMessage = new ChurchUpdatedMessageRequest
            {
                Id = churchId,
                Name = "Name updated",
                Photo =  "Photo updated",
                Email = "teste@gmail.com",
                MobileTelephone = "21999999999",
                TelephoneFixed = "2166666666"
            };

            //Act
            var response = BaseIntegrationTest.PutAsync(requestMessage, "Church/update");
            response.Wait();

            //Assert's
            response.Result.Should().NotBeNull();
            response.Result.IsSuccessStatusCode.Should().BeTrue();
            response.Result.StatusCode.Should().Be(HttpStatusCode.OK);

            Action assert = () =>
            {
                //var unitOfWork = Setup.Container.GetService<IUnitOfWork>();
                //var churchUpdate = unitOfWork.Repository<Church>().GetById(churchId);

                //churchUpdate.Id.Should().Be(churchId);
                //churchUpdate.Name.Should().Be(requestMessage.Name);
                //churchUpdate.Photo.Should().Be(requestMessage.Photo);
                //churchUpdate.Email.Value.Should().Be(requestMessage.Email);
                //churchUpdate.MobileTelephone.Number.Should().Be(requestMessage.MobileTelephone);
                //churchUpdate.TelephoneFixed.Number.Should().Be(requestMessage.TelephoneFixed);
            };

            assert();
        }

        [Ignore("")]
        public void Deleted_church()
        {
        }

        private Guid CreateChurch()
        {
            var churchRepository = Setup.Container.GetService<IChurchRepository>();
            var unitOfWork = Setup.Container.GetService<IUnitOfWork>();

            BuilderSetup.SetCreatePersistenceMethod<Church>(churchRepository.Add);
            var church = Builder<Church>
                .CreateNew()
                .With(x => x.TelephoneFixed, Telephone.Factory.CreateNew(21, "55555555"))
                .With(x => x.MobileTelephone, Telephone.Factory.CreateNew(21, "987413333"))
                .Persist();

            unitOfWork.Commit();

            return church.Id;
        }


    }
}