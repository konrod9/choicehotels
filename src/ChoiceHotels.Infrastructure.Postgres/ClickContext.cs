using Microsoft.EntityFrameworkCore;
using ChoiceHotels.Domain.Entities;

namespace ChoiceHotels.Infrastructure.Postgres;

public class ClickContext(DbContextOptions<ClickContext> options) : DbContext(options)
{
    public DbSet<Click> Clicks => Set<Click>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Click>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ClickId).IsRequired();
            entity.Property(e => e.Offer).IsRequired();
            entity.Property(e => e.Sub1).IsRequired();
            entity.Property(e => e.Ip).IsRequired();
            entity.Property(e => e.UserAgent).IsRequired();
            entity.Property(e => e.Timestamp).HasColumnType("timestamp with time zone");
        });
    }
}