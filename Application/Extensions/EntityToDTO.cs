using Domain.DTO;

namespace Application.Extensions
{
    public static class EntityToDTO
    {
        public static TaskDTO ParseToDTO(this Domain.Entities.TaskEntity entity)
        {
            if (entity != null)
            {
                return new TaskDTO
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description,
                    Status = entity.Status,
                    EstimatePoints = entity.EstimatePoints,
                    CreateDate = entity.CreateDate
                };
            }
            return null;
        }
    }
}
