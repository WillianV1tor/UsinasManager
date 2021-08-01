using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Entities;
using UsinasManager.Domain.Entities.Filtros;
using UsinasManager.Domain.Interfaces.Repositories;

namespace UsinasManager.Infrastructure.Data.Repositories
{
	public class UsinaRepository : RepositoryBase<Usina>, IUsinaRepository
	{
		public IEnumerable<Usina> FiltrarDados(FiltroUsina filtroUsina)
		{
			//var query = from item in UsinasManagerContext.Usinas
			//			where item.FornecedorId == filtroUsina.FornecedorID
			//			&& item.UC == filtroUsina.UC
			//			&& item.Ativo == filtroUsina.Ativo
			//			select item;
			//return query;
			throw new NotImplementedException();
		}
	}
}
