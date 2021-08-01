using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Interfaces.Repositories;
using UsinasManager.Domain.Interfaces.Services;

namespace UsinasManager.Domain.Services
{
	public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
	{
		private readonly IRepositoryBase<TEntity> _repositoryBase;

		public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
		{
			_repositoryBase = repositoryBase;
		}

		public void Add(TEntity entity)
		{
			_repositoryBase.Add(entity);
		}

		public void Update(TEntity entity)
		{
			_repositoryBase.Update(entity);
		}

		public void Delete(TEntity entity)
		{
			_repositoryBase.Delete(entity);
		}

		public TEntity GetById(int id)
		{
			return _repositoryBase.GetById(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _repositoryBase.GetAll();
		}

		public void Dispose()
		{
			_repositoryBase.Dispose();
		}
	}
}
