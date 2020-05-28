using EasyTalents.Domain.Entities;
using System;

namespace EasyTalents.Domain.Interfaces.Repositories
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        Candidate GetByIdComplete(Guid id);
    }
}
