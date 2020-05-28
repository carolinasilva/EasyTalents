using EasyTalents.Domain.Entities;
using EasyTalents.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EasyTalents.Infra.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    { 
        public CandidateRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public Candidate GetByIdComplete(Guid id)
        {
            return _dbContext.Set<Candidate>()
                .Include(i => i.Knowledges).ThenInclude(it => it.Knowledge)
                .Include(i => i.WorkingTimes).ThenInclude(it => it.WorkingTime)
                .Include(i => i.BestTimes).ThenInclude(it => it.BestTime)
                .Where(w => w.Id == id).FirstOrDefault();
        }
    }
}
