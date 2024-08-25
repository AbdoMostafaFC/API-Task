using System.ComponentModel.DataAnnotations;

namespace ApiDAy1.DTO
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
