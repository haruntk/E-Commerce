using System.ComponentModel.DataAnnotations;

namespace E_Commerce.API.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid E-mail")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
