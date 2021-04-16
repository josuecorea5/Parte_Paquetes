using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Areas.Paquetes.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MyRepository<Paquete> _repository;
        private INotyfService _INotyfService { get; }
        public CreateModel(MyRepository<Paquete> repository, INotyfService iNotyfService)
        {
            _repository = repository;
            _INotyfService = iNotyfService;
        }
        [BindProperty]
        public Paquete Paquete { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.AddAsync(Paquete);
                    _INotyfService.Success("Solicitud enviada de manera exitosa");
                }
                else
                {
                    _INotyfService.Warning("Su formulario no cumple con los requisitos");
                    return Page();
                }
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                _INotyfService.Error("Ocurrió un error en el servidor, intente nuevamente");
                return RedirectToPage("Index");
            }
        }
    }
}
