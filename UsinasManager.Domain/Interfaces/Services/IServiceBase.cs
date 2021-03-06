using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsinasManager.Domain.Interfaces.Services
{
	public interface IServiceBase<TEntity> where TEntity : class
	{
		void Add(TEntity entity);

		void Update(TEntity entity);

		void Delete(TEntity entity);

		TEntity GetById(int id);

		IEnumerable<TEntity> GetAll();

		void Dispose();
	}
}
