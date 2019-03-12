using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Scorponok.IB.Cqrs.Data.Context;

namespace Scorponok.IB.Unit.Integration.Tests.Helpers
{
    public class Seed
    {
        public async Task SeedAsync(DataContext context, IHostingEnvironment env)
        {

            //context.Clients.Add(ClientFaker.CreateClient());
            //context.Divisoes.Add(DivisionFaker.CreateDivisions());
            //context.Regions.Add(RegionFaker.CreateRegions());

            //var hospitals = HospitalFaker.CreateHospitals();
            //var unitys = UnityFake.CreateUnity();
            //var groups = CreateGroups(hospitals, unitys).ToList();


            //context.Hospitais.Add(hospitals);
            //context.Indicadores.Add(IndicatorFaker.CreateIndicators());
            //context.Unitys.Add(unitys);
            //context.Groups.Add(groups);

            //var commit = context.SaveChanges() > 0;
            //commit.Should().BeTrue();
        }
    }
}