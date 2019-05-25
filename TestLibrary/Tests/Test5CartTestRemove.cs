using System.Linq;
using ProxSence.BuyAProject;
using ProxSence.Models;
using Xunit;
using ProxSence.BuyAProject.Model;

namespace ProxSence.Test.Tests
{
    public class Test5CartTestRemove
    {
        [Fact]
        public void Can_Cart_Remove()
        {
            Portfolio p1 = new Portfolio { PortfolioID = 1, ProjectName = "Name1" };
            Portfolio p2 = new Portfolio { PortfolioID = 2, ProjectName = "Name2" };
            Portfolio p3 = new Portfolio { PortfolioID = 3, ProjectName = "Name3" };
            Cart target = new Cart();
            target.AddProject(p1, 1);
            target.AddProject(p2, 3);
            target.AddProject(p3, 5);
            target.AddProject(p2, 1);
            target.RemoveProject(p2);
            Assert.Equal(0, target.proj.Where(a => a.Portfolio == p2).Count());
            Assert.Equal(2, target.proj.Count());
        }
    }
}
