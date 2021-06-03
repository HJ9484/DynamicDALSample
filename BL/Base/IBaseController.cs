using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDALSample.BL.Base
{
    public interface IBaseController<TEntity>

    {
        List<TEntity> GetList();
        Task<List<TEntity>> GetListAsync();
        DynamicDAL.ActionResult Create(TEntity instance);
        Task<DynamicDAL.ActionResult> CreateAsync(TEntity instance);
        DynamicDAL.ActionResult Edit(TEntity instance);
        Task<DynamicDAL.ActionResult> EditAsync(TEntity instance);
        DynamicDAL.ActionResult Delete(TEntity instance);
        Task<DynamicDAL.ActionResult> DeleteAsync(TEntity instance);
        Task<DynamicDAL.ActionResult> BulkinsertAsync(TEntity instance, int count, int commitCount);


    }
}
