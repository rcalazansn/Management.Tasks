using Application.Models;
using Application.Validations;
using Xunit;

namespace Management.Tasks.Tests.ApplicationTests.ValidantionsTests
{
    public class TaskUpdateValidationTests
    {
        [Fact]
        public void Parameters_Valid_Return_Success()
        {
            var model = new TaskUpdateViewModel()
            {
                Id = 1,
                Deleted = false,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            TaskUpdateValidation validation = new();
            
            var result = validation.Validate(model);
            
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void Id_Invalid_Return_Invalid()
        {
            var model = new TaskUpdateViewModel()
            {                
                Deleted = false,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            TaskUpdateValidation validation = new();

            var result = validation.Validate(model);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(TaskUpdateViewModel.Id));
        }

        [Fact]
        public void Title_Invalid_Return_Invalid()
        {
            var model = new TaskUpdateViewModel()
            {
                Id = 1,
                Deleted = false,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status"                
            };

            TaskUpdateValidation validation = new();

            var result = validation.Validate(model);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(TaskUpdateViewModel.Title));
        }

        [Fact]
        public void Description_Invalid_Return_Invalid()
        {
            var model = new TaskUpdateViewModel()
            {
                Id = 1,
                Deleted = false,               
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            TaskUpdateValidation validation = new();

            var result = validation.Validate(model);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(TaskUpdateViewModel.Description));
        }

        [Fact]
        public void EstimatePoints_Invalid_Return_Invalid()
        {
            var model = new TaskUpdateViewModel()
            {
                Id = 1,
                Deleted = false,
                Description = "Description",              
                Status = "Status",
                Title = "Title"
            };

            TaskUpdateValidation validation = new();

            var result = validation.Validate(model);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(TaskUpdateViewModel.EstimatePoints));
        }        
    }
}
