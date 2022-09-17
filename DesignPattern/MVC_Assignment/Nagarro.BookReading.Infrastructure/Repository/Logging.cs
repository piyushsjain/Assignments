using Microsoft.Extensions.Logging;
using Nagarro.BookReading.Foundation.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nagarro.BookReading.Data.Repository
{
    public class Logging: ILogging
    {
        public void Show()
        {
            Console.WriteLine("Logging in the foundation component should be created as a singleton");
        }

        
    }
}
