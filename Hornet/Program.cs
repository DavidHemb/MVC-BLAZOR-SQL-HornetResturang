using Hornet.Areas.Identity;
using DataAccess.Data;
using DataAccess.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Business.Repository;
using Business.Repository.IRepository;
using Hornet.Service;
using DataAccess.Models;

namespace Hornet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient("MyApi", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7249/");
            });

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyApi"));


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            builder.Services.AddScoped<UserServices>();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<OrderProductsService>();
            builder.Services.AddScoped<ProductCategoryService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<AdminService>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<CartService>();
            builder.Services.AddScoped<ChangeCartService>();
            builder.Services.AddScoped<EmployeeService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Employee", "Customer" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
            using (var scope = app.Services.CreateScope())
            {
                //ADMIN
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                string email = "Admin@mail.com";
                string password = "Admin1!";
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = email;
                    user.Email = email;
                    user.EmailConfirmed = true;
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                //Users
                userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                List<string> Emails = new List<string>();
                Emails.Add("David");
                Emails.Add("Emanuel");
                Emails.Add("Robin"); 
                Emails.Add("Fredrik");
                Emails.Add("Sanna");
                Emails.Add("Gobbard");
                Emails.Add("Tjatte");
                Emails.Add("Joakim");
                Emails.Add("Fnatte");
                Emails.Add("Kalle");
                List<string> Passwords = new List<string>();
                Passwords.Add("Employee1!");
                Passwords.Add("Employee2!");
                Passwords.Add("Employee3!");
                Passwords.Add("Employee4!");
                Passwords.Add("Employee5!");
                Passwords.Add("Customer1!");
                Passwords.Add("Customer2!");
                Passwords.Add("Customer3!");
                Passwords.Add("Customer4!");
                Passwords.Add("Customer5!");
                int i = 0;
                foreach (string emails in Emails)
                {
                    if (await userManager.FindByEmailAsync(Emails[i]) == null)
                    {
                        var user = new IdentityUser();
                        user.UserName = Emails[i] + "@mail.com";
                        user.Email = Emails[i] + "@mail.com";
                        user.EmailConfirmed = true;
                        await userManager.CreateAsync(user, Passwords[i]);
                        if (i > 4)
                        {
                            await userManager.AddToRoleAsync(user, "Customer");
                        }
                        else
                        {
                            await userManager.AddToRoleAsync(user, "Employee");
                        }
                        i++;
                    }
                    else if (await userManager.FindByEmailAsync(Emails[i]) != null)
                    {
                        break;
                    }
                }
                }
            app.Run();
        }
    }
}