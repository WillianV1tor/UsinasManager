using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Entities;
using UsinasManager.Domain.Entities.Filtros;

namespace UsinasManager.Application.Interfaces
{
	public interface IUsinaApplicationService : IApplicationServiceBase<Usina>
	{
		IEnumerable<Usina> FiltrarDados(FiltroUsina filtroUsina);

		bool VerificaCadastroDuplicado(Usina usina);
	}
}
