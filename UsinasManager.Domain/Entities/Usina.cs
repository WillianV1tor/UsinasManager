using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsinasManager.Domain.Entities
{
	public class Usina
	{
		public int UsinaId { get; set; }

		public string UC { get; set; }

		public bool Ativo { get; set; }

		public int FornecedorId { get; set; }

		public virtual Fornecedor Fornecedor { get; set; }
	}
}
