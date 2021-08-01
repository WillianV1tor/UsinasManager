using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsinasManager.Domain.Entities.Filtros
{
	public class FiltroUsina
	{
		public int? FornecedorID { get; set; }

		public string UC { get; set; }

		public bool? Ativo { get; set; }
	}
}
