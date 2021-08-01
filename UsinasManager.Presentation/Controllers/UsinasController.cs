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

namespace UsinasManager.Presentation.Controllers
{
    public class UsinasController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUsinaApplicationService _usinaApplicationService;

        public UsinasController(IUsinaApplicationService usinaApplicationService)
        {
            mapper = AutoMapperConfig.Mapper;
            _usinaApplicationService = usinaApplicationService;
        }

        // GET: Usinas
        public ActionResult Index()
        {
            var usinas = _usinaApplicationService.GetAll();
            var usinaViewModel = mapper.Map<IEnumerable<Usina>, IEnumerable<UsinaViewModel>>(usinas);
            return View(usinaViewModel);
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
                _usinaApplicationService.Add(usina);

                return Index();
            }

            return View(usinaViewModel);
        }

        // GET: Usinas/Edit/5
        public ActionResult Edit(int id)
        {
            var usina = _usinaApplicationService.GetById(id);
            var usinaViewModel = mapper.Map<Usina, UsinaViewModel>(usina);

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
                _usinaApplicationService.Update(usina);

                return Index();
            }

            return View(usinaViewModel);
        }

        // GET: Usinas/Delete/5
        public ActionResult Delete(int id)
        {
            var usina = _usinaApplicationService.GetById(id);
            var usinaViewModel = mapper.Map<Usina, UsinaViewModel>(usina);

            return View(usinaViewModel);
        }

        // POST: Usinas/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(UsinaViewModel usinaViewModel)
        {
            if (ModelState.IsValid)
            {
                var usina = mapper.Map<UsinaViewModel, Usina>(usinaViewModel);
                _usinaApplicationService.Delete(usina);

                return Index();
            }

            return View(usinaViewModel);
        }

        public ActionResult FiltrarDados(FiltroUsina filtroUsina)
		{
            var usinas = _usinaApplicationService.FiltrarDados(filtroUsina);
            var usinaViewModel = mapper.Map<IEnumerable<Usina>, IEnumerable<UsinaViewModel>>(usinas);
            return View(usinaViewModel);
        }
    }
}
