using Microsoft.Extensions.Primitives;

namespace LoginUsingMiddleware.CustomMiddleware
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            // Handle only POST requests to "/"
            if (ctx.Request.Path == "/" &&
                ctx.Request.Method == "POST")
            {
                // Read request body
                StreamReader reader = new StreamReader(ctx.Request.Body);
                string body = await reader.ReadToEndAsync();

                // Convert request body into Dictionary
                Dictionary<string, StringValues> queryDict =
                    Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

                string? email = null;
                string? password = null;

                // Read email
                if (queryDict.ContainsKey("email"))
                {
                    email = Convert.ToString(queryDict["email"][0]);
                }
                else
                {
                    ctx.Response.StatusCode = 400;
                    await ctx.Response.WriteAsync("Email is required\n");
                }

                // Read password
                if (queryDict.ContainsKey("password"))
                {
                    password = Convert.ToString(queryDict["password"][0]);
                }
                else
                {
                    if (ctx.Response.StatusCode == 200)
                        ctx.Response.StatusCode = 400;

                    await ctx.Response.WriteAsync("Password is required\n");
                }

                // If both values exist
                if (!string.IsNullOrEmpty(email) &&
                    !string.IsNullOrEmpty(password))
                {
                    string validEmail = "saif@saif.com";
                    string validPassword = "admin123";

                    bool isValidLogin =
                        email == validEmail &&
                        password == validPassword;

                    if (isValidLogin)
                    {
                        ctx.Response.StatusCode = 200;
                        await ctx.Response.WriteAsync("Login Successfully");
                    }
                    else
                    {
                        ctx.Response.StatusCode = 400;
                        await ctx.Response.WriteAsync("Invalid Email or Password");
                    }
                }

                return;
            }

            // Continue to the next middleware
            await _next(ctx);
        }
    }

    // Extension Method
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}