using AZGE.ProductApi.Infrastructure.Options;
using AZGE.ProductApi.Persistence;
using AZGE.ProductApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Controllers
builder.Services.AddControllers();

// Services
builder.Services.AddProductServices();

// Swagger | OAS
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.CustomSchemaIds(type => type.DeclaringType is null ? $"{type.Name}" : $"{type.DeclaringType?.Name}.{type.Name}");
    }
);

// Database
builder.Services.AddDbContext<ProductDbContext>(options =>
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
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
        dbContext.Database.EnsureCreated();
        dbContext.Database.Migrate();
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
