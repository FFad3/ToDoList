using Core.Enttities;

namespace Infrastrucutre.Repositories.IRepositories
{
    public interface IPriorityRepository
    {
        public Priority GetById(int id);

        public IEnumerable<Priority> GetAll();

        public void Add(Priority newPriority);

        public void Remove(Priority existingPriority);
    }
}