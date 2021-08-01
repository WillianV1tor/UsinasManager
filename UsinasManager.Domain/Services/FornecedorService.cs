using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Entities;
using UsinasManager.Domain.Interfaces.Repositories;
using UsinasManager.Domain.Interfaces.Services;

namespace UsinasManager.Domain.Services
{
	public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
	{
		private readonly IFornecedorRepository _fornecedorRepository;
		public FornecedorService(IFornecedorRepository fornecedorRepository) : base(fornecedorRepository)
		{
			_fornecedorRepository = fornecedorRepository;
		}
	}
}
