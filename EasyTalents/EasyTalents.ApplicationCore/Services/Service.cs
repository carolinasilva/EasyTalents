using EasyTalents.Domain.Interfaces.Repositories;
using EasyTalents.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace EasyTalents.Domain.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<T> _repository;

        public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        
        public void Add(T entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            var entity = _repository.GetById(id);
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public T GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> ListAll()
        {
            return _repository.ListAll();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
