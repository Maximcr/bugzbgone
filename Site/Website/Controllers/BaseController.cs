using Catel.IoC;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public abstract class BaseController : Controller
    {
        //
        // GET: /Base/
        protected internal IBugzbgoneUoW _uow;
        public BaseController()
        {
            _uow = ServiceLocator.Default.ResolveType<IBugzbgoneUoW>();
        }
        public BaseController(IBugzbgoneUoW uow)
        {
            _uow = uow;
        }
     

    }
}
