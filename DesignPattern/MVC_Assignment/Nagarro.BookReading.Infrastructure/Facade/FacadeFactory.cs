using Nagarro.BookReading.Foundation.IFacade;
using Nagarro.BookReading.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nagarro.BookReading.Data.Facade
{
    class FacadeFactory : IFacadeFactory
    {
        private readonly EventContext _eventC;
        public FacadeFactory(EventContext eventC)
        {
            _eventC = eventC;
        }
        public IFacade Create()
        {
            IFacade facade = new Facade(_eventC);
            return facade;
        }
    }
}
