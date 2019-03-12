using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Scorponok.IB.Web.Api.App.Contributions;

namespace Scorponok.IB.Unit.Integration.Tests
{
    public class InputControllerTests
    {

        [Test]
        public async Task Register_new_value()
        {
            //Arranger's
            var request = new ValueMessageRequest()
            {
                Value = 10,
                MemberId = Guid.NewGuid(),
                Name = "Space ghost",
                TypeContribution = 1,
                ContributionDate = DateTime.Now
            };

            //Act
            try
            {
                var response = await BaseIntegrationTest.PostAsync(request, "Input/addValue");
            }
            catch (Exception ex)
            {
                throw;
            }

            //Assent's
            //response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}