﻿// <auto-generated />
using FoodPrepData.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodPrepAPICore.Migrations
{
    [DbContext(typeof(FoodPrepContext))]
    [Migration("20190922234908_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodPrepData.DataModels.EstimatedCost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ID");

                    b.ToTable("EstimatedCost");
                });

            modelBuilder.Entity("FoodPrepData.DataModels.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstimatedCostID");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("RecipeSteps")
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("ServingSizeID");

                    b.HasKey("ID");

                    b.HasIndex("EstimatedCostID");

                    b.HasIndex("ServingSizeID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("FoodPrepData.DataModels.ServingSize", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ID");

                    b.ToTable("ServingSize");
                });

            modelBuilder.Entity("FoodPrepData.DataModels.Recipe", b =>
                {
                    b.HasOne("FoodPrepData.DataModels.EstimatedCost", "EstimatedCost")
                        .WithMany()
                        .HasForeignKey("EstimatedCostID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FoodPrepData.DataModels.ServingSize", "ServingSize")
                        .WithMany()
                        .HasForeignKey("ServingSizeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
