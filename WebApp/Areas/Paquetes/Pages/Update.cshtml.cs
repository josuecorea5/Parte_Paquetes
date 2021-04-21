using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Areas.Paquetes.Pages
{ 
    public class UpdateModel : PageModel
    {
        private readonly MyRepository<Paquete> _repository;
        public INotyfService _notyfService { get;}
        private readonly IAppLogger<UpdateModel> _logger;

        public UpdateModel(MyRepository<Paquete> repository, INotyfService notyfService, IAppLogger<UpdateModel> logger)
        {
            _repository = repository;
            _notyfService = notyfService;
            _logger = logger;
        }
        [BindProperty]
        public Paquete Paquete { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
            try
            {
                var paquete = await _repository.GetByIdAsync(Id);
                if(paquete == null)
                {
                    _notyfService.Warning($"El paquete, con id {Id}, no ha sido encontrado.");
                    return RedirectToPage("Index");
                }
                Paquete = paquete;
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                throw;
            }
        }
        public async Task<IActionResult> OnPost(int Id)
        {
            try
            {
                var paquete = await _repository.GetByIdAsync(Id);
                if (paquete == null)
                {
                    _notyfService.Warning($"El paquete, con id {Id}, no ha sido encontrado.");
                    return RedirectToPage("Index");
                }
                if (ModelState.IsValid)
                {
                    paquete.Nombre_Paquete = Paquete.Nombre_Paquete;
                    paquete.Tipo_Paquete = Paquete.Tipo_Paquete;
                    paquete.Fecha_Entrega = Paquete.Fecha_Entrega;
                    paquete.Peso_Paquete = Paquete.Peso_Paquete;
                    paquete.Envio_Especial = Paquete.Envio_Especial;

                    await _repository.UpdateAsync(paquete);
                    _notyfService.Information("Información actualizada con éxito");
                }
                else
                {
                    _notyfService.Warning("Datos proporcionados no válidos.");
                    return Page();
                }
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                _notyfService.Error("Ha ocrruido un error, inténtelo nuevamente");
                throw;
            }
        }
    }
}
