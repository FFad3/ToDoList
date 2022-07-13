using Application.Services.PriorityServ;
using Microsoft.AspNetCore.Mvc;
using Utils.Attribiutes;

namespace ToDoList.Controllers
{
    public class PriorityController : Controller
    {
        private readonly ILogger<PriorityController> _logger;
        private readonly IPriorityService _service;

        public PriorityController(ILogger<PriorityController> logger, IPriorityService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [LogAtr("Przeglądanie listy priorytetów")]
        public IActionResult Index()
        {
            try
            {
                var priorities = _service.GetAll();
                return View(priorities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Błąd podczas pobierania listy priorytetów");
                throw;
            }
        }
    }
}