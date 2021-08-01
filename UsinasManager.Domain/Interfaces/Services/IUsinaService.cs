using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Entities;
using UsinasManager.Domain.Entities.Filtros;

namespace UsinasManager.Domain.Interfaces.Services
{
	public interface IUsinaService : IServiceBase<Usina>
	{
		IEnumerable<Usina> FiltrarDados(FiltroUsina filtroUsina);
	}
}
