using Core.Enttities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PriorityServ
{
    public interface IPriorityService
    {
        public IEnumerable<Priority> GetAll();

        public Priority GetById(int id);
    }
}