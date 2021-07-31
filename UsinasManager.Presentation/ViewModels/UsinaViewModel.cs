using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsinasManager.Presentation.ViewModels
{
	public class UsinaViewModel
	{
		[Key]
		public int UsinaId { get; set; }

		[Required(ErrorMessage = "O campo UC possui preenchimento obrigatório.")]
		public string UC { get; set; }

		[Required(ErrorMessage = "O campo Ativo possui preenchimento obrigatório.")]
		public bool Ativo { get; set; }

		[Required(ErrorMessage = "A seleção de um Fornecedor é obrigatória.")]
		public int FornecedorId { get; set; }

		public virtual FornecedorViewModel Fornecedor { get; set; }
	}
}