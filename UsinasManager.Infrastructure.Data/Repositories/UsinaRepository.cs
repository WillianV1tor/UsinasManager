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
			IQueryable<Usina> query = UsinasManagerContext.Usinas;

			if (filtroUsina.Ativo != null)
			{
				query = query.Where(q => q.Ativo == filtroUsina.Ativo);
			}
			if (filtroUsina.FornecedorID != 0)
			{
				query = query.Where(q => q.FornecedorId == filtroUsina.FornecedorID);
			}
			if (filtroUsina.UC != null && filtroUsina.UC != string.Empty)
			{
				query = query.Where(q => q.UC == filtroUsina.UC);
			}

			return query.ToList();
		}
	}
}
