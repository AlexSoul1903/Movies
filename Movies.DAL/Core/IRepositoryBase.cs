﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Core
{
  public interface IRepositoyBase<TEntity> where TEntity: class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Modify(TEntity entity);

        TEntity GetEntity(int entityid);
        void SellMovies(TEntity entity);
        void RentMovies(TEntity entity);

        bool Exists(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetEntities();

    }
}