/*
 * Тест на пагинацию страниц.
 * Задаем количество страниц и проектов на странице
 * true - если количество проектов вмещается на указаные страницы
 * false - в противном случае
 */

using System.Collections.Generic;
using System.Linq;
using Moq;
using ProxSence.Controllers;
using ProxSence.Models;
using ProxSence.Interfaces;
using Xunit;

namespace ProxSence.Test.Tests
{
    public class Test1PagePortfolioControllerTest
    {
        [Fact]
        public void Pagination()
        {
            // Организация
            Mock<IPortfolioProjects> mock = new Mock<IPortfolioProjects>();
            mock.Setup(proj => proj.PortfolioProj).Returns(new Portfolio[] {
                new Portfolio {PortfolioID = 1, ProjectName = "name1" },
                new Portfolio {PortfolioID = 2, ProjectName = "name2" },
                new Portfolio {PortfolioID = 3, ProjectName = "name3" },
                new Portfolio {PortfolioID = 4, ProjectName = "name4" },
                new Portfolio {PortfolioID = 5, ProjectName = "name5" },
                new Portfolio {PortfolioID = 6, ProjectName = "name6" },
                new Portfolio {PortfolioID = 7, ProjectName = "name7" },
                new Portfolio {PortfolioID = 8, ProjectName = "name8" },
                new Portfolio {PortfolioID = 9, ProjectName = "name9" }
            });
            PortfolioController portfolioController = new PortfolioController(mock.Object);
            portfolioController.PageSize = 3;

            // Действие
            IEnumerable<Portfolio> getResult = portfolioController.Projects("2").ViewData.Model as IEnumerable<Portfolio>;

            // Утвеждение
            Portfolio[] portfolioArray = getResult.ToArray();
            Assert.True(portfolioArray.Length == 3);
            Assert.Equal("name4", portfolioArray[0].ProjectName);
            Assert.Equal("name5", portfolioArray[1].ProjectName);
        }
    }
}
