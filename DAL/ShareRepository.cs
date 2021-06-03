using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDALSample.DAL
{
    public class ShareRepository : DynamicDAL.Repository.Base.EntityRepository<Models.Share, int>
    {
       
        public override DbContext CreateContext()
        {
            AppContext context = new AppContext();
            return context;
        }

        public override string TranslateSqlException(int errorNumber, string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
