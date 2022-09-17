using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nagarro.BookReading.Foundation.OberverPattern
{
    public class Notify : INotify
    {
        HttpContext _httpContext => new HttpContextAccessor().HttpContext;
        string NameOfObserver;
        public Notify(String name)
        {
            this.NameOfObserver = name;
        }
        public void Update(int i)
        {
            _httpContext.Response.WriteAsync(string.Format("{0} has received an alert: Someone has post the comment: {1} \n", NameOfObserver, i));
        }
    }
}

