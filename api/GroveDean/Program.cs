var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("/");
builder.Services.AddControllers();
 

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.Run();
