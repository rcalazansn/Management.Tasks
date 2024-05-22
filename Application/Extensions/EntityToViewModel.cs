using Application.Models;

namespace Application.Extensions
{
    public static class EntityToViewModel
    {
        public static TaskCreateViewModel ParseToCreateViewModel(this Domain.Entities.TaskEntity entity)
        {
            if (entity != null)
            {
                return new TaskCreateViewModel
                {
                    Title = entity.Title,
                    Description = entity.Description,
                    Status = entity.Status,
                    EstimatePoints = entity.EstimatePoints,
                    CreateDate = entity.CreateDate
                };
            }
            return null;
        }  

        public static TaskUpdateViewModel ParseToUpdateViewModel(this Domain.Entities.TaskEntity entity)
        {
            if (entity != null)
            {
                return new TaskUpdateViewModel
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description,
                    Status = entity.Status,
                    EstimatePoints = entity.EstimatePoints,
                    Deleted = entity.Deleted
                };
            }

            return null;
        }
    }
}
