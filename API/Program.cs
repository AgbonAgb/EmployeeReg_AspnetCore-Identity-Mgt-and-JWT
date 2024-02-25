using API.MiddlewareExt;
using ApplicationCore.Services.Interface;
using ApplicationCore.Services.Repository;
using ApplicationCore.Services.Utilities;
using Infrastructure.Accounts;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var conn = builder.Configuration.GetConnectionString("DefaultConn");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conn));

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDocSwagger();

//Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IEmployeeBasicInfoRepository, EmployeeBasicInfoRepository>();

builder.Services.AddIdentity<UserReg, UserRoles>(otp =>
{
    otp.SignIn.RequireConfirmedAccount = false;
    //otp.SignIn.RequireConfirmedEmail = true;
    otp.Password.RequireNonAlphanumeric = false;
    otp.Password.RequiredLength = 6;
})
    .AddRoleManager<RoleManager<UserRoles>>()
    .AddUserManager<UserManager<UserReg>>()
    .AddSignInManager<SignInManager<UserReg>>()//this is to allow sign-n
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<AppDbContext>();



var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
