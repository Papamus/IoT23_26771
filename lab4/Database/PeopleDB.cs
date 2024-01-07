using Lab3.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab3.Database{

    public class PeopleDB: DbContext{

        public PeopleDB(DbContextOptions<PeopleDB> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigurePersonEntity(modelBuilder.Entity<PersonEntity>());
            ConfigureAddressEntity(modelBuilder.Entity<AddressEntity>());
        }

        private void ConfigurePersonEntity(EntityTypeBuilder<PersonEntity> entity)
        {
            entity.ToTable("Person");
            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(p => p.LastName).IsRequired().HasMaxLength(200);


            entity.HasOne(a => a.address)
            .WithMany(m => m.people)
            .HasForeignKey(fk => fk.AddressEntityId);
        }


         private void ConfigureAddressEntity(EntityTypeBuilder<AddressEntity> entity)
        {
            entity.ToTable("Address");
            entity.Property(a => a.City).IsRequired().HasMaxLength(200);
            entity.Property(a => a.AddressLine).IsRequired().HasMaxLength(200);
        }


        public DbSet<PersonEntity> People{get;set;}
        public DbSet<AddressEntity> Address{get;set;}



    }



}