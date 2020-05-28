using AutoMapper;
using EasyTalents.Domain.DTOs;
using EasyTalents.Domain.Entities;
using EasyTalents.Domain.Interfaces.Repositories;
using EasyTalents.Domain.Interfaces.Services;
using System;

namespace EasyTalents.Domain.Services
{
    public class CandidateService : Service<Candidate>, ICandidateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Candidate> _repository;
        private readonly IMapper _mapper;
        private readonly ICandidateWorkingTimeService _candidateWorkingTimeService;
        private readonly ICandidateKnowledgeService _candidateKnowledgeService;
        private readonly ICandidateBestTimeService _candidateBestTimeService;

        public CandidateService(
            IRepository<Candidate> repository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            ICandidateKnowledgeService candidateKnowledgeService,
            ICandidateWorkingTimeService candidateWorkingTimeService,
            ICandidateBestTimeService candidateBestTimeService) 
            : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _candidateKnowledgeService = candidateKnowledgeService;
            _candidateBestTimeService = candidateBestTimeService;
            _candidateWorkingTimeService = candidateWorkingTimeService;
        }

        public new void Delete(Guid id)
        {
            Candidate candidate = _unitOfWork.CandidateRepository.GetById(id);

            _candidateKnowledgeService.Delete(id);
            _candidateBestTimeService.Delete(id);
            _candidateWorkingTimeService.Delete(id);

            _repository.Delete(candidate);

            _unitOfWork.Commit();
        }

        public CandidateDTO GetByIdComplete(Guid id)
        {
            Candidate candidate = _unitOfWork.CandidateRepository.GetByIdComplete(id);
            return _mapper.Map<CandidateDTO>(candidate);
        }

        public void Update(CandidateDTO candidate)
        {
            Candidate candidateDB = _mapper.Map<Candidate>(candidate);         

            _unitOfWork.CandidateRepository.Update(candidateDB);

            _candidateKnowledgeService.Update(candidateDB.Id, candidateDB.Knowledges);
            _candidateBestTimeService.Update(candidateDB.Id, candidateDB.BestTimes);
            _candidateWorkingTimeService.Update(candidateDB.Id, candidateDB.WorkingTimes);

            _unitOfWork.Commit();
        }


    }
}
