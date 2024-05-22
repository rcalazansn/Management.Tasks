using Application.Models;
using FluentValidation;

namespace Application.Validations
{
    public class TaskUpdateValidation : AbstractValidator<TaskUpdateViewModel>
    {
        public TaskUpdateValidation()
        {
            RuleFor(model => model.Id).NotEmpty();

            RuleFor(model => model.Id).GreaterThan(0);

            RuleFor(model => model.EstimatePoints)
                .GreaterThan(0)
                .LessThanOrEqualTo(8);

            RuleFor(c => c.Description).Length(3, 500).NotEmpty().WithName("Description");
            RuleFor(c => c.Title).Length(3, 200).NotEmpty().WithName("Title");
            RuleFor(c => c.Status).Length(3, 15).NotEmpty().WithName("Status");
            RuleFor(c => c.Deleted).NotNull().WithName("Deleted");            
        }
    }
}
