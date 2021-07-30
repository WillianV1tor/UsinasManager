using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsinasManager.Domain.Entities
{
	public class Fornecedor
	{
		public int FornecedorId { get; set; }
		public string Nome { get; set; }

		public virtual IEnumerable<Usina> Usinas { get; set; }
	}
}
