using AutoMapper;
using LifeTracker.Business.CustomException;
using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Business.ViewModels;
using LifeTracker.Data.Entities;
using LifeTracker.Data.Repositories;
using System;
using System.Collections.Generic;

namespace LifeTracker.Business.Domain
{
    public class TagDomain : ITagDomain
    {
        private readonly ITagRepository _TagRepository;
        private readonly IMapper _mapper;


        public TagDomain(ITagRepository TagRepository, IMapper mapper)
        {
            _TagRepository = TagRepository;
            _mapper = mapper;
        }

        public void Create(TagViewModel item, Guid userId)
        {
            _TagRepository.Create(_mapper.Map<TagEntity>(item));
        }

        public void Delete(int id, Guid userId)
        {
            _TagRepository.Delete(id);
        }

        public TagViewModel Get(int id)
        {
            return _mapper.Map<TagViewModel>(_TagRepository.Get(id));
        }

        public IEnumerable<TagViewModel> GetAll(Guid userId)
        {
            return _mapper.Map<IEnumerable<TagViewModel>>(_TagRepository.GetAll(userId));
        }

        public void Update(TagViewModel item, Guid userId)
        {
            _TagRepository.Update(_mapper.Map<TagEntity>(item));
        }
    }
}
