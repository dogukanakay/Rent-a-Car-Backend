using Core.Entities.Concrete;
using Entites.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Context
{
    public class ReCapProjectContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<GearType> GearTypes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<RentalLocation> RentalLocations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DOGUKAN\SQLEXPRESS; Database= RentACar; Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Model>()
            //    .HasOne(i => i.Brand)
            //    .WithMany(i => i.Models)
            //    .HasForeignKey(i => i.BrandId);

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Models)
                .WithOne(m => m.Brand)
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Cars)
                .WithOne(c => c.Brand)
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarClass>()
                .HasMany(cc => cc.Cars)
                .WithOne(c => c.CarClass)
                .HasForeignKey(c => c.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Color>()
                .HasMany(co => co.Cars)
                .WithOne(c => c.Color)
                .HasForeignKey(c => c.ColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FuelType>()
                .HasMany(f => f.Cars)
                .WithOne(c => c.FuelType)
                .HasForeignKey(c => c.FuelId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<GearType>()
                .HasMany(g => g.Cars)
                .WithOne(c => c.GearType)
                .HasForeignKey(c => c.GearId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Model>()
                .HasMany(m => m.Cars)
                .WithOne(c => c.Model)
                .HasForeignKey(c => c.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalLocation>()
                .HasMany(rl => rl.Cars)
                .WithOne(c => c.RentalLocation)
                .HasForeignKey(c => c.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalLocation>()
                .HasMany(rl => rl.Rentals)
                .WithOne(r => r.RentalLocation)
                .HasForeignKey(r => r.PickupLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalLocation>()
               .HasMany(rl => rl.Rentals)
               .WithOne(r => r.RentalLocation)
               .HasForeignKey(r => r.DropoffLocationId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.CarImages)
                .WithOne(ci => ci.Car)
                .HasForeignKey(ci => ci.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Rentals)
                .WithOne(r=>r.Car)
                .HasForeignKey(r=>r.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasMany(cu=>cu.Payments)
                .WithOne(p=>p.Customer)
                .HasForeignKey(p=>p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
               .HasMany(cu => cu.PaymentCards)
               .WithOne(pc => pc.Customer)
               .HasForeignKey(pc => pc.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasMany(cu => cu.Rentals)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rental>()
               .HasOne(r=>r.Payment)
               .WithOne(p=>p.Rental)
               .HasForeignKey<Payment>(p=>p.RentId)
               .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<User>()
               .HasMany(u=>u.UserOperationClaims)
               .WithOne(up=>up.User)
               .HasForeignKey(up=>up.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OperationClaim>()
               .HasMany(oc=>oc.UserOperationClaims)
               .WithOne(up=>up.OperationClaim)
               .HasForeignKey(up=>up.OperationClaimId)
               .OnDelete(DeleteBehavior.Restrict);
              
        }
    }
}