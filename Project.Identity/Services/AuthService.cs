using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;
using Project.Application.Contracts.Identity;
using Project.Application.Models.Identity;
using Project.Application.Responses;
using Project.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Project.Identity.Services;

public class AuthService: IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ServerSettings _serverSettings;
    private readonly JwtSettings _jwtSettings;

    public AuthService(UserManager<AppUser> userManager,
                       SignInManager<AppUser> signInManager,
                       IOptions<JwtSettings> jwtSettings,
                       IOptions<ServerSettings> serverSettings
                       )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _serverSettings = serverSettings.Value;
        _jwtSettings = jwtSettings.Value;
    }
    

    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
         throw new Exception($"User with given Email({request.Email}) doesn't exist");
        }
        var res = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

        JwtSecurityToken token = await GenerateToken(user);

        var response = new LoginResponse()
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };
    
        return response;
    }


    private async Task<JwtSecurityToken> GenerateToken(AppUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        

        var Claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }.Union(userClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: Claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredential
        );

        return token;
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
            var user = new AppUser
            {
                Email = request.Email,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return null;


            var registrationResponse = new RegistrationResponse
            {
                UserId = user.Id,
                Email = user.Email
            };

            return registrationResponse;
        
        
    //     var result = new Result<RegistrationResponse>();
    //     var existingUser = await _userManager.FindByEmailAsync(request.Email);
    //     if(existingUser != null)
    //     {
    //         result.Success = false;
    //         result.Errors.Add($"User with given Email({request.Email}) already exists");
    //         return result;
    //     }

    //     var user = new AppUser{
    //         UserName = request.UserName,
    //         Email = request.Email,
    //         EmailConfirmed = false
    //     };

    //     var createResult = await _userManager.CreateAsync(user, request.Password);

    //     if(!createResult.Succeeded)
    //     {
    //         result.Success = false;
    //         foreach(var Error in createResult.Errors)
    //         {
    //             result.Errors.Add(Error.Description);
    //         }
    //         return result;
    //     }

    //     var createdUser = await _userManager.FindByNameAsync(request.UserName);
    //     await _userManager.AddToRolesAsync(createdUser, request.Roles);
        
    //     result.Success = true;
    //     result.Value = new RegistrationResponse
    //     {
    //         UserId = createdUser.Id,
    //         email = createdUser.Email
    //     };

    //     return result;
    }

    
}