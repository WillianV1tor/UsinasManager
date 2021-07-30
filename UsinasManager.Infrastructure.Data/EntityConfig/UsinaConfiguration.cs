using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Entities;

namespace UsinasManager.Infrastructure.Data.EntityConfig
{
	public class UsinaConfiguration : EntityTypeConfiguration<Usina>
	{
		public UsinaConfiguration()
		{
			HasKey(u => u.UsinaId);

			Property(u => u.UC)
				.IsRequired();

			Property(u => u.Ativo)
				.IsRequired();

			HasRequired(u => u.Fornecedor)
					.WithMany()
					.HasForeignKey(u => u.FornecedorId);
		}
	}
}
