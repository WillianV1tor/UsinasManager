using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Application.Interfaces;
using UsinasManager.Domain.Entities;
using UsinasManager.Domain.Interfaces.Services;

namespace UsinasManager.Application
{
	public class FornecedorApplicationService : ApplicationServiceBase<Fornecedor>, IFornecedorApplicationService
	{
		private readonly IFornecedorService _fornecedorService;

		public FornecedorApplicationService(IFornecedorService fornecedorService) : base(fornecedorService)
		{
			_fornecedorService = fornecedorService;
		}
	}
}
