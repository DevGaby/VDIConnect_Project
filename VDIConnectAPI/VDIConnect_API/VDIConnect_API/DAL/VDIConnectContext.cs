using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VDIConnect_API.Models;

namespace VDIConnect_API.DAL
{
    public class VDIConnectContext : DbContext
    {
        public VDIConnectContext()
           : base("VDIConnect")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<VDI> VDI { get; set; }
        public DbSet<Enterprise> Enterprise { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Commentary> Commentary { get; set; }
        public DbSet<TypeInterest> TypeInterest { get; set; }
        public DbSet<TypeCommentary> TypeCommentary { get; set; }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
