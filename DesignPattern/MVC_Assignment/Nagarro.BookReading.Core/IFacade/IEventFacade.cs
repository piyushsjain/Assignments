using Nagarro.BookReading.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Foundation.IFacade
{
    public interface IEventFacade
    {
        Task<IList<Event>> GetEvents();
        Task<Event> ViewDetails(int eventId);
        Task<int> CreateEvent(Event _event);

        int UpdateEvent(Event _event);
        Task<IList<Event>> MyEvents(string organiser);

        Task<IList<Comment>> GetAllCommentByEventId(int eventId);

    }
}
