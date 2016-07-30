namespace gtech.mobilefinance.dal
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=MOBILEFINANCE")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Location>().ToTable("Locations");
            modelBuilder.Entity<Phone>().ToTable("Phones");
            modelBuilder.Entity<PhoneType>().ToTable("PhoneTypes");
            modelBuilder.Entity<Photo>().ToTable("Photos");
            modelBuilder.Entity<Province>().ToTable("Provinces");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
    }
    }
}
