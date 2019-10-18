﻿// <auto-generated />
using FoodPrepData.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodPrepAPICore.Migrations
{
    [DbContext(typeof(FoodPrepContext))]
    partial class FoodPrepContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodPrepData.DataModels.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

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

            modelBuilder.Entity("FoodPrepData.DataModels.Ingredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("FoodPrepData.DataModels.QuantityType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ID");

                    b.ToTable("QuantityType");
                });

            modelBuilder.Entity("FoodPrepData.DataModels.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstimatedCostID");

                    b.Property<string>("Info");

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

            modelBuilder.Entity("FoodPrepData.DataModels.RecipeCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID");

                    b.Property<int>("RecipeID");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeCategories");
                });

            modelBuilder.Entity("FoodPrepData.DataModels.RecipeIngredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngredientID");

                    b.Property<float>("Quantity");

                    b.Property<int>("QuantityTypeID");

                    b.Property<int>("RecipeID");

                    b.HasKey("ID");

                    b.HasIndex("IngredientID");

                    b.HasIndex("QuantityTypeID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeIngredients");
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

            modelBuilder.Entity("FoodPrepData.DataModels.RecipeCategory", b =>
                {
                    b.HasOne("FoodPrepData.DataModels.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FoodPrepData.DataModels.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FoodPrepData.DataModels.RecipeIngredient", b =>
                {
                    b.HasOne("FoodPrepData.DataModels.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FoodPrepData.DataModels.QuantityType", "QuantityType")
                        .WithMany()
                        .HasForeignKey("QuantityTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FoodPrepData.DataModels.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
