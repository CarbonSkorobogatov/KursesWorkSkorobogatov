using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProxSenceProject.Models.EntityFramework;

namespace ProxSenceProject.Migrations.EFHomeDb
{
    [DbContext(typeof(EFHomeDbContext))]
    partial class EFHomeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProxSenceProject.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NewsDescription");

                    b.Property<string>("Title");

                    b.Property<DateTime>("dateNewsTime");

                    b.HasKey("NewsId");

                    b.ToTable("NewsData");
                });
        }
    }
}
