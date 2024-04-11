using AZGE.StockApi.Infrastructure.Options;
using AZGE.StockApi.Persistence;
using Microsoft.EntityFrameworkCore;
using AZGE.StockApi.Services;
using AZGE.StockApi.Domain.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Controllers
builder.Services.AddControllers();

// Services
builder.Services.AddStockServices();

// Swagger | OAS
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.DeclaringType is null ? $"{type.Name}" : $"{type.DeclaringType?.Name}.{type.Name}");
}
);

// Database
builder.Services.AddDbContext<StockDbContext>(options =>
{
    string connection = builder
        .Configuration
        .GetSection(DatabaseOptions.Database)
        .Get<DatabaseOptions>()
        .ConnectionString;

    options.UseSqlServer(
        connection
    );
}
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<StockDbContext>();
        dbContext.Database.EnsureCreated();
        dbContext.Database.Migrate();
        dbContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT StockApi.$StockProduct ON");
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
