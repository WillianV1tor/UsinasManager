using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsinasManager.Presentation.ViewModels
{
	public class FornecedorViewModel
	{
		[Key]
		public int FornecedorId { get; set; }

		[Required(ErrorMessage = "O campo Nome possui preenchimento obrigatório.")]
		public string Nome { get; set; }

		public virtual IEnumerable<UsinaViewModel> Usinas { get; set; }
	}
}