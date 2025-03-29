using GrpcDemo.Services;
using Grpc.Net.Client;
using StockApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
// ✅ Map gRPC service
app.MapGrpcService<GreeterService>();
app.MapGrpcService<StockService>(); 
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<StockService>();
});
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new StockService.StockServiceClient(channel);

var request = new StockRequest { Symbol = "AAPL" };
using var call = client.GetStockUpdates(request);

await foreach (var response in call.ResponseStream.ReadAllAsync())
{
    Console.WriteLine($"Stock: {response.Symbol}, Price: {response.Price}");
}