using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;




namespace BookReadingEvent.Core.Data.Transaction
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
       
        void Rollback();
        IDbContextTransaction BeginTransaction();
        Task<int> SaveAsyc();
    }
}
