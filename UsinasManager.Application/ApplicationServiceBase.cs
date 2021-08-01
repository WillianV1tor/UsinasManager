using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Application.Interfaces;
using UsinasManager.Domain.Interfaces.Services;

namespace UsinasManager.Application
{
	public class ApplicationServiceBase<TEntity> : IDisposable, IApplicationServiceBase<TEntity> where TEntity : class
	{
		private readonly IServiceBase<TEntity> _serviceBase;

		public ApplicationServiceBase(IServiceBase<TEntity> serviceBase)
		{
			_serviceBase = serviceBase;
		}

		public void Add(TEntity entity)
		{
			_serviceBase.Add(entity);
		}

		public void Update(TEntity entity)
		{
			_serviceBase.Update(entity);
		}

		public void Delete(TEntity entity)
		{
			_serviceBase.Delete(entity);
		}

		public TEntity GetById(int id)
		{
			return _serviceBase.GetById(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _serviceBase.GetAll();
		}

		public void Dispose()
		{
			_serviceBase.Dispose();
		}
	}
}
