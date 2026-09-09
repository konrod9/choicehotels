using Microsoft.EntityFrameworkCore;
using ChoiceHotels.Application.Interfaces;
using ChoiceHotels.Application.UseCases.GetAllClicks;
using ChoiceHotels.Application.UseCases.TrackClick;
using ChoiceHotels.Infrastructure.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ClickContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClickRepository, ClickRepository>();
builder.Services.AddScoped<TrackClickUseCase>();
builder.Services.AddScoped<GetAllClicksUseCase>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ClickContext>();
    db.Database.Migrate();
}

app.UseCors(builder =>
{
    builder.WithOrigins(
            "https://choicehotels-frontend-561x.vercel.app/",
            "https://choicehotels-frontend-v2jz.vercel.app/")
        .AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();