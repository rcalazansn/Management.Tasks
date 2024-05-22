using Application.Extensions;
using Domain.DTO;
using FluentAssertions;
using Xunit;

namespace Management.Tasks.Tests.ApplicationTests.ExtensionsTests
{
    public class EntityToDTOTests
    {
        private readonly DateTime createDate;
        public EntityToDTOTests()
        {
            createDate = DateTime.UtcNow;
        }

        [Fact]
        public void ParseToDTOAsExpected()
        {
            var taskEntity = new Domain.Entities.TaskEntity()
            {
                Id = 0,
                CreateDate = createDate,
                Deleted = false,
                Description = "Description",
                EstimatePoints = 2,
                ModifyDate = DateTime.Now,
                Status = "Status",
                Title = "Title"

            };

            var taskDTO = new TaskDTO()
            {
                CreateDate = createDate,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            var model = taskEntity.ParseToDTO();
            model.Should().BeEquivalentTo(taskDTO);
        }   
    }
}
