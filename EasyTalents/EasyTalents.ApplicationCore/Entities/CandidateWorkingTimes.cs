using System;
using System.Text.Json.Serialization;

namespace EasyTalents.Domain.Entities
{
    public class CandidateWorkingTimes
    {
        //public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public int WorkingTimeId { get; set; }

        [JsonIgnore]
        public Candidate Candidate { get; set; }
        public WorkingTime WorkingTime { get; set; }
    }
}
