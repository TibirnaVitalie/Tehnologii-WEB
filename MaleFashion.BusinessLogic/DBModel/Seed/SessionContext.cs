using System.Data.Entity;
using MaleFashion.Domain.Entities.User;

namespace MaleFashion.BusinessLogic.DBModel.Seed
{
     public class SessionContext : DbContext
     {
          public SessionContext() : base("name=MaleFashion")
          {
          }

          public virtual DbSet<SessionsDbTable> Sessions { get; set; }
     }
}
