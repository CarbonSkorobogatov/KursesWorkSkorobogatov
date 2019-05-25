using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ProxSenceProject.Models.EntityFramework
{
    public static class EFHomeData
    {
        public static void EnsurePopulated(IApplicationBuilder appBuilder)
        {
            // EFHomeDbContext context = appBuilder.ApplicationServices.GetRequiredService<EFHomeDbContext>();
            //    if (!context.NewsData.Any())
            //    {
            //        context.NewsData.AddRange(
            //            new News
            //            {
            //                Title = "Как шла разработка проекта",
            //                NewsDescription = "Шла она ваще какпец, потеря за патерей, блооооо",
            //                dateNewsTime = DateTime.Now
            //            },
            //            new News
            //            {
            //                Title = "Как шла разработка проекта",
            //                NewsDescription = "Шла она ваще какпец, потеря за патерей, блооооо",
            //                dateNewsTime = DateTime.Now
            //            },
            //            new News
            //            {
            //                Title = "Как шла разработка проекта",
            //                NewsDescription = "Шла она ваще какпец, потеря за патерей, блооооо",
            //                dateNewsTime = DateTime.Now
            //            },
            //            new News
            //            {
            //                Title = "Как шла разработка проекта",
            //                NewsDescription = "Шла она ваще какпец, потеря за патерей, блооооо",
            //                dateNewsTime = DateTime.Now
            //            }
            //            );
            //        context.SaveChanges();
            //    }
            //}
        }
    }
}
