using Carter;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Dtos;
using VSATestProject.Entities;
using VSATestProject.Features.Books;
using VSATestProject.Features.Books.Validators;
using VSATestProject.Features.Sessions;
using VSATestProject.Features.Users;
using VSATestProject.Middlewares;
using VSATestProject.Services;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(connString);
});

builder.Services.AddScoped<GenerateSession.SessionHandler>();
builder.Services.AddScoped<Login.LoginHandler>();
builder.Services.AddScoped<Registration.RegistrationHandler>();
builder.Services.AddScoped<TokenCheck.TokenCheckHandler>();
builder.Services.AddScoped<PasswordHasherService>();
builder.Services.AddScoped<CredentialsCheckService>();

builder.Services.AddScoped<CreateBook.CreateBookHandler>();
builder.Services.AddScoped<GetAllBooks.GetAllBooksHandler>();
builder.Services.AddScoped<IValidator<CreateBook.CreateBookRequest>, BookValidator>();

builder.Services.AddScoped<GetAllUsers.GetAllUsersHandler>();
builder.Services.AddScoped<GetUser.GetAccountHandler>();
builder.Services.AddScoped<EditUser.EditUserHandler>();
builder.Services.AddScoped<RemoveUser.RemoveUserHandler>();

builder.Services.AddScoped<GetAllSessions.GetAllSessionsHandler>();
builder.Services.AddScoped<RemoveSession.RemoveSessionHandler>();
builder.Services.AddScoped<GetSession.GetSessionHandler>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = AuthOptions.Audience,
            
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<HandleExceptionsMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run(); 