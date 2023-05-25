using RestaurantOrder.Service.DTOs.Responses;
using System.Collections.Generic;
using System.Net;

namespace RestaurantOrder.Service.Responses
{
    public static class ServiceResultFactory
    {
        public static ServiceResult Ok(string message)
        {
            return new ServiceResult(
                message,
                (int)HttpStatusCode.OK,
                success: true
            );
        }

        public static ServiceResult Created(string message)
        {
            return new ServiceResult(
                message,
                (int)HttpStatusCode.Created,
                success: true
            );
        }

        public static ServiceResult NoContent()
        {
            return new ServiceResult(null, (int)HttpStatusCode.NoContent, true);
        }

        public static ServiceResult NoContent(string message)
        {
            return new ServiceResult(message, (int)HttpStatusCode.NoContent, true);
        }

        public static ServiceResult BadRequest(string message)
        {
            return new ServiceResult(
                message,
                (int)HttpStatusCode.BadRequest,
                errors: new List<ValidationFailureDTO>()
            );
        }

        public static ServiceResult BadRequest(ICollection<ValidationFailureDTO>  validationErrors, string message)
        {
            return new ServiceResult(
                message,
                (int)HttpStatusCode.BadRequest,
                errors: validationErrors
            );
        }

        public static ServiceResult BadRequest(ValidationFailureDTO validationFailureDTO, string message)
        {
            return new ServiceResult(
                message,
                (int)HttpStatusCode.BadRequest,
                errors: new List<ValidationFailureDTO>() { validationFailureDTO }
            );
        }

        public static ServiceResult NotFound(string message)
        {
            return new ServiceResult(message, (int)HttpStatusCode.NotFound);
        }

        public static ServiceResult Forbidden(string message)
        {
            return new ServiceResult(message, (int)HttpStatusCode.Forbidden);
        }

        public static ServiceResult InternalServerError(string message)
        {
            return new ServiceResult(message, (int)HttpStatusCode.InternalServerError);
        }

    }

    /// <summary>
    /// Factory for the result service with response datas - ResponseFactory
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public static class ServiceResultFactory<T> where T : class
    {
        public static ServiceResult<T> Ok(T data)
        {
            return new ServiceResult<T>(
                message: null,
                (int)HttpStatusCode.OK,
                success: true,
                data
            );
        }

        public static ServiceResult<T> Ok(T data, string message)
        {
            return new ServiceResult<T>(
                message,
                (int)HttpStatusCode.OK,
                success: true,
                data
            );
        }

        public static ServiceResult<T> Created(T data, string message)
        {
            return new ServiceResult<T>(
                message,
                (int)HttpStatusCode.Created,
                success: true,
                data
            );
        }

        public static ServiceResult<T> NoContent()
        {
            return new ServiceResult<T>(null, (int)HttpStatusCode.NoContent, true);
        }

        public static ServiceResult<T> NoContent(string message)
        {
            return new ServiceResult<T>(message, (int)HttpStatusCode.NoContent, true);
        }

        public static ServiceResult<T> BadRequest(string message)
        {
            return new ServiceResult<T>(
                message,
                (int)HttpStatusCode.BadRequest,
                errors: new List<ValidationFailureDTO>()
            );
        }

        public static ServiceResult<T> BadRequest(ICollection<ValidationFailureDTO> validationFailureDTOs, string message)
        {
            return new ServiceResult<T>(
                message,
                (int)HttpStatusCode.BadRequest,
                errors: validationFailureDTOs
            );
        }

        public static ServiceResult<T> BadRequest(ValidationFailureDTO validationFailureDTO, string message)
        {
            return new ServiceResult<T>(
                message,
                (int)HttpStatusCode.BadRequest,
                errors: new List<ValidationFailureDTO>() { validationFailureDTO }
            );
        }

        public static ServiceResult<T> NotFound(string message)
        {
            return new ServiceResult<T>(message, (int)HttpStatusCode.NotFound);
        }

        public static ServiceResult<T> Forbidden(string message)
        {
            return new ServiceResult<T>(message, (int)HttpStatusCode.Forbidden);
        }

        public static ServiceResult<T> InternalServerError(string message)
        {
            return new ServiceResult<T>(message, (int)HttpStatusCode.InternalServerError);
        }

    }
}
