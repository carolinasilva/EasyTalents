using EasyTalents.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EasyTalents.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public ICandidateRepository CandidateRepository { get; }

        public UnitOfWork(DbContext context)
        {
            _context = context;
            CandidateRepository = new CandidateRepository(_context);
        }

        void IUnitOfWork.Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            _context.Dispose();
        }
    }
}
