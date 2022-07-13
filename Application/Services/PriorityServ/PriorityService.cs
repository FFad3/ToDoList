using Core.Enttities;
using Infrastrucutre.Repositories.PriorityRepo;
using Microsoft.Extensions.Logging;
using Utils.Attribiutes;

namespace Application.Services.PriorityServ
{
    [Injectable(typeof(IPriorityService), DependencyInjectionScope.Scoped)]
    public class PriorityService : IPriorityService
    {
        private readonly IPriorityRepository _repo;
        private readonly ILogger<PriorityService> _logger;

        public PriorityService(IPriorityRepository repo, ILogger<PriorityService> logger)
        {
            _repo = repo;
            this._logger = logger;
        }

        public IEnumerable<Priority> GetAll()
        {
            var priorities = _repo.GetAll();
            _logger.LogDebug($"Pobrano {priorities.Count()} priorytetów");

            return priorities;
        }

        public Priority GetById(int id)
        {
            var priority = _repo.GetById(id);
            _logger.LogDebug($"Pobrano Id={priority.Id} Level={priority.PriorytyLevel}");
            return priority;
        }
    }
}