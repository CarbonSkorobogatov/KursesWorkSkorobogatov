/*
 * Класс для наполнения базы данных
 */

using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ProxSenceProject.Models.EntityFramework
{
    public class EFData
    {
        // Промежуточное ПО для обработки HTTP-запроса: наличие содержимого к БД
        public static void EFDbData(IApplicationBuilder applicationBuilder)
        {
            EFDBContext dataBase = applicationBuilder.ApplicationServices.GetRequiredService<EFDBContext>();
            if (!dataBase.ProjectData.Any())
            {
                // Наполняем БД тестовыми запросами
                dataBase.ProjectData.AddRange(
                    new Project
                    {
                        ProjectName = "Проект на ASP.NET",
                        ProjectDescription = "Сочитает в себе все технологии проектирования",
                        ProjectCategory = "ASPNET",
                        ProjectPrice = 275
                    },
                    new Project
                    {
                        ProjectName = "Проект на YII 2",
                        ProjectDescription = "Сочитает в себе все технологии проектирования",
                        ProjectCategory = "YII 2",
                        ProjectPrice = 48.95m
                    },
                    new Project
                    {
                        ProjectName = "PHP проекты",
                        ProjectDescription = "Сочитает в себе все технологии проектирования",
                        ProjectCategory = "PHP",
                        ProjectPrice = 19.50m
                    },
                    new Project
                    {
                        ProjectName = "Проект на YII 2",
                        ProjectDescription = "Сочитает в себе все технологии проектирования",
                        ProjectCategory = "YII 2",
                        ProjectPrice = 34.95m
                    },
                    new Project
                    {
                        ProjectName = "JavaScript Projects",
                        ProjectDescription = "Сочитает в себе все технологии проектирования",
                        ProjectCategory = "JavaScript",
                        ProjectPrice = 79500
                    },
                    new Project
                    {
                        ProjectName = "Проект на YII 2",
                        ProjectDescription = "Сочитает в себе все технологии проектирования",
                        ProjectCategory = "YII 2",
                        ProjectPrice = 16
                    },
                    new Project
                    {
                        ProjectName = "Звук в текст",
                        ProjectDescription = "Сочитает в себе все технологии проектирования",
                        ProjectCategory = "JavaScript",
                        ProjectPrice = 29.95m
                    },
                    new Project
                    {
                        ProjectName = "Проект на YII 2",
                        ProjectDescription = "Сочитает в себе все технологии проектирования",
                        ProjectCategory = "YII 2",
                        ProjectPrice = 75
                    },
                    new Project
                    {
                        ProjectName = "ASP.NET Sites ToString()",
                        ProjectDescription = "Сочитает в себе все технологии проектирования",
                        ProjectCategory = "ASPNET",
                        ProjectPrice = 1200
                    }
                  );
                dataBase.SaveChanges();
            }
        }
    }
}
