using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositoryFactory
    {
        public static IRepository CreateRepository()
        {
            //return new EFRepository(new Entities.NWindEntities());
            var Context = new Entities.CONTOSOPetsDBEntities();
            Context.Configuration.ProxyCreationEnabled = false;
            return new EFRepository(Context);
        }
    }
}
