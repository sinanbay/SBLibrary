using SB.Library.LibraryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SB.Library.DBHelper.EntityRepository
{
    public interface IEfEntityRepository<TEntity> where TEntity : class
    {
        ResultObject<List<TEntity>> _findEntityAll(Expression<Func<TEntity, bool>> filtre = null, params string[] includeProperties);
        ResultObject<TEntity> _findEntity(Expression<Func<TEntity, bool>> filtre, params string[] includeProperties);
        ResultObject<TEntity> _add(TEntity entity);
        ResultObject<bool> _addAll(ICollection<TEntity> entityList);
        ResultObject<TEntity> _update(TEntity entity);
        ResultObject<bool> _delete(TEntity entity);
    }
}
