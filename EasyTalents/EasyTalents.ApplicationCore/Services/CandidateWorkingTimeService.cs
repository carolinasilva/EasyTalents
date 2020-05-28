using EasyTalents.Domain.Entities;
using EasyTalents.Domain.Interfaces.Repositories;
using EasyTalents.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTalents.Domain.Services
{
    public class CandidateWorkingTimeService : Service<CandidateWorkingTimes>, ICandidateWorkingTimeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CandidateWorkingTimes> _repository;

        public CandidateWorkingTimeService(
            IRepository<CandidateWorkingTimes> repository, 
            IUnitOfWork unitOfWork) 
            : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Update(Guid candidateId, IEnumerable<CandidateWorkingTimes> workingTimes)
        {
            IEnumerable<CandidateWorkingTimes> workingTimesDB = _repository.ListBy(i => i.CandidateId == candidateId);

            foreach (CandidateWorkingTimes item in workingTimesDB)
            {
                if (!workingTimes.Any(i => i.WorkingTimeId == item.WorkingTimeId))
                    _repository.Delete(item);
            }

            foreach (CandidateWorkingTimes item in workingTimes)
            {
                if (!workingTimesDB.Any(i => i.WorkingTimeId == item.WorkingTimeId))
                {
                    item.CandidateId = candidateId;
                    _repository.Add(item);
                }
            }
        }

        public new void Delete(Guid candidateId)
        {
            IEnumerable<CandidateWorkingTimes> workingTimesDB = _repository.ListBy(i => i.CandidateId == candidateId);

            foreach (CandidateWorkingTimes item in workingTimesDB)
            {
                _repository.Delete(item);
            }
        }
    }
}
