using EasyTalents.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EasyTalents.Domain.Interfaces.Services
{
    public interface ICandidateBestTimeService : IService<CandidateBestTimes>
    {
        void Update(Guid candidateId, IEnumerable<CandidateBestTimes> bestTimes);
        new void Delete(Guid candidateId);
    }
}
