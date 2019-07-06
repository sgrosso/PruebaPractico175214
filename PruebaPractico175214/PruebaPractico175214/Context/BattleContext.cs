using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entities;

namespace Persistence
{
    public class BattleContext : DbContext
    {

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Villain> Villains { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Hero>().Property(hero => hero.Name).IsRequired();
            modelBuilder.Entity<Villain>().Property(villain => villain.Name).IsRequired();
            modelBuilder.Entity<Weapon>().Property(weapon => weapon.Name).IsRequired();

            modelBuilder.Entity<Hero>()
                .HasMany<Villain>(hero => hero.Villains)
                .WithMany(villain => villain.Heroes);

        }
    }
}
