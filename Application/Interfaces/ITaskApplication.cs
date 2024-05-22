using Application.Models;
using Application.Response;
using Domain.DTO;

namespace Application.Interfaces
{
    public interface ITaskApplication
    {
        Task<BaseResponse<TaskCreateViewModel>> NewAsync(TaskCreateViewModel model, CancellationToken cancellationToken = default);

        Task<BaseResponse<TaskUpdateViewModel>> UpdateAsync(TaskUpdateViewModel model);

        Task<BaseResponse<TaskDTO>> GetByIdAsync(int id);

        Task<BaseResponse<int?>> DeleteAsync(int id);

        Task<BaseResponse<int?>> DeleteLogicAsync(int id);

        Task<BaseResponse<List<TaskDTO>>> GetAllAsync();
    }
}
