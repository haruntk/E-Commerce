using System.ComponentModel.DataAnnotations;

namespace E_Commerce.API.Models.DTO
{
    public class LoginRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
