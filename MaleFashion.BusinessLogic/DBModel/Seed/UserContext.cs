using System.Data.Entity;
using MaleFashion.Domain.Entities.User;

namespace MaleFashion.BusinessLogic.DBModel.Seed
{
 
     public class UserContext : DbContext
     {
          public UserContext() : base("name=MaleFashion") // connectionstring name define in your web.config
          {
          }

          public virtual DbSet<UDbTable> Users { get; set; }

          public virtual DbSet<SessionsDbTable> Sessions { get; set; }
     }
}
