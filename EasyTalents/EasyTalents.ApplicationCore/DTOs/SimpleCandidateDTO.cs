using System;

namespace EasyTalents.Domain.DTOs
{
    public class SimpleCandidateDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int? CrudRating { get; set; }
    }
}
