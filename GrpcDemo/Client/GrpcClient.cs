using Grpc.Net.Client;
using StockApp;

using var channel = GrpcChannel.ForAddress("https://localhost:5001"); 
var client = new StockService.StockServiceClient(channel);

var request = new StockRequest { Symbol = "AAPL" };
using var call = client.GetStockUpdates(request);

await foreach (var response in call.ResponseStream.ReadAllAsync())
{
    Console.WriteLine($"Stock: {response.Symbol}, Price: {response.Price}");
}
// This code demonstrates how to create a gRPC client in C# to consume a gRPC service.
// It connects to a gRPC server, sends a request for stock updates, and prints the received stock prices in real-time.
// The client uses the Grpc.Net.Client library to establish a connection and communicate with the server.
// The StockServiceClient is generated from the .proto file and provides methods to call the gRPC service.
// The code uses asynchronous programming with async/await to handle the streaming response from the server.
// The client listens for stock updates and prints them to the console as they arrive.
// This is a simple example of how to consume a gRPC service in C# using the Grpc.Net.Client library.
// The code is structured to be easy to read and understand, making it suitable for educational purposes.
// The use of async/await allows for non-blocking calls, making the client responsive and efficient.
// The code is designed to be run in a console application, and it assumes that the gRPC server is running locally on port 5001.
// The client connects to the server using a secure HTTPS connection.
// The StockRequest and StockResponse messages are defined in the .proto file, and the client uses these messages to communicate with the server.
// The code is self-contained and does not require any external dependencies other than the Grpc.Net.Client library.
// The client is designed to be simple and straightforward, making it easy to understand how gRPC works in C#.
// The code is a complete example of how to create a gRPC client in C# and consume a gRPC service.
// The client can be easily modified to handle different types of requests and responses by changing the request and response messages.
// The code is a good starting point for anyone looking to learn about gRPC in C# and how to create a client to consume gRPC services.
// The client can be extended to handle errors and exceptions that may occur during the gRPC call.
// The code can be used as a template for creating more complex gRPC clients that require additional functionality.
// The client can be integrated into larger applications that require real-time data updates from a gRPC server.
// The code is designed to be modular and reusable, making it easy to integrate into existing projects.
// The client can be used in various scenarios, such as financial applications, real-time data monitoring, and more.
// The code is a practical example of how to use gRPC in C# and demonstrates the power of gRPC for building efficient and scalable applications.