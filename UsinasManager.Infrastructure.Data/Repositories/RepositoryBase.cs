using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Interfaces.Repositories;
using UsinasManager.Infrastructure.Data.Context;

namespace UsinasManager.Infrastructure.Data.Repositories
{
	public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
	{
		protected UsinasManagerContext UsinasManagerContext = new UsinasManagerContext();

		public void Add(TEntity entity)
		{
			UsinasManagerContext.Set<TEntity>().Add(entity);
			UsinasManagerContext.SaveChanges();
		}
		public void Update(TEntity entity)
		{
			UsinasManagerContext.Entry(entity).State = EntityState.Modified;
			UsinasManagerContext.SaveChanges();
		}

		public void Delete(TEntity entity)
		{
			UsinasManagerContext.Set<TEntity>().Remove(entity);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return UsinasManagerContext.Set<TEntity>().ToList();
		}

		public TEntity GetById(int id)
		{
			return UsinasManagerContext.Set<TEntity>().Find(id);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
