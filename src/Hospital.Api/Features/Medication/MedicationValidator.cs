using FastEndpoints;
using FluentValidation;

namespace Hospital.Features;

public class MedicationValidator : Validator<MedicationRequest>
{
   public MedicationValidator()
   {
      RuleFor(p => p.Bsn)
         .InclusiveBetween(1, int.MaxValue) // add real bsn validation
         .WithMessage("Bsn is niet correct");
   }
}