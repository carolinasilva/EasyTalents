using System;
using System.Collections.Generic;

namespace EasyTalents.Domain.Entities
{
    public class Candidate
    {
        public Candidate()
        {
            this.WorkingTimes = new HashSet<CandidateWorkingTimes>();
            this.BestTimes = new HashSet<CandidateBestTimes>();
            this.Knowledges = new HashSet<CandidateKnowledges>();
        }

        public Guid Id { get; set; }
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
        public virtual ICollection<CandidateWorkingTimes> WorkingTimes { get; set; }
        public virtual ICollection<CandidateBestTimes> BestTimes { get; set; }
        public virtual ICollection<CandidateKnowledges> Knowledges { get; set; }
    }
}
