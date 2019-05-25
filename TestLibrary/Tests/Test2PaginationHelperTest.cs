/*
 * Тест на создание ссылок на страницы.
 * Для начала создадим дескрипторный вспомогательный класс PaginationHelper
 * и вызавем метод Process() с тестовыми данными и предоставляется объект TagHelperOutput
 * который инспектируется на предмет сгенерированной HTML-разметки.
 */


using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using ProxSence.ProxSenceOthKernel;
using ProxSence.Models;
using Xunit;

namespace ProxSence.Test.Tests
{
    public class Test2PaginationHelperTest
    {
        [Fact]
        public void PageLinksCanGenerate()
        {
            // Организация
            var urlHelper = new Mock<IUrlHelper>();
            urlHelper.SetupSequence(proj => proj.Action(It.IsAny<UrlActionContext>()))
                .Returns("Test/Page1")
                .Returns("Test/Page2")
                .Returns("Test/Page3");
            var urlHelperF = new Mock<IUrlHelperFactory>();
            urlHelperF.Setup(proj2 => proj2.GetUrlHelper(It.IsAny<ActionContext>()))
                .Returns(urlHelper.Object);
            PaginationHelper paginationHelper = new PaginationHelper(urlHelperF.Object)
            {
                PageModel = new Pagination
                {
                    CurrentPage = 2,
                    TotalItems = 28,
                    ItemsPerPage = 10
                },
                PageAction = "TestProject"
            };
            TagHelperContext THcontext = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "");

            var context = new Mock<TagHelperContent>();
            TagHelperOutput THoutput = new TagHelperOutput("div", new TagHelperAttributeList(),(cache,encoder) => Task.FromResult(context.Object));

            // Действие
            paginationHelper.Process(THcontext, THoutput);
            // Утверждение
            Assert.Equal(@"<a href=""Test/Page1"">1</a>" + @"<a href=""Test/Page2"">2</a>" + @"<a href=""Test/Page3"">3</a>", THoutput.Content.GetContent());
        }
    }
}
