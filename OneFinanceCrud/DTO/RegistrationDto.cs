using System.ComponentModel.DataAnnotations;

namespace OneFinanceCrud.DTO
{
    public class RegistrationDto
    {
       
            [Required]
            public string Name { get; set; }
            [DataType(DataType.EmailAddress)]
            [Required]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        
    }
}
