using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsinasManager.Infrastructure.Data.Context
{
	public class UsinasManagerContext : DbContext
	{
		public UsinasManagerContext() : base("UsinasManagerDB")
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
