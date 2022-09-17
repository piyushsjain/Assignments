using Nagarro.BookReading.Core.Entities;
using Nagarro.BookReading.Foundation.IFacade;
using Nagarro.BookReading.Infrastructure.Data;
using Nagarro.BookReading.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Data.Facade
{
    public class Facade : Repository<Event>,IFacade
    {
        
        private readonly EventContext _eventContext;
        private readonly EventContext _commentContext;

        public Facade(EventContext eventContext) : base(eventContext)
        {
            this._eventContext = eventContext;
            this._commentContext = eventContext;
        }
        public Task<int> CreateEvent(Event _event)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Comment>> GetAllCommentByEventId(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Event>> GetEvents()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Event>> MyEvents(string organiser)
        {
            throw new NotImplementedException();
        }

        public int UpdateEvent(Event _event)
        {
            throw new NotImplementedException();
        }

        public Task<Event> ViewDetails(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
