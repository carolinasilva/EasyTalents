using EasyTalents.Domain.Entities;
using EasyTalents.Domain.Interfaces.Repositories;
using EasyTalents.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTalents.Domain.Services
{
    public class CandidateBestTimeService : Service<CandidateBestTimes>, ICandidateBestTimeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CandidateBestTimes> _repository;

        public CandidateBestTimeService(
            IRepository<CandidateBestTimes> repository,
            IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Update(Guid candidateId, IEnumerable<CandidateBestTimes> bestTimes)
        {
            IEnumerable<CandidateBestTimes> bestTimesDB = _repository.ListBy(i => i.CandidateId == candidateId);

            foreach (CandidateBestTimes item in bestTimesDB)
            {
                if (!bestTimes.Any(i => i.BestTimeId == item.BestTimeId))
                    _repository.Delete(item);
            }

            foreach (CandidateBestTimes item in bestTimes)
            {
                if (!bestTimesDB.Any(i => i.BestTimeId == item.BestTimeId))
                {
                    item.CandidateId = candidateId;
                    _repository.Add(item);
                }
            }
        }

        public new void Delete(Guid candidateId)
        {
            IEnumerable<CandidateBestTimes> bestTimesDB = _repository.ListBy(i => i.CandidateId == candidateId);

            foreach (CandidateBestTimes item in bestTimesDB)
            {
                _repository.Delete(item);
            }
        }
    }
}
