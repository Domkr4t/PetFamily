using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Response;
using PetFamily.Domain.Shared;

namespace PetFamily.API.Extentions
{
    public static class ResponseExtentions
    {
        public static ActionResult ToErrorResponse(this Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Failure => StatusCodes.Status500InternalServerError,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError,
            };

            var responseError = new ResponseError(error.Code, error.Message, null);

            var envelope = Envelope.Error([responseError]);

            return new ObjectResult(envelope)
            {
                StatusCode = statusCode
            };
        }
    }
}
