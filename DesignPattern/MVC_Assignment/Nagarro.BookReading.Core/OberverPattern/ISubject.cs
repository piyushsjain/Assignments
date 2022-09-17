using Nagarro.BookReading.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nagarro.BookReading.Foundation.OberverPattern
{
    public interface ISubject
    {
        void Post(INotify comment);
      
        void NotifyUsers(int i);
    }
}
