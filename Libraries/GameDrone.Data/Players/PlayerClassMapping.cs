using GameDrones.Domain.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameDrones.Data.Players
{
    /// <summary>
    /// Class mapping of the <see cref="Player"/> entity.
    /// </summary>
    public class PlayerClassMapping : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> modelBuilder)
        {
            modelBuilder
                .ToTable("Player");

            modelBuilder
                .Property(e => e.Name)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder
                .HasMany(e => e.LostMatches)
                .WithOne(e => e.Loser)
                .HasForeignKey(e => e.LoserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasMany(e => e.WonMatches)
                .WithOne(e => e.Winner)
                .HasForeignKey(e => e.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}