using Application.Extensions;
using Application.Models;
using FluentAssertions;
using Xunit;

namespace Management.Tasks.Tests.ApplicationTests.ExtensionsTests
{
    public class EntityToViewModelTests
    {
        private readonly DateTime createDate; 
        public EntityToViewModelTests()
        {
            createDate= DateTime.UtcNow;
        }

        [Fact]
        public void ParseToCreateViewModelAsExpected()
        {           
            var taskEntity  = new Domain.Entities.TaskEntity()
            {  
                Id = 0,
                CreateDate = createDate,
                Deleted = false,
                Description = "Description",
                EstimatePoints =2,
                ModifyDate = DateTime.Now,  
                Status =   "Status",
                Title = "Title"

            };

            var taskCreateViewModelExpected = new TaskCreateViewModel()
            {  
                CreateDate = createDate,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            var model = taskEntity.ParseToCreateViewModel();
            model.Should().BeEquivalentTo(taskCreateViewModelExpected);
        }


        [Fact]
        public void ParseToUpdateViewModelAsExpected()
        {
            var taskEntity = new Domain.Entities.TaskEntity()
            {
                Id = 1,
                CreateDate =createDate,
                Deleted = false,
                Description = "Description",
                EstimatePoints = 2,
                ModifyDate = DateTime.Now,
                Status = "Status",
                Title = "Title"
            };

            var taskUpdateViewModelExpected = new TaskUpdateViewModel()
            {
                Id = 1,                
                Deleted = false,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            var model = taskEntity.ParseToUpdateViewModel();
            model.Should().BeEquivalentTo(taskUpdateViewModelExpected);
        }
    }
}
