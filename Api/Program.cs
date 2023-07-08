using Api.Routes;
using Infrastructure.Dependencies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
DependencyInversion.Register(builder.Services);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
var productRoutes = new ProductRoutes(app);
productRoutes.Start();
app.Run();

