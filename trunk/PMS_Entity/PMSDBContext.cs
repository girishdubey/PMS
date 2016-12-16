namespace PMS_Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PMS_Entity.Model;
    using PMS_Entity.Model.Master;

    public partial class PMSDBContext : DbContext
    {
        public PMSDBContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<PMSDBContext>(new CreateDatabaseIfNotExists<PMSDBContext>());
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<ClientRegistration> ClientRegistrations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id);

            modelBuilder.Entity<Holiday>()
                .Property(e => e.Holiday_Id);

            modelBuilder.Entity<Shift>()
                .Property(e => e.Shift_Id);

            modelBuilder.Entity<ClientRegistration>()
                .Property(e => e.RegistrationID);

        }
    }
}
