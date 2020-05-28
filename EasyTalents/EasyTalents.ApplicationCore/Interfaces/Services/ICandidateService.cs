using EasyTalents.Domain.DTOs;
using EasyTalents.Domain.Entities;
using System;

namespace EasyTalents.Domain.Interfaces.Services
{
    public interface ICandidateService : IService<Candidate>
    {
        CandidateDTO GetByIdComplete(Guid id);
        void Update(CandidateDTO candidate);

        new void Delete(Guid id);
    }
}
