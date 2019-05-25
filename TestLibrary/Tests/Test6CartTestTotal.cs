using System.Linq;
using ProxSence.BuyAProject;
using ProxSence.Models;
using Xunit;
using ProxSence.BuyAProject.Model;

namespace ProxSence.Test.Tests
{
    public class Test6CartTestTotal
    {
        [Fact]
        public void Can_Cart_Total()
        {
            Portfolio p1 = new Portfolio { PortfolioID = 1, ProjectName = "Name1", ProjectPrice = 375M };
            Portfolio p2 = new Portfolio { PortfolioID = 2, ProjectName = "Name2", ProjectPrice = 375M };
            Cart target = new Cart();
            target.AddProject(p1, 1);
            target.AddProject(p2, 1);
            target.AddProject(p1, 3);
            decimal result = target.TotalValue();
            Assert.Equal(1875M, result);
        }
    }
}
