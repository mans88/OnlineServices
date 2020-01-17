using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineServices.Common.DataAccessHelpers
{
    public class GenericRepository<TEntity, TIdType> : IRepositoryDO_NOT_USE<TEntity, TIdType>
        where TEntity : class, IEntity<TIdType>
    {
        private readonly DbContext dbContext;

        public GenericRepository(DbContext dBContext)
        {
            this.dbContext = dBContext;
        }

        void IRepositoryDO_NOT_USE<TEntity, TIdType>.Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        void IRepositoryDO_NOT_USE<TEntity, TIdType>.Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        //private bool Equalite(TIdType a, TIdType b)
        //{
        //    return EqualityComparer<TIdType>.Default.Equals(a,b);
        //}

        void IRepositoryDO_NOT_USE<TEntity, TIdType>.Delete(TIdType id)
        {
            var entityToDelete = dbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
            if (entityToDelete != null)
            {
                dbContext.Set<TEntity>().Remove(entityToDelete);
            }
        }

        void IRepositoryDO_NOT_USE<TEntity, TIdType>.Edit(TEntity entity)
        {
            var editedEntity = dbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(entity.Id));
            editedEntity = entity;
        }

        IEnumerable<TEntity> IRepositoryDO_NOT_USE<TEntity, TIdType>.GetAll()
        {
            return dbContext.Set<TEntity>();
        }

        IEnumerable<TEntity> IRepositoryDO_NOT_USE<TEntity, TIdType>.Filter(Func<TEntity, bool> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate);
        }

        TEntity IRepositoryDO_NOT_USE<TEntity, TIdType>.GetById(TIdType id)
        {
            return dbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
        }

        int IRepositoryDO_NOT_USE<TEntity, TIdType>.SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public delegate TEntity ToEntity(TEntity a);
        public delegate TEntity ToTransfertObject(TEntity a);
    }
}

