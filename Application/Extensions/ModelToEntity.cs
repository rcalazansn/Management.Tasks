using Application.Models;
using Domain.Entities;

namespace Application.Extensions
{
    public static class ModelToEntity
    {
        public static TaskEntity ParseToEntity(this TaskCreateViewModel createViewModel)
        {
            return new TaskEntity
            {
                Title = createViewModel.Title,
                Description = createViewModel.Description,
                Status = createViewModel.Status,
                EstimatePoints = createViewModel.EstimatePoints,
                CreateDate = createViewModel.CreateDate
            };             
        }
        
        public static TaskEntity ParseToEntity(this TaskUpdateViewModel updateViewModel)
        {
            return new TaskEntity
            {
                Id = updateViewModel.Id,
                Title = updateViewModel.Title,
                Description = updateViewModel.Description,
                Status = updateViewModel.Status,
                EstimatePoints = updateViewModel.EstimatePoints,               
                Deleted = updateViewModel.Deleted,
                ModifyDate = DateTime.UtcNow             
            };
        }        
    }
}
