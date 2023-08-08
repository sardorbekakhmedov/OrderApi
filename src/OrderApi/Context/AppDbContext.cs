using Microsoft.EntityFrameworkCore;
using OrderApi.Entities;

namespace OrderApi.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        UpdateTimeStampForBaseEntityClass();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimeStampForBaseEntityClass()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not BaseEntity entity)
                continue;

            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entity.UpdateAt = DateTime.UtcNow;
                    break;
            }
        }
    }
}