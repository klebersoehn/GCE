using GCE.Domain.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UpCardapio.Domain
{
    public partial class GceContext : DbContext
    {
        public GceContext() : base("GceContext")
        {
            Configuration.LazyLoadingEnabled = true;

            Database.CommandTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds;
        }

        public GceContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = true;

            Database.CommandTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds;
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        public override int SaveChanges()
        {
            if (HttpContext.Current != null)
            {
                var entries = ChangeTracker.Entries().Where(m => m.State >= EntityState.Added).ToList();

                if (entries.Count > 0)
                {
                    var isAuthenticated = HttpContext.Current.User.Identity.IsAuthenticated;

                    foreach (var entry in entries)
                    {
                        if (entry.Entity is BaseEntity baseEntity)
                        {
                            if (isAuthenticated)
                            {
                                switch (entry.State)
                                {
                                    case EntityState.Added:
                                        baseEntity.CreatedBy = HttpContext.Current.User.Identity.Name;
                                        baseEntity.CreatedDate = DateTime.Now;
                                        break;

                                    case EntityState.Modified:
                                        baseEntity.UpdatedBy = HttpContext.Current.User.Identity.Name;
                                        baseEntity.UpdatedDate = DateTime.Now;

                                        Entry(baseEntity).Property(m => m.CreatedBy)
                                            .IsModified = false;

                                        Entry(baseEntity).Property(m => m.CreatedDate)
                                            .IsModified = false;
                                        break;
                                }
                            }
                            else
                            {
                                if (entry.State == EntityState.Modified)
                                {
                                    baseEntity.UpdatedBy = "Gce";
                                    baseEntity.UpdatedDate = DateTime.Now;

                                    Entry(baseEntity).Property(m => m.CreatedBy)
                                        .IsModified = false;

                                    Entry(baseEntity).Property(m => m.CreatedDate)
                                        .IsModified = false;
                                }
                            }
                        }
                    }
                }
            }

            try
            {
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);

                        raise = new InvalidOperationException(message, raise);
                    }
                }

                throw raise;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}