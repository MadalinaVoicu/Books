using System;
using System.ComponentModel.DataAnnotations;

namespace BooksWebApi.Entities
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }

        [MaxLength(150)]
        public string FirstName { get; set; }

        [MaxLength(150)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool? Deleted { get; set; }
    }
}
