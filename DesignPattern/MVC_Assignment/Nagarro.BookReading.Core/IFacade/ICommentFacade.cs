using Nagarro.BookReading.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Foundation.IFacade
{
  public   interface ICommentFacade
    {
        Task<int> PostComment(Comment response);

        Task<IList<Comment>> GetComments();

        Task<Comment> ViewComment(int commentId);

        int EditComment(Comment response);
    }
}
