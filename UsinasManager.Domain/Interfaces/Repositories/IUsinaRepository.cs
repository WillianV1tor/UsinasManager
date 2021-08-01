using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Entities;
using UsinasManager.Domain.Entities.Filtros;

namespace UsinasManager.Domain.Interfaces.Repositories
{
	public interface IUsinaRepository : IRepositoryBase<Usina>
	{
		IEnumerable<Usina> FiltrarDados(FiltroUsina filtroUsina);
	}
}
