using BackendAbara.Models;
using BackendAbara.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5000.com",
                                              "http://localhost:3000.com").AllowAnyHeader()
                                                  .AllowAnyMethod(); ;
                      });
});
builder.Services.Configure<PetsDatabaseSetting>(
    builder.Configuration.GetSection("PetsDatabase"));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PetService>();
builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors();

app.MapControllers(); // Ensure controllers are mapped correctly
app.UseAuthentication();
app.UseAuthorization();
app.Run();

