using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmploymentSystem.Application.Commands;
using EmploymentSystem.Application.Common.Extensions.Helpers;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using MaxMind.GeoIP2.Exceptions;
using System.Net;
using EmploymentSystem.Infrastructure.Services;
using Microsoft.Extensions.Localization;
using EmploymentSystem.API;

namespace EmploymentSystem.Api.Controllers.LookupControllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class VaccancyController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILoggerManager _loggerManager;
        private readonly ICurrentUserService _userServices;

        #endregion
        #region Ctor
        public VaccancyController(IMediator mediator, ILoggerManager loggerManager, ICurrentUserService userServices)
        {
            _mediator = mediator;
            _loggerManager = loggerManager;
            _userServices = userServices;
        }

        #endregion

        #region Methods
        [HttpGet]
        [MapToApiVersion("1")]
        [Authorize]
        public async Task<ActionResult<List<VaccancyDto>>> GetVaccancy([FromQuery] string? searchKey)
        {
            try
            {
                var response = await _mediator.Send(new GetAllVaccancyQuery() { IsAdmin=_userServices.IsAdmin(),searchKey=searchKey});
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetJobApplications")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Employer)]
        public async Task<ActionResult<List<JobApplicationDto>>> GetJobApplications([FromQuery] Guid vacancyId)
        {
            try
            {
                var response = await _mediator.Send(new GetJobApplicationQuery() { vacancyId=vacancyId });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("CreateVaccancy")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Employer)]
        public async Task<ActionResult<VaccancyDto>> CreateVaccancy([FromBody]AddVaccancyDto objDto)
        {
            try
            {
                var response = await _mediator.Send(new AddVaccancyCommand() { obj = objDto });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("UpdateVaccancy")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Employer)]
        public async Task<ActionResult<EditVaccancyDto>> UpdateVaccancy([FromBody]EditVaccancyDto objDto)
        {
            try
            {
                var response = await _mediator.Send(new UpdateVaccancyCommand() { obj = objDto });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("GetVaccancyById")]
        [MapToApiVersion("1")]
        [Authorize]
        public async Task<ActionResult<VaccancyDto>> GetVaccancyById([FromQuery] Guid Id)
        {
            try
            {
                var response = await _mediator.Send(new GetVaccancyByIdQuery() { VaccancyId = Id });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("ApplyForVacancy")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Applicant)]
        public async Task<ActionResult<bool>> ApplyForVacancy([FromBody] Guid vacancyId)
        {
            try
            {
                var userId=_userServices.GetUserId();
                var response = await _mediator.Send(new ApplyForVacancyCommand() { UserId=userId,VaccancyId = vacancyId });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("PostVacancy")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Employer)]
        public async Task<ActionResult<bool>> PostVacancy([FromBody] Guid vacancyId)
        {
            try
            {
                var response = await _mediator.Send(new ChangeVacancyStatusCommand() { Status = Domain.Enums.VaccancyStatusEnum.Posted, VaccancyId = vacancyId });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("DeactivateVacancy")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Employer)]
        public async Task<ActionResult<bool>> DeactivateVacancy([FromBody] Guid vacancyId)
        {
            try
            {
                var response = await _mediator.Send(new ChangeVacancyStatusCommand() { Status = Domain.Enums.VaccancyStatusEnum.Deactivated, VaccancyId = vacancyId });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("DeleteVaccancy")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Employer)]
        public async Task<ActionResult<bool>> DeleteVaccancy([FromBody] Guid Id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteVaccancyCommand() { Id = Id });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

       

        #endregion
    }
}
