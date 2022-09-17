using System;
using System.Collections.Generic;
using System.Text;

namespace Nagarro.BookReading.Business.CustomException
{
    public class NotMappedException: Exception

    {
        public NotMappedException(): base()
        {

        }
        public NotMappedException(string message): base(message)
        {

        }
    }
}
