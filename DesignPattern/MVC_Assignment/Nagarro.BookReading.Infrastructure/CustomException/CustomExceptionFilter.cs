using Nagarro.BookReading.Foundation.ICustomException;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Nagarro.BookReading.Data.CustomException
{
    public class CustomExceptionFilter : FilterAttribute, System.Web.Mvc.IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is NullReferenceException)
            {
                filterContext.Result = new RedirectResult("customErrorPage.html");
                filterContext.ExceptionHandled = true;
            }
        }

    }
}
