using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Entities;

namespace UsinasManager.Infrastructure.Data.Context
{
	public class UsinasManagerDBInitializer : DropCreateDatabaseAlways<UsinasManagerContext>
	{
        protected override void Seed(UsinasManagerContext usinasManagerContext)
        {
			IList<Fornecedor> fornecedoresDefault = new List<Fornecedor>
			{
				new Fornecedor() { FornecedorId = 1, Nome = "SOLARIAN" },
				new Fornecedor() { FornecedorId = 2, Nome = "FUTURA" },
				new Fornecedor() { FornecedorId = 3, Nome = "CENTRAL GERADORA FAZENDA MODELO" },
				new Fornecedor() { FornecedorId = 4, Nome = "NOVA MUNDO" },
				new Fornecedor() { FornecedorId = 5, Nome = "SOLARE" },
				new Fornecedor() { FornecedorId = 6, Nome = "UNISOL" }
			};

			usinasManagerContext.Fornecedores.AddRange(fornecedoresDefault);

            base.Seed(usinasManagerContext);
        }
    }
}
