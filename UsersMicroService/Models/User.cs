using Microsoft.AspNetCore.Mvc;

namespace UsersMicroService.Models
{
    public class User
    {
        [FromForm]
        public int Id { get; set; }

        [FromForm]
        public string Email { get; set; }

        [FromForm]
        public string Password { get; set; }

        [FromForm]
        public string FullName { get; set; }

        [FromForm]
        public string UserType { get; set; }

        [FromForm]
        public bool IsActive { get; set; }

        [FromForm]
        public string ResetPasswordCode { get; set; }

        [FromForm]
        public string ActivationCode { get; set; }
    }
}
