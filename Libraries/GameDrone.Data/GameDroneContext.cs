using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using GameDrones.Data.Matches;
using GameDrones.Data.Players;
using GameDrones.Domain;
using GameDrones.Domain.Matches;
using GameDrones.Domain.Players;
using Microsoft.EntityFrameworkCore;

namespace GameDrones.Data
{
    public class GameDroneContext : DbContext, IDbContext
    {
        #region Properties

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Match> Matches { get; set; }

        public Func<String> UserProvider { get; set; } = () => WindowsIdentity.GetCurrent().Name;
        public Func<DateTime> TimestampProvider { get; set; } = () => DateTime.UtcNow;

        #endregion

        #region Constructors

        public GameDroneContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        public GameDroneContext(DbContextOptions<GameDroneContext> options) : base(options)
        {
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerClassMapping());
            modelBuilder.ApplyConfiguration(new MatchClassMapping());

            foreach (var entity in modelBuilder.Model.GetEntityTypes().Where(x => typeof(IAuditable).IsAssignableFrom(x.ClrType)))
            {
                entity.AddProperty("CreatedBy", typeof(string)).SetMaxLength(50);
                entity.AddProperty("CreatedAt", typeof(DateTime));
                entity.AddProperty("UpdatedBy", typeof(string)).SetMaxLength(50);
                entity.AddProperty("UpdatedAt", typeof(DateTime?));
            }

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity is IAuditable)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedBy").CurrentValue = UserProvider();
                        entry.Property("CreatedAt").CurrentValue = TimestampProvider();
                    }
                    else
                    {
                        entry.Property("UpdatedBy").CurrentValue = UserProvider();
                        entry.Property("UpdatedAt").CurrentValue = TimestampProvider();
                    }
                }

                Validator.ValidateObject(entry.Entity, new ValidationContext(entry.Entity));
            }

            return await base.SaveChangesAsync();
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            var modelBuilder = new DbContextOptionsBuilder();
            return modelBuilder.UseSqlServer(connectionString).Options;
        }

        /// <inheritdoc />
        public new DbSet<TEntity> Set<TEntity>()
            where TEntity : class, IEntity
        {
            return base.Set<TEntity>();
        }

        #endregion
    }
}
