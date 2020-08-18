using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class ExceptionHandlingController : ActionFilterAttribute, IExceptionFilter
    {
      
        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {

            Exception e = filterContext.Exception;

            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult()

            {

                ViewName = "~/Views/Shared/Error.cshtml"

            };
        }
    }
}