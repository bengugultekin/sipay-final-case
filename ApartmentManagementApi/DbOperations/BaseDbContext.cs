﻿using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi;

public class BaseDbContext : DbContext, IBaseDbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    public DbSet<Bill> Bills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Bills tablosundaki UserId alanını, Users tablosundaki Id alanına bağla
        modelBuilder.Entity<Bill>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bills)
            .HasForeignKey(b => b.UserId);
    }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}
