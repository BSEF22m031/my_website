namespace web_lab_06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add session services
            builder.Services.AddDistributedMemoryCache(); // You can use other cache providers (like Redis) if needed
            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true; // Prevents client-side access to the session cookie
                options.Cookie.IsEssential = true; // Ensures the session is always available
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout (optional)
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Enable session middleware
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
