namespace ClanWork.v1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelForAll : DbContext
    {
        public ModelForAll()
            : base("name=ModelForAll")
        {
        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<NewMembTab> NewMembTabs { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .Property(e => e.Money)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Logins)
                .WithOptional(e => e.Member)
                .WillCascadeOnDelete();
        }
    }
}
