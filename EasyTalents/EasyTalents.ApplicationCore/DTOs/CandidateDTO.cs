using EasyTalents.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyTalents.Domain.DTOs
{
    public class CandidateDTO
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Skype { get; set; }
        public string Phone { get; set; }
        public string Linkedin { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Portfolio { get; set; }
        public int SalaryRequirements { get; set; }
        public string ExtraKnowledges { get; set; }
        public string CrudUrl { get; set; }
        public int? CrudRating { get; set; }
        public List<WorkingTime> WorkingTimes { get; set; }
        public List<BestTime> BestTimes { get; set; }
        public List<KnowledgeDTO> Knowledges { get; set; }
    }
}
