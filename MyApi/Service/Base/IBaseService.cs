using MyApi.Enums;
using MyApi.Models.Base;
using System.Linq.Expressions;

namespace MyApi.Service.Base
{
    public interface IBaseService<TEntity>
    {
        DataResult<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter);
        DataResult<TEntity> GetList(Expression<Func<TEntity, bool>> filter);
        DataResult<TEntity> Delete(int id);
        DataResult<TEntity> Update(TEntity entity);
    }
}
