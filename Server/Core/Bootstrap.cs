using Catel.IoC;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Bootstrap
    {
        public static void Start()
        {
            IoC.AutoRegisterRepositories();
            ServiceLocator.Default.RegisterType<IBugzbgoneUoW, BugzbgoneUoW>();
        }

    }
}
