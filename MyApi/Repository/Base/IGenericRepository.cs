using MyApi.Models.Base;
using System.Linq.Expressions;

namespace MyApi.Repository.Base
{
    public interface IGenericRepository<TEntity>
    {
        DataResult<TEntity> GetList(Expression<Func<TEntity, bool>> filter);
        DataResult<TEntity> Delete(int id);
        DataResult<TEntity> Update(TEntity entity);
        DataResult<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter);
    }
}
