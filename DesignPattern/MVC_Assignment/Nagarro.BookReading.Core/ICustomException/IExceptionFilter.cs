using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Nagarro.BookReading.Foundation.ICustomException
{
    public interface IExceptionFilter
    {
        void OnException(ExceptionContext filterContext);
    }
}
