using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models
{
    public class UserModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

    }
}
