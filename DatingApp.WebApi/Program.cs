using DatingApp.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline. ORdering is very important.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
   .WithOrigins("http://localhost:4200", "https://localhost:4200"));  //should be before .mapcontrollers and .run

app.UseAuthentication();    //need to be before authorization
app.UseAuthorization();

app.MapControllers();

app.Run();