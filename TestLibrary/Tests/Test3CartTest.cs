using System.Linq;
using ProxSence.BuyAProject;
using ProxSence.Models;
using Xunit;
using ProxSence.BuyAProject.Model;

namespace ProxSence.Test.Tests
{
    public class Test3CartTest
    {
        [Fact]
        public void Can_Add_Cart_Now()
        {
            Portfolio p1 = new Portfolio { PortfolioID = 1, ProjectName = "Name1" };
            Portfolio p2 = new Portfolio { PortfolioID = 2, ProjectName = "Name2" };
            Cart target = new Cart();
            target.AddProject(p1, 1);
            target.AddProject(p2, 1);
            CartProj[] results = target.proj.ToArray();
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Portfolio);
            Assert.Equal(p2, results[1].Portfolio);
        }
    }
}
