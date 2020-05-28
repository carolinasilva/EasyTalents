using AutoMapper;
using EasyTalents.Domain.DTOs;
using EasyTalents.Domain.Entities;
using EasyTalents.Domain.Interfaces.Repositories;
using EasyTalents.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTalents.Domain.Services
{
    public class CandidateKnowledgeService : Service<CandidateKnowledges>, ICandidateKnowledgeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CandidateKnowledges> _repository;

        public CandidateKnowledgeService(
            IRepository<CandidateKnowledges> repository, 
            IUnitOfWork unitOfWork) 
            : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Update(Guid candidateId, IEnumerable<CandidateKnowledges> knowledges)
        {
            IEnumerable<CandidateKnowledges> knowledgesDB = _repository.ListBy(i => i.CandidateId == candidateId);

            foreach (CandidateKnowledges item in knowledgesDB)
            {
                var newItem = knowledges.FirstOrDefault(i => i.KnowledgeId == item.KnowledgeId);
                item.Rate = newItem != null ? newItem.Rate : 0;
                _repository.Update(item);
            }
        }

        public new void Delete(Guid candidateId)
        {
            IEnumerable<CandidateKnowledges> knowledgesDB = _repository.ListBy(i => i.CandidateId == candidateId);

            foreach (CandidateKnowledges item in knowledgesDB)
            {
                _repository.Delete(item);
            }
        }
    }
}
