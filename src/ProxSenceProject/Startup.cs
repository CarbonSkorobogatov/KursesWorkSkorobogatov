using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ProxSenceProject.Models.EntityFramework;
using ProxSenceProject.Models.Interfaces;
using ProxSenceProject.Models;
using ProxSenceProject.Models.CartData;

namespace ProxSenceProject
{
    public class Startup
    {
        // Чтение и подключение конфигурационного файла, а так же настройка EntityFrameworkCore
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment enviroment)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(enviroment.ContentRootPath)
                                                      .AddJsonFile("appsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Последовательность обращений к методам, которые настраивают инфраструктуру EntityFrameworkCore
            // Для Проектов
            services.AddDbContext<EFDBContext>(options => options.UseSqlServer(
                Configuration["Data:ProxSenceProject:ConnectionString"]
                ));
            // Для RollBase
            services.AddDbContext<IdentityEFDbContext>(options => options.UseSqlServer(
                Configuration["Data:ProxSenceIdentity:ConnectionString"]
                ));
            // Для всего остального
            //services.AddDbContext<EFHomeDbContext>(options => options.UseSqlServer(
            //    Configuration["Data:ProxSence:ConnectionString"]
            //    ));
            
            // Регистрация хранилищ для слабо связанных компонентов 
            services.AddTransient<IProjectData, EFProjectData>();
            services.AddTransient<INewsData, EFHome>();
            services.AddTransient<IOrderProcesser, EFOrderData>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityEFDbContext>();

            services.AddScoped<Cart>(a => SessionCart.GetCart(a));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Расширяющий метод, который отображает ошибки и исключения
            app.UseDeveloperExceptionPage();
            // Код 404
            app.UseStatusCodePages();
            // Поддержка папки wwwroot
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();
            // Роуты
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: null,
                   template: "{category}/Page{page:int}",
                   defaults: new { controller = "Project", action = "ProjectList" }
               );

                routes.MapRoute(
                    name: null,
                    template: "Page{page:int}",
                    defaults: new { controller = "Project", action = "ProjectList", page = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Project", action = "ProjectList", page = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Project", action = "ProjectList", page = 1 });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });

            // Метод, который гарантирует наличие в БД тестовой информации(установленно и сконфигурированно)
            EFData.EFDbData(app);
            IdentityData.EnsurePopulated(app);
            EFHomeData.EnsurePopulated(app);
        }
    }
}
