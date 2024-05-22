using Application.Models;
using Application.Validations;
using Xunit;

namespace Management.Tasks.Tests.ApplicationTests.ValidantionsTests
{
    public class TaskCreateValidationTests
    {
        private readonly DateTime createDate;

        public TaskCreateValidationTests()
        {
            createDate = DateTime.UtcNow.Date;
        }

        [Fact]
        public void Parameters_Valid_Return_Success()
        {
            var model = new TaskCreateViewModel()
            {                
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title",
                CreateDate = createDate
            };

            TaskCreateValidation validation = new();

            var result = validation.Validate(model);

            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }        

        [Fact]
        public void Title_Invalid_Return_Invalid()
        {
            var model = new TaskCreateViewModel()
            {                
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                CreateDate = createDate
            };

            TaskCreateValidation validation = new();

            var result = validation.Validate(model);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(TaskCreateViewModel.Title));
        }

        [Fact]
        public void Description_Invalid_Return_Invalid()
        {
            var model = new TaskCreateViewModel()
            {               
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title",
                CreateDate = createDate
            };

            TaskCreateValidation validation = new();

            var result = validation.Validate(model);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(TaskCreateViewModel.Description));
        }

        [Fact]
        public void EstimatePoints_Invalid_Return_Invalid()
        {
            var model = new TaskCreateViewModel()
            {               
                Description = "Description",
                Status = "Status",
                Title = "Title",
                CreateDate = createDate
            };

            TaskCreateValidation validation = new();

            var result = validation.Validate(model);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(TaskCreateViewModel.EstimatePoints));
        }

        [Fact]
        public void CreateDate_Invalid_Return_Invalid()
        {
            var model = new TaskCreateViewModel()
            {
                Title = "Title",
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status"                
            };

            TaskCreateValidation validation = new();

            var result = validation.Validate(model);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(TaskCreateViewModel.CreateDate));
        }
    }
}
