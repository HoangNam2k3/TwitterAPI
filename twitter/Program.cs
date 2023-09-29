using Microsoft.EntityFrameworkCore;
using twitter.Data;
using twitter.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConect"));

builder.Services.AddScoped<IRepoTweet, TweetRepo>();
builder.Services.AddScoped<IRepoVideo,  VideoRepo>();
builder.Services.AddScoped<IRepoImage, ImageRepo>();
builder.Services.AddScoped<IRepoProfile, ProfileRepo>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
