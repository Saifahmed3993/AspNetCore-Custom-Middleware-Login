namespace LoginUsingMiddleware.CustomMiddleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.UseLoginMiddleware();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from the next middleware!");
            });

            app.Run();
        }
    }
}
