global using Microsoft.EntityFrameworkCore;
global using Store.Inventory.Domain.Models;
global using Store.Inventory.Domain.Enum;

namespace Inventory.Store.Repositories.Context;

public partial class InventoryStoreContext : DbContext
{
    public InventoryStoreContext() : base()
    {
        //this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public InventoryStoreContext(DbContextOptions<InventoryStoreContext> options) : base(options)
    {
        //this.ChangeTracker.QueryTrackingBehavior =QueryTrackingBehavior.NoTracking;
        //Database.SetCommandTimeout(20000);
    }

    // DBSets
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<InventoryStatus> InventoryStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedInventoryStatusData(modelBuilder);
        SeedCategooryData(modelBuilder);
        SeedProductData(modelBuilder);
        SeedCategoryProductData(modelBuilder);
    }

    private static void SeedCategooryData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new List<Category>() {
            new Category { Id = 1, Name = "Category1", CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new Category { Id = 2, Name = "Category2", CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true}
        });
    }

    private static void SeedInventoryStatusData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryStatus>().HasData(new List<InventoryStatus>() {
            new InventoryStatus { Id = 1, Name = "Sold",    CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new InventoryStatus { Id = 2, Name = "Damaged", CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new InventoryStatus { Id = 3, Name = "InStock", CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true}
        });
    }

    private static void SeedProductData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new List<Product>() {
            new Product { Id = 1, Name = "Product1", BarCode="BarCode1", Description="Test Product 1", StatusId = (int)Status.InStock, Weight = 20, CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new Product { Id = 2, Name = "Product2", BarCode="BarCode2", Description="Test Product 2", StatusId = (int)Status.InStock, Weight = 30, CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new Product { Id = 3, Name = "Product3", BarCode="BarCode3", Description="Test Product 3", StatusId = (int)Status.Damaged, Weight = 40, CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new Product { Id = 4, Name = "Product4", BarCode="BarCode4", Description="Test Product 4", StatusId = (int)Status.Sold,    Weight = 50, CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
        });
    }

    private static void SeedCategoryProductData(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ProductCategory>()
            .HasKey(t => t.Id);

        modelBuilder
            .Entity<ProductCategory>()
            .HasOne(c => c.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryId);

        modelBuilder
            .Entity<ProductCategory>()
            .HasOne(p => p.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);

        modelBuilder.Entity<ProductCategory>().HasData(new List<ProductCategory>() {
            new ProductCategory { Id = 1, CategoryId = 1, ProductId = 1, CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new ProductCategory { Id = 2, CategoryId = 2, ProductId = 1, CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new ProductCategory { Id = 3, CategoryId = 1, ProductId = 2, CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new ProductCategory { Id = 4, CategoryId = 2, ProductId = 3, CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new ProductCategory { Id = 5, CategoryId = 1, ProductId = 4, CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true},
            new ProductCategory { Id = 6, CategoryId = 2, ProductId = 4, CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsActive = true}
        });
    }
}