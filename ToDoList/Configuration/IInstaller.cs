using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Configuration
{
    public interface IInstaller
    {
        public void Install(WebApplicationBuilder builder);
    }
}