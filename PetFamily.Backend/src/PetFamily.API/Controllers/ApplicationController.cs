﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PetFamily.API.Response;

namespace PetFamily.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        {
            var envelope = Envelope.Ok(value);

            return new OkObjectResult(envelope);
        }
    }
}
