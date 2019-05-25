using System.Linq;
using ProxSence.BuyAProject;
using ProxSence.Models;
using Xunit;
using ProxSence.BuyAProject.Model;

namespace ProxSence.Test.Tests
{
    public class Test4CartTestProj
    {
        [Fact]
        public void Can_Add_Quantity_For_Projects()
        {
            Portfolio p1 = new Portfolio { PortfolioID = 1, ProjectName = "Name1" };
            Portfolio p2 = new Portfolio { PortfolioID = 2, ProjectName = "Name2" };
            Cart target = new Cart();
            target.AddProject(p1, 1);
            target.AddProject(p2, 1);
            target.AddProject(p1, 10);
            CartProj[] results = target.proj.OrderBy(a => a.Portfolio.PortfolioID).ToArray();
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }
    }
}
