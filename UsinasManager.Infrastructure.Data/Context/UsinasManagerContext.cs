using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsinasManager.Domain.Entities;
using UsinasManager.Infrastructure.Data.EntityConfig;

namespace UsinasManager.Infrastructure.Data.Context
{
	public class UsinasManagerContext : DbContext
	{
		public UsinasManagerContext() : base("UsinasManagerDB")
		{
			Database.SetInitializer(new UsinasManagerDBInitializer());
			Configuration.ProxyCreationEnabled = true;
			Configuration.LazyLoadingEnabled = true;
		}

		public DbSet<Fornecedor> Fornecedores { get; set; }

		public DbSet<Usina> Usinas { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

			modelBuilder.Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));

			modelBuilder.Properties<string>()
				.Configure(p => p.HasMaxLength(200));

			modelBuilder.Configurations.Add(new FornecedorConfiguration());
			modelBuilder.Configurations.Add(new UsinaConfiguration());
		}
	}
}
