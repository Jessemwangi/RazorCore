using Microsoft.Data.SqlClient;

namespace RazorCore.Pages
{
    public class TestSqlConnectionMiddleWare
    {
        private readonly RequestDelegate _next;

        public TestSqlConnectionMiddleWare(RequestDelegate next)
        {
            _next = next;

        }
        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {

            if (context.Request.Path.Equals("/testsql"))
            {
                var ConnectionString = configuration["ConnectionStrings:DbConnection"];

                using (var connection = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        using (var command = new SqlCommand("SELECT 1", connection))
                        {
                            var result = await command.ExecuteScalarAsync();
                            if ((int)result == 1)
                            {
                                await context.Response.WriteAsync("Database connection successful!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        await context.Response.WriteAsync($"Error connecting to database: {ex.Message}");
                    }
                }
            }
            else
            {
                await _next(context);
            }

        }
    }
}

