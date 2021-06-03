using DynamicDAL.Repository.Base;
using DynamicDALSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDALSample.BL
{
    //inheritance from BaseController
    public class ShareController : BL.Base.BaseController<Models.Share, int>
    {
        //types property get => Assembly.GetExecutingAssembly() 
        public override Assembly types { get => Assembly.GetExecutingAssembly(); set => throw new NotImplementedException(); }


        //You can choose type of Data Base Connection
        // 0 => Entity
        // 1 => ADO
        public override int dbconnectiontype { get => 0; set => throw new NotImplementedException(); }

        public override IRepository<Share, int> CreateRepository()
        {
            return DynamicDAL.Repository.Factory<Models.Share, int>.DALTypeSelector(types, dbconnectiontype);
        }

        public override string TranslateException(string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
