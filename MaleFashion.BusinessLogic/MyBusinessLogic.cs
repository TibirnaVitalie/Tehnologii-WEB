using MaleFashion.BusinessLogic.Interfaces;

namespace MaleFashion.BusinessLogic
{
     public class MyBusinessLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }

          public IProduct GetProductBL()
          {
               return new ProductBL();
          }
     }
}
