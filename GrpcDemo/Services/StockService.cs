using Grpc.Core;
using System;
using System.Threading.Tasks;

public class StockService : StockApp.StockServiceBase
{
    public override async Task GetStockUpdates(StockRequest request,
        IServerStreamWriter<StockResponse> responseStream,
        ServerCallContext context)
    {
        Random rand = new();
        
        for (int i = 0; i < 10; i++) // Simulating real-time stock updates
        {
            var stockUpdate = new StockResponse
            {
                Symbol = request.Symbol,
                Price = Math.Round(rand.NextDouble() * 1000, 2)
            };

            await responseStream.WriteAsync(stockUpdate);
            await Task.Delay(1000); // Simulate real-time delay
        }
    }
}
