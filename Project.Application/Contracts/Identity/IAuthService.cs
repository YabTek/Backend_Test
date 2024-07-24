using Project.Application.Models.Identity;
using Project.Application.Responses;

namespace Project.Application.Contracts.Identity;

public interface IAuthService
{
    public Task<RegistrationResponse> Register(RegistrationRequest request);

    public Task<LoginResponse> Login(LoginRequest request);


}