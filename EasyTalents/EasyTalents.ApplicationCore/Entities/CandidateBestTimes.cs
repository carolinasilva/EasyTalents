using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EasyTalents.Domain.Entities
{
    public class CandidateBestTimes
    {
        //public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public int BestTimeId { get; set; }

        [JsonIgnore]
        public Candidate Candidate { get; set; }
        public BestTime BestTime { get; set; }
    }
}
