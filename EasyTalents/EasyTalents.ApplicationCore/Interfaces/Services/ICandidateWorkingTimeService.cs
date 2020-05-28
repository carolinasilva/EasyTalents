using EasyTalents.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EasyTalents.Domain.Interfaces.Services
{
    public interface ICandidateWorkingTimeService : IService<CandidateWorkingTimes>
    {
        void Update(Guid candidateId, IEnumerable<CandidateWorkingTimes> workingTimes);
        new void Delete(Guid candidateId);
    }
}
