using Application.Models;
using Xunit;
using Application.Extensions;
using FluentAssertions;

namespace Management.Tasks.Tests.ApplicationTests.ExtensionsTests
{
    public class ModelToEntityTests
    {
        private readonly DateTime createDate;       

        public ModelToEntityTests()
        {
            createDate = DateTime.UtcNow.Date;       
        }

        [Fact]
        public void ParseToEntityAsExpected()
        { 
            var taskCreateViewModel = new TaskCreateViewModel()
            {
                CreateDate = createDate,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            var taskEntityExpected = new Domain.Entities.TaskEntity()
            {
                Id = 0,
                CreateDate = createDate,
                Deleted = false,
                Description = "Description",
                EstimatePoints = 2,               
                Status = "Status",
                Title = "Title",
                ModifyDate = null
            };

            var entity = taskCreateViewModel.ParseToEntity();
            entity.Should().BeEquivalentTo(taskEntityExpected);
        }


        [Fact]
        public void ParseToEntityAsExpected2()
        {
            var taskUpdateViewModel = new TaskUpdateViewModel()
            {
                Id = 1,
                Deleted = false,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            var taskEntityExpected = new Domain.Entities.TaskEntity()
            {
                Id = 1,
                CreateDate = createDate,
                Deleted = false,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title",
            };

            var entity = taskUpdateViewModel.ParseToEntity();

            entity.CreateDate = createDate;
            taskEntityExpected.ModifyDate = entity.ModifyDate;

            entity.Should().BeEquivalentTo(taskEntityExpected);
        }
    }
}
