using SB.Library.LibraryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SB.Library.DBHelper.EntityRepository
{
    public interface IEfEntityRepositoryOne<TEntity> where TEntity : class
    {
        List<TEntity> _findEntityAll(Expression<Func<TEntity, bool>> filtre = null, params string[] includeProperties);
        TEntity _findEntity(Expression<Func<TEntity, bool>> filtre, params string[] includeProperties);
        TEntity _add(TEntity entity);
        bool _addAll(ICollection<TEntity> entityList);
        TEntity _update(TEntity entity);
        bool _delete(TEntity entity);
    }
}
