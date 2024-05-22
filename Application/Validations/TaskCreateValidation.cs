using Application.Models;
using FluentValidation;

namespace Application.Validations
{
    public class TaskCreateValidation : AbstractValidator<TaskCreateViewModel>
    {
        public TaskCreateValidation()
        {
            RuleFor(model => model.EstimatePoints)
                .GreaterThan(0)
                .LessThanOrEqualTo(8);

            RuleFor(c => c.Description).Length(3, 500).NotEmpty().WithName("Description");
            RuleFor(c => c.Title).Length(3, 200).NotEmpty().WithName("Title");
            RuleFor(c => c.Status).Length(3, 15).NotEmpty().WithName("Status");
          
            RuleFor(task => task.CreateDate)
              .NotEmpty();

            When(task => task.CreateDate != null, () =>
            {
                RuleFor(task => task.CreateDate)
                .GreaterThanOrEqualTo(DateTime.Now.Date);

                RuleFor(task => task.CreateDate)
                .GreaterThan(DateTime.MinValue);

                RuleFor(task => task.CreateDate)
                .LessThan(DateTime.MaxValue);
            });
        }
    }
}
