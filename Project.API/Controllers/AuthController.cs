using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using Project.Application.Contracts.Identity;
using Project.Application.Models.Identity;
using Project.Application.Features.Users_.DTOs;

namespace Project.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseApiController
{
    private readonly IAuthService _authService;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthController(IAuthService authService, IMediator mediator, IMapper mapper)
    {
        _authService = authService;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
       var loginResponse = await _authService.Login(request);

            if (loginResponse == null)
                return Unauthorized();

            return Ok(loginResponse);
        
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegisterDto registerDto)
    {
       if (!ModelState.IsValid)
                return BadRequest(ModelState);

        var registrationRequest = _mapper.Map<RegistrationRequest>(registerDto);
        var registrationResponse = await _authService.Register(registrationRequest);

        if (registrationResponse == null)
            return BadRequest();

        var responseDto = _mapper.Map<RegistrationResponse>(registrationResponse);

        return Created("", responseDto);
    }
        


}