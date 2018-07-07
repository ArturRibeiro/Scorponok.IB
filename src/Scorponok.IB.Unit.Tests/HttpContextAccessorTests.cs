
using System.Security.Claims;
using System.Security.Principal;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using Scorponok.IB.Cross.Cutting.Identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace Scorponok.IB.Unit.Tests
{
    [TestFixture]
    public class HttpContextAccessorTests
    {
        [Test]
        public void MyTestMethod()
        {
            // Arrange
            const string userEmail = "some-email@example.com";

            var context = new DefaultHttpContext();
            context.User = new GenericPrincipal(
                new GenericIdentity(userEmail), null);


           var mockIHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockIHttpContextAccessor.Setup(x => x.HttpContext).Returns(context);


            var user = new AspNetUser(mockIHttpContextAccessor.Object);

            user.Should().NotBeNull();
            user.IsAuthenticated().Should().BeTrue();
        }
    }
}