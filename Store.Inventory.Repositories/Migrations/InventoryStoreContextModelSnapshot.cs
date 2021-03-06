// <auto-generated />
using System;
using Inventory.Store.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Store.Inventory.Repositories.Migrations
{
    [DbContext(typeof(InventoryStoreContext))]
    partial class InventoryStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Store.Inventory.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6171),
                            IsActive = true,
                            Name = "Category1",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6173)
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6176),
                            IsActive = true,
                            Name = "Category2",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6177)
                        });
                });

            modelBuilder.Entity("Store.Inventory.Domain.Models.InventoryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("InventoryStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6015),
                            IsActive = true,
                            Name = "Sold",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6028)
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6116),
                            IsActive = true,
                            Name = "Damaged",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6117)
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6118),
                            IsActive = true,
                            Name = "InStock",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6119)
                        });
                });

            modelBuilder.Entity("Store.Inventory.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InventoryStatusId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InventoryStatusId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BarCode = "BarCode1",
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6210),
                            Description = "Test Product 1",
                            IsActive = true,
                            Name = "Product1",
                            StatusId = 3,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6211),
                            Weight = 20.0
                        },
                        new
                        {
                            Id = 2,
                            BarCode = "BarCode2",
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6216),
                            Description = "Test Product 2",
                            IsActive = true,
                            Name = "Product2",
                            StatusId = 3,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6216),
                            Weight = 30.0
                        },
                        new
                        {
                            Id = 3,
                            BarCode = "BarCode3",
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6219),
                            Description = "Test Product 3",
                            IsActive = true,
                            Name = "Product3",
                            StatusId = 2,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6220),
                            Weight = 40.0
                        },
                        new
                        {
                            Id = 4,
                            BarCode = "BarCode4",
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6223),
                            Description = "Test Product 4",
                            IsActive = true,
                            Name = "Product4",
                            StatusId = 1,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6224),
                            Weight = 50.0
                        });
                });

            modelBuilder.Entity("Store.Inventory.Domain.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(62),
                            IsActive = true,
                            ProductId = 1,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(69)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(74),
                            IsActive = true,
                            ProductId = 1,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(75)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(77),
                            IsActive = true,
                            ProductId = 2,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(78)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(79),
                            IsActive = true,
                            ProductId = 3,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(79)
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(81),
                            IsActive = true,
                            ProductId = 4,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(81)
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(85),
                            IsActive = true,
                            ProductId = 4,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(85)
                        });
                });

            modelBuilder.Entity("Store.Inventory.Domain.Models.Product", b =>
                {
                    b.HasOne("Store.Inventory.Domain.Models.InventoryStatus", "InventoryStatus")
                        .WithMany()
                        .HasForeignKey("InventoryStatusId");

                    b.Navigation("InventoryStatus");
                });

            modelBuilder.Entity("Store.Inventory.Domain.Models.ProductCategory", b =>
                {
                    b.HasOne("Store.Inventory.Domain.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Inventory.Domain.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Store.Inventory.Domain.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("Store.Inventory.Domain.Models.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
