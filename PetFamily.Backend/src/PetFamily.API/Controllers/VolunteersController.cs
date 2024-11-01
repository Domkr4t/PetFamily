using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extentions;
using PetFamily.API.Response;
using PetFamily.Application.Volunteers.CreateVolunteer;
using PetFamily.Application.Volunteers.GetVolunteer;
using PetFamily.Domain.Shared;

namespace PetFamily.API.Controllers
{
    public class VolunteersController : ApplicationController
    {
        [HttpGet]
        public async Task<IActionResult> GetByPhone(
            [FromServices] GetVolunteerByEmailHandler handler,
            [FromServices] IValidator<GetVolunteerByEmailRequest> validator,
            [FromQuery] GetVolunteerByEmailRequest request,
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
            {
                var validationErrors = validationResult.Errors;

                List<ResponseError> errors = [];

                foreach (var validationError in validationErrors)
                {
                    var error = Error.Validation(validationError.ErrorCode, validationError.ErrorMessage);

                    var responseError = new ResponseError(
                        error.Code,
                        error.Message,
                        validationError.PropertyName);

                    errors.Add(responseError);
                }

                var envelope = Envelope.Error(errors);

                return BadRequest(envelope);
            }

            var volunteer = await handler.Handle(request, cancellationToken);

            if (volunteer.IsFailure)
                return volunteer.Error.ToErrorResponse();

            return Ok(volunteer);
        }



        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromServices] CreateVolunteerHandler handler,
                                                [FromServices] IValidator<CreateVolunteerRequest> validator,
                                                [FromBody] CreateVolunteerRequest request,
                                                CancellationToken cancellationToken = default)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
            {
                var validationErrors = validationResult.Errors;

                List<ResponseError> errors = [];

                foreach (var validationError in validationErrors)
                {
                    var error = Error.Validation(validationError.ErrorCode, validationError.ErrorMessage);

                    var responseError = new ResponseError(
                        error.Code,
                        error.Message,
                        validationError.PropertyName);

                    errors.Add(responseError);
                }

                var envelope = Envelope.Error(errors);

                return BadRequest(envelope);
            }

            var result = await handler.Handle(request, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToErrorResponse();

            return Ok(result.Value);
        }
    }
}
