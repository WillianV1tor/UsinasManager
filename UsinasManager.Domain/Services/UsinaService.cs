using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Entities;
using UsinasManager.Domain.Entities.Filtros;
using UsinasManager.Domain.Interfaces.Repositories;
using UsinasManager.Domain.Interfaces.Services;

namespace UsinasManager.Domain.Services
{
	public class UsinaService : ServiceBase<Usina>, IUsinaService
	{
		private readonly IUsinaRepository _usinaRepository;

		public UsinaService(IUsinaRepository usinaRepository) : base(usinaRepository)
		{
			_usinaRepository = usinaRepository;
		}

		public IEnumerable<Usina> FiltrarDados(FiltroUsina filtroUsina)
		{
			return _usinaRepository.FiltrarDados(filtroUsina);
		}
	}
}
