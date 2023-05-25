using RestaurantOrder.Service.DTOs.Responses;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestaurantOrder.Service.Responses
{
    public class ServiceResult
    {
        public ServiceResult(string message, int statusCode, bool success = false,
            ICollection<ValidationFailureDTO> errors = null)
        {
            Message = message;
            StatusCode = statusCode;
            Success = success;
            Failure = !success;
            Errors = errors;
        }

        [JsonPropertyName("message")]
        public string Message { get; protected set; }

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; protected set; }

        [JsonPropertyName("success")]
        public bool Success { get; protected set; }

        [JsonPropertyName("failure")]
        public bool Failure { get; protected set; }

        [JsonPropertyName("errors")]
        public ICollection<ValidationFailureDTO> Errors { get; protected set; }
    }

    public class ServiceResult<TEntity> : ServiceResult where TEntity : class
    {
        public ServiceResult(string message, int statusCode, bool success = false,
                                TEntity data = null, ICollection<ValidationFailureDTO> errors = null)
            : base(message, statusCode, success, errors)
        {
            Data = data;
        }

        [JsonPropertyName("data")]
        public TEntity Data { get; private set; }

    }
}
