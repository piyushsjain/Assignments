using System;
using System.Collections.Generic;
using System.Text;

namespace Nagarro.BookReading.Foundation.IFacade
{
    public interface IFacadeFactory
    {
        IFacade Create();
    }
}
