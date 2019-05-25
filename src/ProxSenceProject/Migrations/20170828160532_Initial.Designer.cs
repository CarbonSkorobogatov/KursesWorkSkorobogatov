using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProxSenceProject.Models.EntityFramework;

namespace ProxSenceProject.Migrations
{
    [DbContext(typeof(EFDBContext))]
    [Migration("20170828160532_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProxSenceProject.Models.CartLine", b =>
                {
                    b.Property<int>("CartLineID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderId");

                    b.Property<int?>("ProjectId");

                    b.Property<int>("Quantity");

                    b.HasKey("CartLineID");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProjectId");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("ProxSenceProject.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("Passed");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("SecondName")
                        .IsRequired();

                    b.Property<string>("Town")
                        .IsRequired();

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProxSenceProject.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageName");

                    b.Property<string>("ImagePath");

                    b.Property<string>("ProjectCategory")
                        .IsRequired();

                    b.Property<string>("ProjectDescription")
                        .IsRequired();

                    b.Property<string>("ProjectName")
                        .IsRequired();

                    b.Property<decimal>("ProjectPrice");

                    b.HasKey("ProjectId");

                    b.ToTable("ProjectData");
                });

            modelBuilder.Entity("ProxSenceProject.Models.CartLine", b =>
                {
                    b.HasOne("ProxSenceProject.Models.Order")
                        .WithMany("Lines")
                        .HasForeignKey("OrderId");

                    b.HasOne("ProxSenceProject.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });
        }
    }
}
