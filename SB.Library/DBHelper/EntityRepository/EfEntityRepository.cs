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
    public class EfEntityRepository<TEntity, TContext> : IEfEntityRepository<TEntity> where TEntity : class, new() where TContext : DbContext, new()
    {
        private NLog.Logger Logger;

        public ResultObject<List<TEntity>> _findEntityAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeProperties)
        {
            ResultObject<List<TEntity>> result = new ResultObject<List<TEntity>>();
            try
            {
                using (var DB = new TContext())
                {
                    IQueryable<TEntity> query = DB.Set<TEntity>();
                    foreach (var item in includeProperties)
                    {
                        query = query.Include(item);
                    }

                    result.Result = filter == null ? query.ToList() : query.Where(filter).ToList();
                }
            }
            catch (Exception ex)
            {
                result.Message = EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError);
                result.IsError = true;
                result.Exception = ex;
                Logger = NLog.LogManager.GetCurrentClassLogger();
                Logger.Error(ex, "_findEntityAll");
            }
            return result;
        }
        public ResultObject<TEntity> _findEntity(Expression<Func<TEntity, bool>> filter, params string[] includeProperties)
        {
            ResultObject<TEntity> sonuc = new ResultObject<TEntity>();
            try
            {
                using (var DB = new TContext())
                {
                    IQueryable<TEntity> query = DB.Set<TEntity>();
                    foreach (var item in includeProperties)
                    {
                        query = query.Include(item);
                    }

                    sonuc.Result = filter == null ? query.SingleOrDefault() : query.SingleOrDefault(filter);
                }
            }
            catch (Exception ex)
            {
                sonuc.Message = EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError);
                sonuc.IsError = true;
                Logger = NLog.LogManager.GetCurrentClassLogger();
                Logger.Error(ex, "_findEntity");
            }
            return sonuc;
        }

        public ResultObject<TEntity> _add(TEntity entity)
        {
            ResultObject<TEntity> result = new ResultObject<TEntity>();
            try
            {
                using (var DB = new TContext())
                {
                    var addedEntity = DB.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    DB.SaveChanges();

                    result.Result = addedEntity.Entity;
                }
            }
            catch (Exception ex)
            {
                result.Message = EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError);
                result.IsError = true;
                result.Exception = ex;
                Logger = NLog.LogManager.GetCurrentClassLogger();
                Logger.Error(ex, "_add");
            }
            return result;
        }
        public ResultObject<bool> _addAll(ICollection<TEntity> entityList)
        {
            ResultObject<bool> result = new ResultObject<bool>();
            try
            {
                using (var DB = new TContext())
                {
                    DB.AddRange(entityList);
                    DB.SaveChanges();

                    result.Result = true;
                }
            }
            catch (Exception ex)
            {
                result.Message = EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError);
                result.IsError = true;
                result.Exception = ex;
                Logger = NLog.LogManager.GetCurrentClassLogger();
                Logger.Error(ex, "_addAll");
            }
            return result;
        }
        public ResultObject<TEntity> _update(TEntity entity)
        {
            ResultObject<TEntity> result = new ResultObject<TEntity>();
            try
            {
                using (var DB = new TContext())
                {
                    var updatedEntity = DB.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    DB.SaveChanges();
                    result.Result = entity;
                }
            }
            catch (Exception ex)
            {
                result.Message = EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError);
                result.IsError = true;
                result.Exception = ex;
                Logger = NLog.LogManager.GetCurrentClassLogger();
                Logger.Error(ex, "_update");
            }
            return result;

        }
        public ResultObject<bool> _delete(TEntity entity)
        {
            ResultObject<bool> result = new ResultObject<bool>();
            try
            {
                using (var DB = new TContext())
                {
                    var updatedEntity = DB.Entry(entity);
                    updatedEntity.State = EntityState.Deleted;
                    DB.SaveChanges();

                    result.Result = true;
                }
            }
            catch (Exception ex)
            {
                result.IsError = false;
                result.Message = EnumHelper<EnumResultMessage>.getEnumDescription(EnumResultMessage.SystemError);
                result.Exception = ex;
                Logger = NLog.LogManager.GetCurrentClassLogger();
                Logger.Error(ex, "_delete");
            }
            return result;
        }
    }
}
