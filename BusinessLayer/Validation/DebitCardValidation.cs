using FluentValidation;
using Safe_Development.BusinessLayer.DTOs;
using System.Text.RegularExpressions;

namespace Safe_Development.BusinessLayer.Validation
{
    public class DebitCardValidation : AbstractValidator<DebitCardDTO>
    {
        public DebitCardValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .Must(n => Regex.IsMatch(n, @"\A[\p{L}\s]+\Z"))
                .WithMessage("{PropertyName} must be in English")
                .WithErrorCode("NAM-001");
            RuleFor(c => c.Id)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be more than 0")
                .WithErrorCode("ID-000");
            RuleFor(c => c.Number)
                .NotNull()
                .Must(n => n.All(Char.IsDigit))
                .WithMessage("{PropertyName} must be all numbers")
                .WithErrorCode("NUM-001");
        }
    }
}
