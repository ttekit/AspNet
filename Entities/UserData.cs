using mvc.Entities.enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Entities
{
    public class UserData
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Abbout { get; set; }

        [DefaultValue(Role.User)]
        public Role Role { get; set; }
        public DateTime DateOfRegister { get; set; }

    }
}
