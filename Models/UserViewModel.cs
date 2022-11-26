using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using mvc.Controllers;
using mvc.DB;
using mvc.Entities;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Models
{
    public class UserViewModel
    {
        public string Errors { get; set; }
        public string Success { get; set; }
        public string Message { get; set; }
        public UserViewModel(string errors = "", string success = "", string message = "")
        {
            this.Errors = errors;
            this.Success = success;
            this.Message = message;
        }
    }
}
