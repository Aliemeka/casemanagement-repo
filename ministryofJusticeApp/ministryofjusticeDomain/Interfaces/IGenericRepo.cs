﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
        void Save();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void AddRange(IEnumerable<TEntity> obj);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}