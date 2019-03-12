using System;
using NUnit.Framework;

namespace Scorponok.IB.Unit.Integration.Tests
{

    [SetUpFixture, Category("Global")]
    public class Global
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Console.Write("SetUp");
            BaseIntegrationTest.Server = ConfigureStartup.CreateServer();
        }

        [OneTimeTearDown]
        public void End()
        {
            Console.Write("TearDown");
        }
    }
}

