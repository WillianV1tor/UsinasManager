using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Entities;

namespace UsinasManager.Infrastructure.Data.EntityConfig
{
	public class FornecedorConfiguration : EntityTypeConfiguration<Fornecedor>
	{
		public FornecedorConfiguration()
		{
			HasKey(f => f.FornecedorId);

			Property(f => f.Nome)
				.IsRequired();
		}
	}
}
