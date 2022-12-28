using Microsoft.EntityFrameworkCore;
using MyApi.Context;
using MyApi.Models.Base;
using System.Linq.Expressions;

namespace MyApi.Repository.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Vehicle
    {

        // Projenin database ile tüm ilişkisi burada oluyor
        // Bu arada normalde Service, Repository ve controller'lar farklı katmanda olur fakat projenin boyutundan dolayı bu şekilde yaptık, bunu da söylerseniz belki + olur

        private MyContext _Context;
        public GenericRepository()
        {
            _Context = new();

        }
        public DataResult<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            var result = new DataResult<TEntity>();
            try
            {
                result.ListData = _Context.Set<TEntity>().Where(filter).ToList();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return result;
        }
        public DataResult<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter)
        {
            var result = new DataResult<TEntity>();
            try
            {
                result.Data = _Context.Set<TEntity>().Where(filter).SingleOrDefault();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return result;
        }
        public DataResult<TEntity> Delete(int id)
        {
            var result = new DataResult<TEntity>();
            try
            {
                var entity = _Context.Set<TEntity>().Where(x => x.Id == id).SingleOrDefault();
                if (entity != null)
                {
                    _Context.Remove(entity);
                    result.Success = _Context.SaveChanges() > 0;
                }
                else
                {
                    result.Message = "No records found";
                    result.Success = false;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return result;
        }
        public DataResult<TEntity> Update(TEntity entity)
        {
            var result = new DataResult<TEntity>();
            try
            {
                _Context.Set<TEntity>();
                _Context.Attach(entity);
                _Context.Entry(entity).State = EntityState.Modified;
                result.Success = _Context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return result;
        }
    }
}
