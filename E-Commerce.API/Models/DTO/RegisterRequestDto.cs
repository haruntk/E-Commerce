using System.ComponentModel.DataAnnotations;

namespace E_Commerce.API.Models.DTO
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
