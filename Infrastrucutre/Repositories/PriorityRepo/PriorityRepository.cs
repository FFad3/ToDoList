using Core.Enttities;
using Utils.Attribiutes;

namespace Infrastrucutre.Repositories.PriorityRepo
{
    [Injectable(typeof(IPriorityRepository), DependencyInjectionScope.Scoped)]
    public class PriorityRepository : IPriorityRepository
    {
        private readonly ApplicationDbContext _context;

        public PriorityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Priority newPriority)
        {
            _context.Priorities.Add(newPriority);
            _context.SaveChanges();
        }

        public IEnumerable<Priority> GetAll() => _context.Priorities.ToList();

        public Priority GetById(int id) => _context.Priorities.FirstOrDefault(x => x.Id == id);

        public void Remove(Priority existingPriority)
        {
            _context.Priorities.Remove(existingPriority);
            _context.SaveChanges();
        }
    }
}