// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Data;
// using Microsoft.EntityFrameworkCore;
// using System.Linq.Expressions;
// using apivent.Infrastructure.Context;
// using apivent.Application.Interfaces;

// namespace apivent.Application.Repositories
// {
//     public class GenericBaseRepository<TEntity>  : IGenericRepository<TEntity> where TEntity : class 
//     {
//         internal AppContexto context;
//         internal DbSet<TEntity> dbSet;

//         public GenericBaseRepository(AppContexto context)
//         {
//             this.context = context;
//             this.dbSet = context.Set<TEntity>();
//         }

//         public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
//                                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
//                                                 string includeProperties = "")
//         {
//             IQueryable<TEntity> query = dbSet;

//             if (filter != null)
//                 query = query.Where(filter);

//             foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
//                 query = query.Include(includeProperty);

//             if (orderBy != null)
//                 return orderBy(query).ToList();            
            
//             return query.ToList();
//         }

//         public virtual IQueryable<TEntity> GetQueryList(Expression<Func<TEntity, bool>> filter = null,
//                                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
//                                                 string includeProperties = "")
//         {
//             IQueryable<TEntity> query = dbSet;

//             if (filter != null)
//                 query = query.Where(filter);

//             foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
//                 query = query.Include(includeProperty);

//             if (orderBy != null)
//                 return orderBy(query);            
            
//             return query;
//         }

//         public virtual TEntity GetById(object id)
//         {
//             return context.Find<TEntity>(id);
//         }

//         public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
//         {
//            return context.Set<TEntity>().Where(expression);
//         }
        
//         public virtual void Add(TEntity entity)
//         {
//             dbSet.Add(entity);
//         }

//         public virtual void AddRange(IEnumerable<TEntity> entity)
//         {
//             dbSet.AddRange(entity);
//         }

//         public virtual void Delete(object id)
//         {
//             TEntity entityToDelete = dbSet.Find(id);
//             Delete(entityToDelete);
//         }

//         public virtual void Delete(TEntity entityToDelete)
//         {
//             if (context.Entry(entityToDelete).State == EntityState.Detached)
//                 dbSet.Attach(entityToDelete);

//             dbSet.Remove(entityToDelete);
//         }

//         public virtual void DeleteRange(IEnumerable<TEntity> entitiesToDelete)
//         {
//             dbSet.RemoveRange(entitiesToDelete);
//         }

//         public virtual void Update(TEntity entityToUpdate)
//         {
//             dbSet.Attach(entityToUpdate);
//             context.Entry(entityToUpdate).State = EntityState.Modified;
//         }

//         public int Save()
//         {
//             return context.SaveChanges();
//         }

//         public void Dispose()
//         {
//             context.Dispose();
//         }

//          public void BeginTransaction()
//         {
//             context.Database.BeginTransaction();
//         }

//         public void CommitTransaction()
//         {
//             context.Database.CommitTransaction();
//         }

//         public void RollbackTransaction()
//         {
//             context.Database.RollbackTransaction();
//         }

//         public void DisposeTransaction()
//         {
//             context.Database.CurrentTransaction.Dispose();
//         }
//     }
// }
