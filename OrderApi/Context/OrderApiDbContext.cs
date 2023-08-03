using Microsoft.EntityFrameworkCore;
using OrderApi.Entities;

namespace OrderApi.Context;

public class OrderApiDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    public OrderApiDbContext(DbContextOptions<OrderApiDbContext> options) : base(options)
    { }
}