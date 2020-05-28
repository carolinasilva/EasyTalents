using AutoMapper;
using EasyTalents.Domain.DTOs;
using EasyTalents.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyTalents.Domain.Mapping
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<KnowledgeDTO, CandidateKnowledges>()
                .ForMember(dest => dest.KnowledgeId, org => org.MapFrom(rr => rr.Id))
                .ForMember(dest => dest.Rate, org => org.MapFrom(rr => rr.Rate))
                .ForMember(dest => dest.CandidateId, org => org.Ignore())
                .ForMember(dest => dest.Candidate, org => org.Ignore())
                .ForMember(dest => dest.Knowledge, org => org.Ignore());

            CreateMap<CandidateKnowledges, KnowledgeDTO>()
                .ForMember(dest => dest.Id, org => org.MapFrom(rr => rr.KnowledgeId))
                .ForMember(dest => dest.Description, org => org.MapFrom(rr => rr.Knowledge.Description))
                .ForMember(dest => dest.Rate, org => org.MapFrom(rr => rr.Rate));

            CreateMap<WorkingTime, CandidateWorkingTimes>()
                    .ForMember(dest => dest.WorkingTimeId, org => org.MapFrom(rr => rr.Id))
                    .ForMember(dest => dest.CandidateId, org => org.Ignore())
                    .ForMember(dest => dest.Candidate, org => org.Ignore())
                    .ForMember(dest => dest.WorkingTime, org => org.Ignore());

            CreateMap<CandidateWorkingTimes, WorkingTime>()
                .ForMember(dest => dest.Id, org => org.MapFrom(rr => rr.WorkingTimeId))
                .ForMember(dest => dest.Description, org => org.MapFrom(rr => rr.WorkingTime.Description));

            CreateMap<BestTime, CandidateBestTimes>()
                    .ForMember(dest => dest.BestTimeId, org => org.MapFrom(rr => rr.Id))                    
                    .ForMember(dest => dest.Candidate, org => org.Ignore())
                    .ForMember(dest => dest.BestTime, org => org.Ignore());

            CreateMap<CandidateBestTimes, BestTime>()
                .ForMember(dest => dest.Id, org => org.MapFrom(rr => rr.BestTimeId))
                .ForMember(dest => dest.Description, org => org.MapFrom(rr => rr.BestTime.Description));

            CreateMap<CandidateDTO, Candidate>()
                .ReverseMap();

            CreateMap<Candidate, SimpleCandidateDTO>()
                .ReverseMap();
        }
    }
}
