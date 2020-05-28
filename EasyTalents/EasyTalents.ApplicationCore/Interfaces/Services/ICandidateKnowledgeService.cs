using EasyTalents.Domain.DTOs;
using EasyTalents.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EasyTalents.Domain.Interfaces.Services
{
    public interface ICandidateKnowledgeService : IService<CandidateKnowledges>
    {
        void Update(Guid candidateId, IEnumerable<CandidateKnowledges> knowledges);
        new void Delete(Guid candidateId);
    }
}
