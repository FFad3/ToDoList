using Core.Enttities;
using Infrastrucutre.Repositories.IRepositories;
using Utils.Attribiutes;

namespace Infrastrucutre.Repositories
{
    [Injectable(typeof(IPriorityRepository), DependencyInjectionScope.Scoped)]
    public class PriorityRepository : IPriorityRepository
    {
        private readonly ApplicationDbContext _context;

        public PriorityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Priority newPriority) => _context.Priorities.Add(newPriority);

        public IEnumerable<Priority> GetAll() => _context.Priorities.ToList();

        public Priority GetById(int id) => _context.Priorities.FirstOrDefault(x => x.Id == id);

        public void Remove(Priority existingPriority) => _context.Priorities.Remove(existingPriority);
    }
}