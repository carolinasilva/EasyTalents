using System;
using System.Text.Json.Serialization;

namespace EasyTalents.Domain.Entities
{
    public class CandidateKnowledges
    {
        //public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public int KnowledgeId { get; set; }
        public int Rate { get; set; }

        [JsonIgnore]
        public Candidate Candidate { get; set; }
        public Knowledge Knowledge { get; set; }
    }
}
