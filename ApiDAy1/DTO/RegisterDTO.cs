using System.ComponentModel.DataAnnotations;

namespace ApiDAy1.DTO
{
    public class RegisterDTO
    {


        public string username { get; set; }
          [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

    }
}
