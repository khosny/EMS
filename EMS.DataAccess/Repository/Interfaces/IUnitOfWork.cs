using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task<bool> SaveAsync();
    }
}
