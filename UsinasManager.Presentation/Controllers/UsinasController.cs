using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsinasManager.Application.Interfaces;
using UsinasManager.Domain.Entities;
using UsinasManager.Domain.Entities.Filtros;
using UsinasManager.Domain.Interfaces.Repositories;
using UsinasManager.Presentation.AutoMapper;
using UsinasManager.Presentation.ViewModels;
using PagedList;

namespace UsinasManager.Presentation.Controllers
{
    public class UsinasController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUsinaApplicationService _usinaApplicationService;
        private readonly IFornecedorApplicationService _fornecedorApplicationService;

        // Ninject foi usado para injeção de dependência
        public UsinasController(IUsinaApplicationService usinaApplicationService, IFornecedorApplicationService fornecedorApplicationService)
        {
            mapper = AutoMapperConfig.Mapper;
            _usinaApplicationService = usinaApplicationService;
            _fornecedorApplicationService = fornecedorApplicationService;
        }

        // Os parâmetros opcionais existem para configuração da paginação
        // GET: Usinas
        public ActionResult Index(int? page, int? size)
        {
            var usinas = _usinaApplicationService.GetAll();

            return InternalIndex(usinas, page, size);
        }

        // Action result para chamadas internas na controller
        public ActionResult InternalIndex(IEnumerable<Usina> usinas, int? page, int? size)
        {
            var usinaViewModel = mapper.Map<IEnumerable<Usina>, IEnumerable<UsinaViewModel>>(usinas);

            var pageSize = size != null ? size.Value : 10;
            var pageNumber = page != null ? page.Value : 1;

            ViewBag.FornecedorId = new SelectList(_fornecedorApplicationService.GetAll(), "FornecedorId", "Nome");

            return View("Index", usinaViewModel.ToPagedList(pageNumber, pageSize));
        }

        // GET: Usinas/Details/5
        public ActionResult Details(int id)
        {
            var usina = _usinaApplicationService.GetById(id);
            var usinaViewModel = mapper.Map<Usina, UsinaViewModel>(usina);

            return View(usinaViewModel);
        }

        // GET: Usinas/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(_fornecedorApplicationService.GetAll(), "FornecedorId", "Nome");

            return View();
        }

        // POST: Usinas/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(UsinaViewModel usinaViewModel)
        {
            if (ModelState.IsValid)
            {
                var usina = mapper.Map<UsinaViewModel, Usina>(usinaViewModel);

                if (_usinaApplicationService.VerificaCadastroDuplicado(usina))
                {
                    return View("ErroCadastroDuplicado");
                }

                _usinaApplicationService.Add(usina);

                return Index(null, null);
            }

            ViewBag.FornecedorId = new SelectList(_fornecedorApplicationService.GetAll(), "FornecedorId", "Nome");

            return RedirectToAction("Index");
        }

        // GET: Usinas/Edit/5
        public ActionResult Edit(int id)
        {
            var usina = _usinaApplicationService.GetById(id);
            var usinaViewModel = mapper.Map<Usina, UsinaViewModel>(usina);

            ViewBag.FornecedorId = new SelectList(_fornecedorApplicationService.GetAll(), "FornecedorId", "Nome", usinaViewModel.FornecedorId);

            return View(usinaViewModel);
        }

        // POST: Usinas/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(UsinaViewModel usinaViewModel)
        {
            if (ModelState.IsValid)
            {
                var usina = mapper.Map<UsinaViewModel, Usina>(usinaViewModel);

                if (_usinaApplicationService.VerificaCadastroDuplicado(usina))
				{
                    return View("ErroCadastroDuplicado");
				}

                _usinaApplicationService.Update(usina);

                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(_fornecedorApplicationService.GetAll(), "FornecedorId", "Nome", usinaViewModel.FornecedorId);

            return View(usinaViewModel);
        }

        // GET: Usinas/Delete/5
        public ActionResult Delete(int id)
        {
            var usina = _usinaApplicationService.GetById(id);
            var usinaViewModel = mapper.Map<Usina, UsinaViewModel>(usina);

            return View(usinaViewModel);
        }

        // POST: Usinas/DeleteConfirmation/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteConfirmation(int id)
        {
            var usina = _usinaApplicationService.GetById(id);
            _usinaApplicationService.Delete(usina);

            return Index(null, null);
        }

        public ActionResult FiltrarDados(FiltroUsina filtroUsina)
		{
            var usinas = _usinaApplicationService.FiltrarDados(filtroUsina);
            
            return InternalIndex(usinas, null, null);
        }
    }
}
