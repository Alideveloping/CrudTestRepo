using FluentValidation.AspNetCore;
using FluentValidation;
using CrudRepos.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CrudRepos.Data;
using CrudRepos.Application.Services.Users.Query;
using CrudRepos.Application.Vaidators;
using CrudRepos.Application.Services.Users.Command;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<CrudReposContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrudReposContext") ?? throw new InvalidOperationException("Connection string 'CrudReposContext' not found.")));

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//context
builder.Services.AddScoped<DatabaseContext>();

//user
builder.Services.AddValidatorsFromAssemblyContaining<RequestRegisterUserDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IRegisterUserService, AddNewUserService>();






var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=List}");


app.Run();
