/*
 * Создание класса для базы данных
 */

using Microsoft.EntityFrameworkCore;

namespace ProxSenceProject.Models.EntityFramework
{
    // Предоставляет доступ к функциональности EFCore
    public class EFDBContext : DbContext
    {
        // Класс контекста, обеспечивает доступ к данным приложения с применением объектов моделей
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }
        // Объект базы данных
        public DbSet<Project> ProjectData { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
