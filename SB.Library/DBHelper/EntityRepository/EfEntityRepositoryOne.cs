using Microsoft.EntityFrameworkCore;
using SB.Library.Enum;
using SB.Library.Helper;
using SB.Library.LibraryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SB.Library.DBHelper.EntityRepository
{
    public class EfEntityRepositoryOne<TEntity> : IEfEntityRepositoryOne<TEntity> where TEntity : class, new()
    {
        private NLog.Logger Logger;
        private readonly DbContext DB;

        public EfEntityRepositoryOne(DbContext tContext)
        {
            DB = tContext;
        }
        public List<TEntity> _findEntityAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeProperties)
        {
            List<TEntity> result = new List<TEntity>();
            try
            {
                IQueryable<TEntity> query = DB.Set<TEntity>();
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }

                result = filter == null ? query.ToList() : query.Where(filter).ToList();
            }
            catch (Exception ex)
            {
                throw new CustomExceptionHelper(EnumErrorCode.NULL,
                                                EnumErrorCodeType.Code,
                                                EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError),
                                                NLog.LogManager.GetCurrentClassLogger(), ex);
            }
            return result;
        }
        public TEntity _findEntity(Expression<Func<TEntity, bool>> filter, params string[] includeProperties)
        {
            TEntity result = new TEntity();
            try
            {
                IQueryable<TEntity> query = DB.Set<TEntity>();
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }

                result = filter == null ? query.SingleOrDefault() : query.SingleOrDefault(filter);
            }
            catch (Exception ex)
            {
                throw new CustomExceptionHelper(EnumErrorCode.NULL,
                                                EnumErrorCodeType.Code,
                                                EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError),
                                                NLog.LogManager.GetCurrentClassLogger(), ex);
            }
            return result;
        }

        public TEntity _add(TEntity entity)
        {
            TEntity result = new TEntity();
            try
            {
                var addedEntity = DB.Entry(entity);
                addedEntity.State = EntityState.Added;
                DB.SaveChanges();

                result = addedEntity.Entity;
            }
            catch (Exception ex)
            {
                throw new CustomExceptionHelper(EnumErrorCode.NULL,
                                                EnumErrorCodeType.Code,
                                                EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError),
                                                NLog.LogManager.GetCurrentClassLogger(), ex);
            }
            return result;
        }
        public bool _addAll(ICollection<TEntity> entityList)
        {
            bool result = new bool();
            try
            {
                DB.AddRange(entityList);
                DB.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                throw new CustomExceptionHelper(EnumErrorCode.NULL,
                                                EnumErrorCodeType.Code,
                                                EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError),
                                                NLog.LogManager.GetCurrentClassLogger(), ex);
            }
            return result;
        }
        public TEntity _update(TEntity entity)
        {
            TEntity result = new TEntity();
            try
            {
                var updatedEntity = DB.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                DB.SaveChanges();
                result = entity;
            }
            catch (Exception ex)
            {
                throw new CustomExceptionHelper(EnumErrorCode.NULL,
                                                EnumErrorCodeType.Code,
                                                EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError),
                                                NLog.LogManager.GetCurrentClassLogger(), ex);
            }
            return result;

        }
        public bool _delete(TEntity entity)
        {
            bool result = new bool();
            try
            {
                var updatedEntity = DB.Entry(entity);
                updatedEntity.State = EntityState.Deleted;
                DB.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                throw new CustomExceptionHelper(EnumErrorCode.NULL,
                                                EnumErrorCodeType.Code,
                                                EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError),
                                                NLog.LogManager.GetCurrentClassLogger(), ex);
            }
            return result;
        }
    }
}
