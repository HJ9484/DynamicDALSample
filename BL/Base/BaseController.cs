//Add "Using DynamicDAL and System.Reflection"
using DynamicDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDALSample.BL.Base
{
    public abstract class BaseController<TEntity, TKey> : IBaseController<TEntity>, IDisposable
        where TEntity : class
        where TKey : struct
    {
        #region AbstractMembers
        public abstract string TranslateException(string errorMessage);
        public abstract DynamicDAL.Repository.Base.IRepository<TEntity, TKey> CreateRepository();
        public abstract Assembly types { get; set; }

        public abstract int dbconnectiontype { get; set; }

        #endregion

        #region PrivateMembers
        private async Task<DynamicDAL.ActionResult> HandleExceptionAsync(Exception ex, DynamicDAL.ActionResult result)
        {
            Exception exception = await FindInnerExceptionAsync(ex);
            if (!result.Success && result.ErrorMessage.Length != 0)
            {
                result.ErrorMessage += $"\n{TranslateException(ex.Message)}";
            }
            else
            {
                result.Success = false;
                result.ErrorMessage = $"\n{TranslateException(ex.Message)}";
            }
            return result;
        }
        private DynamicDAL.ActionResult HandleException(Exception ex, DynamicDAL.ActionResult result)
        {
            Exception exception = FindInnerException(ex);
            if (!result.Success && result.ErrorMessage.Length != 0)
            {
                result.ErrorMessage += $"\n{TranslateException(ex.Message)}";
            }
            else
            {
                result.Success = false;
                result.ErrorMessage = $"\n{TranslateException(ex.Message)}";
            }
            return result;
        }

        #endregion

        #region ProtectedMembers
        protected DynamicDAL.Repository.Base.IRepository<TEntity, TKey> _repository;
        protected Exception FindInnerException(Exception ex)
        {
            if (ex.InnerException == null)
                return ex;
            return FindInnerException(ex.InnerException);
        }
        protected async Task<Exception> FindInnerExceptionAsync(Exception ex)
        {
            if (ex.InnerException == null)
                return ex;
            return await FindInnerExceptionAsync(ex.InnerException);
        }

        protected async Task<string> GetEntityTitle()
        {
            await Task.Run(() =>
            {
                // Dowork
            });
            return string.Empty;
        }


        #endregion

       

        #region Constructors
        public BaseController()
        {
            _repository = CreateRepository();

        }

        public BaseController(DynamicDAL.Repository.Base.IRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        #endregion


        #region CRUD
        public virtual List<TEntity> GetList()
        {
            try
            {
               
                return _repository.GetList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public virtual async Task<List<TEntity>> GetListAsync()
        {
            try
            {
                
                return await _repository.GetListAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public virtual ActionResult Create(TEntity instance)
        {
            ActionResult result = new ActionResult(true, string.Empty);
            try
            {
                return _repository.Create(instance);
            }
            catch (Exception ex)
            {
                return HandleException(ex, result);
            }
        }
        public virtual async Task<ActionResult> CreateAsync(TEntity instance)
        {
            ActionResult result = new ActionResult(true, string.Empty);
            try
            {
                return await _repository.CreateAsync(instance);
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex, result);
            }
        }

        public virtual ActionResult Edit(TEntity instance)
        {
            ActionResult result = new ActionResult() { Success = true };
            try
            {
                return _repository.Edit(instance);

            }
            catch (Exception ex)
            {
                return HandleException(ex, result);
            }
        }
        public virtual async Task<ActionResult> EditAsync(TEntity instance)
        {
            ActionResult result = new ActionResult() { Success = true };
            try
            {
                return await _repository.EditAsync(instance);

            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex, result);
            }
        }

        public virtual ActionResult Delete(TEntity instance)
        {
            ActionResult result = new ActionResult() { Success = true };
            try
            {
                typeof(TEntity).GetProperty("ID").GetValue(instance);

                var id = instance.GetType().GetProperty("ID").GetValue(instance, null);

                return _repository.Delete((TKey)id);

            }
            catch (Exception ex)
            {
                return HandleException(ex, result);
            }
        }
        public virtual async Task<ActionResult> DeleteAsync(TEntity instance)
        {
            ActionResult result = new ActionResult() { Success = true };
            try
            {
                var id = instance.GetType().GetProperty("ID").GetValue(instance, null);
                return await _repository.DeleteAsync((TKey)id);

            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex, result);
            }
        }

        #endregion
        public void Dispose()
        {
            if (_repository != null)
                _repository.Dispose();
        }

        public async Task<ActionResult> BulkinsertAsync(TEntity instance, int count, int commitCount)
        {
            ActionResult result = new ActionResult(true, string.Empty);
            try
            {
                return await _repository.BulkinsertAsync(instance, count, commitCount);
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex, result);
            }
        }
    }
}
