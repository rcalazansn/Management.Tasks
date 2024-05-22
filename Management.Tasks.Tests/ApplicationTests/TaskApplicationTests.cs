using Application;
using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Management.Tasks.Tests.ApplicationTests
{
    public class TaskApplicationTests
    {
        private readonly TaskApplication _applicationService;
        private readonly ITaskRepository _repository;
        private readonly ILogger<TaskApplication> _iLogger;
        private readonly DateTime createDate;

        public TaskApplicationTests()
        {
            createDate = DateTime.UtcNow.Date;
            _repository = Substitute.For<ITaskRepository>();
            _iLogger = Substitute.For<ILogger<TaskApplication>>();

            _applicationService = new TaskApplication(_repository, _iLogger);
        }

        [Fact]
        public async Task New_Should_Ok()
        {
            var model = new TaskCreateViewModel
            {
                CreateDate = createDate,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            var response = _applicationService.NewAsync(model).Result;

            _repository.Received().Add(Arg.Any<TaskEntity>());

            Assert.Equal(2, response.Data.EstimatePoints);
            Assert.Equal(createDate, response.Data.CreateDate);
            Assert.Equal("Description", response.Data.Description);
            Assert.Equal("Status", response.Data.Status);
            Assert.Equal("Title", response.Data.Title);
        }

        [Fact]
        public async Task Deleted_Should_Ok()
        {
            int id = 9999;

            var entityFound = new TaskEntity
            {
                Id = id
            };

            _repository.GetById(Arg.Any<int>()).Returns(entityFound);

            var response = _applicationService.DeleteAsync(id).Result;            

            _repository.Received().GetById(Arg.Any<int>());
            _repository.Received().Remove(Arg.Any<TaskEntity>());

            Assert.Equal(9999,response.Data);  
        }

        [Fact]
        public async Task DeletedLogic_Should_Ok()
        {
            int id = 9999;

            var entityFound = new TaskEntity
            {
                Id = id
            };

            _repository.GetById(Arg.Any<int>()).Returns(entityFound);

            var response = _applicationService.DeleteLogicAsync(id).Result;

            _repository.Received().GetById(Arg.Any<int>());
            _repository.DidNotReceive().Remove(Arg.Any<TaskEntity>());
            _repository.Received().Update(Arg.Any<TaskEntity>());

            Assert.Equal(9999, response.Data);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Ok()
        {
            int id = 9999;

            var entityFound = new TaskEntity
            {
                Id = id,
                CreateDate = createDate,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            var dto = entityFound.ParseToDTO();

            _repository.GetById(Arg.Any<int>()).Returns(entityFound);

            var response = _applicationService.GetByIdAsync(id).Result;

            _repository.Received().GetById(Arg.Any<int>());

            Assert.Equal(dto.Title, response.Data.Title);
            Assert.Equal(dto.Description, response.Data.Description);
            Assert.Equal(dto.Status, response.Data.Status);
            Assert.Equal(dto.Id, response.Data.Id);
            Assert.Equal(dto.CreateDate, response.Data.CreateDate);
            Assert.Equal(dto.ModifyDate, response.Data.ModifyDate);
        }


        [Fact]
        public async Task GetAllAsync_Should_Ok()
        {
            int id = 9999;

            List<TaskEntity> list = [];

            var entity1 = new TaskEntity
            {
                Id = id,
                CreateDate = createDate,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            var entity2 = new TaskEntity
            {
                Id = id,
                CreateDate = createDate,
                Description = "Description",
                EstimatePoints = 2,
                Status = "Status",
                Title = "Title"
            };

            list.Add(entity1);
            list.Add(entity2);

            _repository.GetAll().Returns(list);
            var response = _applicationService.GetAllAsync().Result;

            _repository.DidNotReceive().GetById(Arg.Any<int>());
            _repository.Received().GetAll();

            Assert.Equal(2, response.Data.Count);          
        }
    }
}
