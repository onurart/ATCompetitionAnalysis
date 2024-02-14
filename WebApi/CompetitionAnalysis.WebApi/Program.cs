using CompetitionAnalysis.Persistance.Context;
using CompetitionAnalysis.WebApi.Configurations;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
using (var context = new AppDbContext()) { context.Database.Migrate(); }

app.Run();
