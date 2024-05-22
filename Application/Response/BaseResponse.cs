using FluentValidation.Results;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Response
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; } = [];

        [JsonIgnore()]
        public bool Success => Errors.Count == 0;

        [JsonIgnore()]
        public bool NoContent => Data == null && Errors.Count == 0;


        public HttpStatusCode GetStatusCode()
        {
            if (NoContent)
                return HttpStatusCode.NoContent;

            if (Success)
                return HttpStatusCode.OK;

            return HttpStatusCode.UnprocessableEntity;
        }
        public BaseResponse() { }

        public BaseResponse<T> SetData(T data)
        {
            Data = data;
            return this;
        }

        public BaseResponse<T> AddErrors(List<ValidationFailure> errors)
        {
            foreach (var error in errors)
                Errors.Add(error.ErrorMessage);
            return this;
        }

        public BaseResponse<T> AddError(string error, params object?[] args)
        {
            Errors.Add(string.Format(error, args));
            return this;
        }
    }
}
