using Application.Extensions;
using Application.Interfaces;
using Application.Models;
using Application.Response;
using Application.Validations;
using Domain.DTO;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Application
{
    public class TaskApplication : ITaskApplication
    {
        private readonly ITaskRepository _repository;
        private readonly ILogger<TaskApplication> _logger;

        public TaskApplication(ITaskRepository repository,
             ILogger<TaskApplication> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        public async Task<BaseResponse<TaskCreateViewModel>> NewAsync(TaskCreateViewModel model, CancellationToken cancellationToken = default)
        {
            BaseResponse<TaskCreateViewModel> response = new();

            try
            {
                var task = model.ParseToEntity();
                var validationResult = new TaskCreateValidation().Validate(model);

                if (!validationResult.IsValid)
                    return response.AddErrors(validationResult.Errors);

                _repository.Add(task);

                return response.SetData(task.ParseToCreateViewModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao inserir Tarefa Erro");
                return response.AddError("Falha ao inserir Tarefa Erro Create");
            }
        }

        public async Task<BaseResponse<TaskUpdateViewModel>> UpdateAsync(TaskUpdateViewModel model)
        {
            BaseResponse<TaskUpdateViewModel> response = new();
            try
            {
                var update = model.ParseToEntity();

                var task = _repository.GetById(model.Id);

                if (task != null)
                {
                    update.CreateDate = task.CreateDate;
                }

                var validationResult = new TaskUpdateValidation().Validate(model);
                if (!validationResult.IsValid)
                    return response.AddErrors(validationResult.Errors);

                _repository.Update(update);
                return response.SetData(update.ParseToUpdateViewModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao atualizar Tarefa Erro");
                return response.AddError("Falha ao atualizar Tarefa Erro UPDATE");
            }
        }

        public async Task<BaseResponse<TaskDTO>> GetByIdAsync(int id)
        {
            BaseResponse<TaskDTO> response = new();
            try
            {
                var task = _repository.GetById(id);
                return response.SetData(task.ParseToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao obter Tarefa Erro");
                return response.AddError("Falha ao obter Tarefa Erro ObterPorId");
            }
        }

        public async Task<BaseResponse<int?>> DeleteAsync(int id)
        {
            BaseResponse<int?> response = new();
            try
            {
                var task = _repository.GetById(id);
                if (task == null)
                    return response.AddError(string.Format("Não encontrada", "Task", id));

                _repository.Remove(task);
                return response.SetData(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao deletar Tarefa Erro");
                return response.AddError("Falha ao deletar Tarefa Erro DELETE");
            }
        }

        public async Task<BaseResponse<List<TaskDTO>>> GetAllAsync()
        {
            BaseResponse<List<TaskDTO>> response = new();
            try
            {
                var tasks = _repository.GetAll();
                return response.SetData(tasks.Select(s => s.ParseToDTO()).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao obter lista de Tarefa Erro");
                return response.AddError("Falha ao obter Tarefa Erro ObterLista");
            }
        }

        public async Task<BaseResponse<int?>> DeleteLogicAsync(int id)
        {
            BaseResponse<int?> response = new();
            try
            {
                var task = _repository.GetById(id);
                if (task == null)
                    return response.AddError(string.Format("Não encontrada", "Task", id));

                task.Deleted = true;

                _repository.Update(task);
                return response.SetData(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao deletar Tarefa Erro");
                return response.AddError("Falha ao deletar Tarefa Erro DELETE");
            }
        }
    }
}

