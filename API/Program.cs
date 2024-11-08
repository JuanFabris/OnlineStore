using API.Database;
using API.Interface;
using API.Models;
using API.Repository;
//using API.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSwaggerGen(option =>
// {
//     option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
//     option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//     {
//         In = ParameterLocation.Header,
//         Description = "Please enter a valid token",
//         Name = "Authorization",
//         Type = SecuritySchemeType.Http,
//         BearerFormat = "JWT",
//         Scheme = "Bearer"
//     });
//     option.AddSecurityRequirement(new OpenApiSecurityRequirement
//     {
//         {
//             new OpenApiSecurityScheme
//             {
//                 Reference = new OpenApiReference
//                 {
//                     Type=ReferenceType.SecurityScheme,
//                     Id="Bearer"
//                 }
//             },
//             new string[]{}
//         }
//     });
// });


//Prevent object loop
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<AppDbGoal5>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddScoped<IAvatarRepo, AvatarRepo>();
builder.Services.AddScoped<IAvatarSkillRepo, AvatarSkillRepo>();

//password 
// builder.Services.AddIdentity<User, IdentityRole>(options => {
//     options.Password.RequireDigit = true;
//     options.Password.RequireLowercase = true;
//     options.Password.RequireUppercase = true;
//     options.Password.RequireNonAlphanumeric = true;
//     options.Password.RequiredLength = 12;
// })
// .AddEntityFrameworkStores<AppDbGoal5>();

// //add scheme
// builder.Services.AddAuthentication(options => {
//     options.DefaultAuthenticateScheme =
//     options.DefaultChallengeScheme =
//     options.DefaultForbidScheme =
//     options.DefaultScheme =
//     options.DefaultSignInScheme =
//     options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(options => {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidIssuer = builder.Configuration["JWT:Issuer"],
//         ValidateAudience = true,
//         ValidAudience = builder.Configuration["JWT:Audience"],
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(
//             System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
//         )
//     };
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseCors(x => x
//     .AllowAnyHeader()
//     .AllowAnyMethod()
//     .AllowCredentials()
//     //.WithOrigins("https://localhost:....")
//     .SetIsOriginAllowed(origin => true)
// );

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();