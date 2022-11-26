using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace mvc
{
    public class CustomMiddleWare
    {
        private readonly RequestDelegate _next;

        public CustomMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string method = context.Request.Method;
            
            switch (method)
            {
                case "GET":
            
                    break;
                case "POST":
            
                    break;
                case "PUT":
            
                    break;
                case "DELETE":
                    break;
            }
            await _next.Invoke(context);

        }
    }
}
