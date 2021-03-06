using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsinasManager.Domain.Entities;
using UsinasManager.Presentation.ViewModels;

namespace UsinasManager.Presentation.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			CreateMap<Fornecedor, FornecedorViewModel>();
			CreateMap<Usina, UsinaViewModel>();
		}

	}
}