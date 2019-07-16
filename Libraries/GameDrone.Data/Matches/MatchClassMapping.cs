using GameDrones.Domain.Matches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameDrones.Data.Matches
{
    /// <summary>
    /// Class mapping of the <see cref="Match"/> entity.
    /// </summary>
    public class MatchClassMapping : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> modelBuilder)
        {
            modelBuilder
                .ToTable("Match");

            modelBuilder
                .Property(e => e.WinnerId)
                .ValueGeneratedNever();

            modelBuilder
                .Property(e => e.LoserId)
                .ValueGeneratedNever();
        }
    }
}