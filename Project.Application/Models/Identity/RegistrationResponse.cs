using Project.Application.Responses;

namespace Project.Application.Models.Identity;

public class RegistrationResponse
{
    public string UserId {get; set;} = "";

    public string Email {get; set;}
}