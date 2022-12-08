using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using mvc.DB;
using mvc.Models;
using System.Collections.Generic;

namespace mvc.Entities
{
    public class PostUpdateComplexType
    {
        public string Name { get; set; }
        public string Context { get; set; }
        public string Id { get; set; }
        public IFormFile Logo { get; set; }
    }
}
