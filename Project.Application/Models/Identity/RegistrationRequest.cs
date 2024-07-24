using System.ComponentModel.DataAnnotations;

namespace Project.Application.Models.Identity;

public class RegistrationRequest
{
    [Required]
    [EmailAddress]
    public string Email {get; set;} = "";

    [Required]
    public string UserName {get; set;} = "";

    [Required]
    public string Password{get; set;} = "";

}