using Application.Services.PriorityServ;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [LogAtr("Pobieranie listy piorytetów")]
        [HttpGet]
        public JsonResult GetPriorities()
        {
            try
            {
                var priorities = _service.GetAll();
                var values = new JsonResult(Ok(priorities));
                return values;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Błąd podczas pobierania listy priorytetów");
                throw;
            }
        }
    }
}