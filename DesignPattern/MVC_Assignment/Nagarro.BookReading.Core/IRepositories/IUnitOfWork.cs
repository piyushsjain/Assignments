using Nagarro.BookReading.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nagarro.BookReading.Foundation.IRepositories
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        
    }
}
