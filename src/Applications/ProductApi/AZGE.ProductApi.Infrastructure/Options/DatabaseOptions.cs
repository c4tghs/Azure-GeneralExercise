namespace AZGE.ProductApi.Infrastructure.Options;

public class DatabaseOptions
{
    public const string Database = "Database";

    public string ConnectionString { get; set; } = default!;
}