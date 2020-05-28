using EasyTalents.Domain.Entities;
using FluentValidation;

namespace EasyTalents.Domain.Validators
{
    public class CandidateValidator : AbstractValidator<Candidate>
    {
        public CandidateValidator()
        {
            RuleFor(r => r.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(r => r.Skype).NotEmpty().WithMessage("Skype is required.");
            RuleFor(r => r.Phone).NotEmpty().WithMessage("Phone is required.");
            RuleFor(r => r.City).NotEmpty().WithMessage("City is required.");
            RuleFor(r => r.State).NotEmpty().WithMessage("State is required.");
            RuleFor(r => r.SalaryRequirements).NotEmpty().WithMessage("SalaryRequirements is required.");
            RuleFor(r => r.Knowledges).NotEmpty().WithMessage("Knowledges is required.");
            RuleFor(r => r.Knowledges).Must(i => i.Count > 0).When(i => i.Knowledges != null).WithMessage("Knowledges is required.");
        }
    }
}
