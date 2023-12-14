using Lab3.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab3.Database{

    public class PeopleDB: DbContext{

        public PeopleDB(DbContextOptions<PeopleDB> options):base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePersonEntity(modelBuilder.Entity<PersonEntity>());
        }

        private void ConfigurePersonEntity(EntityTypeBuilder<PersonEntity> entity)
        {
            entity.ToTable("Person");
            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(p => p.LastName).IsRequired().HasMaxLength(200);
        }

        public DbSet<PersonEntity> People{get;set;}



    }



}