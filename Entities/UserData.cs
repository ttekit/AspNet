using mvc.Entities.enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvc.Entities
{
    public class UserData
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }
        public string Abbout { get; set; }

        public DateTime DateOfRegister { get; set; }

        [DefaultValue(Role.User)]
        public Role Role { get; set; }
    }
}
