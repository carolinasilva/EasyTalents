using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTalents.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository CandidateRepository { get; }
        void Commit();
        void Rollback();
    }
}
