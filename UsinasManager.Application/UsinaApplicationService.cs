using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Application.Interfaces;
using UsinasManager.Domain.Entities;
using UsinasManager.Domain.Entities.Filtros;
using UsinasManager.Domain.Interfaces.Services;

namespace UsinasManager.Application
{
	public class UsinaApplicationService : ApplicationServiceBase<Usina>, IUsinaApplicationService
	{
		private readonly IUsinaService _usinaService;

		public UsinaApplicationService(IUsinaService usinaService) : base(usinaService)
		{
			_usinaService = usinaService;
		}

		public IEnumerable<Usina> FiltrarDados(FiltroUsina filtroUsina)
		{
			return _usinaService.FiltrarDados(filtroUsina);
		}
	}
}
