# DamlSocket

## Overview
DamlSocket is a library designed to simplify the development of Interactive Voice Response (IVR) systems. It allows developers to write stateful, linear, async/await-style C# code to control calls, bridging the gap between stateless HTTP protocols (like Twilio's TwiML) and stateful application logic.

Instead of managing complex state machines or database cursors to track a user's progress through a call, DamlSocket lets you write code that reads naturally from top to bottom.

## How It Works
DamlSocket uses `TaskCompletionSource` to pause the execution of your C# method when waiting for user input.
1. **Request**: An HTTP request (GET/POST) arrives from the telephony provider (e.g., Twilio).
2. **Resume**: DamlSocket finds the existing session (based on `CallSid`) and resumes the paused method.
3. **Execution**: Your code runs until it needs more input (e.g., `client.GetInputAsync()`).
4. **Response**: The method pauses again, and the TwiML response is sent back to the provider.

## Quick Integration Guide

### 1. Setup Dependency Injection
In your ASP.NET Core `Program.cs` or `Startup.cs`, register the DamlSocket services and your IVR logic classes.

```csharp
using DamlSocket.DiExtention;

var builder = WebApplication.CreateBuilder(args);

// 1. Add DamlSocket Core Services
builder.Services.AddDamlSocket();

// 2. Register your IVR classes (Must be Scoped)
builder.Services.AddScoped<MyIvrLogic>();

var app = builder.Build();
```

### 2. Map the Endpoint
Map the DamlSocket middleware to a specific route. This route will handle incoming webhooks.

```csharp
using DamlSocket.Extensions;

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Maps GET and POST requests to /ivr to the DamlSocket engine
    endpoints.MapDamlSocket("/ivr");
});

app.Run();
```

## Partial Integration with Existing Projects

If you have an existing ASP.NET Core project (e.g., using MVC Controllers for TwiML), you can add DamlSocket alongside your existing routes. This allows you to migrate specific complex flows to DamlSocket while keeping simple static TwiML in controllers.

### Example `Program.cs`

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add standard MVC/Controllers
builder.Services.AddControllers();

// Add DamlSocket
builder.Services.AddDamlSocket();
builder.Services.AddScoped<ComplexIvrFlow>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Existing Controllers (e.g., /api/voice/simple)
    endpoints.MapControllers();

    // DamlSocket Endpoint (e.g., /daml/ComplexFlow)
    // Only requests matching this pattern are handled by DamlSocket
    endpoints.MapDamlSocket("/daml/{method?}");
});

app.Run();
```

In this setup:
*   `POST /api/voice/simple` -> Handled by your existing Controller.
*   `POST /daml/ComplexFlow` -> Handled by DamlSocket (`ComplexIvrFlow.ComplexFlow`).

## Writing an IVR Service

Create a class to handle the call logic. Inject the `Client` service to interact with the caller.

```csharp
using DamlSocket.Services;
using System.Threading.Tasks;

public class MyIvrLogic
{
    private readonly Client _client;

    public MyIvrLogic(Client client)
    {
        _client = client;
    }

    // The method name corresponds to the 'method' query parameter
    // e.g., /ivr?method=Welcome
    public async Task Welcome()
    {
        // 1. Send TwiML and wait for user input (digits, speech, etc.)
        var input = await _client.GetInputAsync(
            "<Response><Gather numDigits='1'><Say>Press 1 for Sales, 2 for Support.</Say></Gather></Response>"
        );

        // 2. Process the input (input is a JObject containing the form data)
        var digits = input["Digits"]?.ToString();

        if (digits == "1")
        {
            // Linear logic flow - no state machine needed!
            await _client.GetInputAsync("<Response><Say>Connecting you to sales...</Say></Response>");
        }
        else
        {
            await _client.GetInputAsync("<Response><Say>Connecting you to support...</Say></Response>");
        }
    }
}
```

## Key Features

### `Client.GetInputAsync(string twiml)`
*   **Sends Response**: Returns the provided TwiML string to the HTTP caller.
*   **Pauses**: Suspends the execution of the method.
*   **Resumes**: When the next HTTP request arrives with the same `CallSid`, it returns the request parameters (Form/Query) as a `JObject` and resumes execution.

### Exception Handling
Exceptions thrown within your IVR logic are automatically caught and converted into HTTP 500 responses. This allows the telephony provider to trigger their fallback URL or error handling logic.

### Session Lifecycle (`CallScope`)
DamlSocket maintains a `CallScope` keyed by the `CallSid`.
*   **Persistence**: The `IServiceScope` stays alive for the duration of the call.
*   **State**: Your Scoped services (like `MyIvrLogic`) retain their state variables between HTTP requests.
*   **Cleanup**: The scope should be disposed when the call ends (implementation detail: currently relies on explicit cleanup or timeout).

## Testing
You can test your IVR flows using `Microsoft.AspNetCore.TestHost` without a real phone.

```csharp
[Fact]
public async Task Test_Welcome_Flow()
{
    // Setup TestServer with DamlSocket...
    var client = host.GetTestClient();

    // Simulate incoming call
    var response = await client.PostAsync("/ivr?method=Welcome&CallSid=123", null);
    
    // Assert TwiML response
    Assert.Contains("Press 1 for Sales", await response.Content.ReadAsStringAsync());
}

## TCP Integration Guide

In addition to ASP.NET Core integration, DamlSocket can run as a standalone TCP server. This is useful for legacy integrations or specific socket-based telephony providers.

### 1. Setup Dependency Injection
Register DamlSocket services just like in the ASP.NET Core example.

```csharp
using DamlSocket.DiExtention;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDamlSocket();
        // Register your IVR classes
        services.AddScoped<MyIvrLogic>();
        // Register the worker that starts the listener
        services.AddHostedService<TcpWorker>();
    })
    .Build();

host.Run();
```

### 2. Start the Listener
Create a `BackgroundService` to start the TCP listener. Inject `ListenerStartup` and call `Start()`.

```csharp
using DamlSocket;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

public class TcpWorker : BackgroundService
{
    private readonly ListenerStartup _listenerStartup;

    public TcpWorker(ListenerStartup listenerStartup)
    {
        _listenerStartup = listenerStartup;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Optional: Configure the port (Default is 4649)
        ListenerStartup.Port = 4649;

        // Start the TCP Listener
        return _listenerStartup.Start();
    }
}
```

### 3. Protocol Details
The TCP listener expects a JSON-RPC 2.0 style payload.

**Request Format:**
```json
{
    "jsonrpc": "2.0",
    "method": "Welcome",
    "params": {
        "callSid": "unique-call-id",
        "Digits": "1"
    },
    "id": "request-guid"
}
```

**Response Format:**
```json
{
    "jsonrpc": "2.0",
    "result": "<Response><Say>Hello</Say></Response>",
    "id": "request-guid"
}
```
```