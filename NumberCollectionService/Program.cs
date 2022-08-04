var builder = WebApplication.CreateBuilder(args);

var daprHttpPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3601";
var daprGrpcPort = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "60001";

builder.Services.AddDaprClient(builder => builder
    .UseHttpEndpoint($"http://localhost:{daprHttpPort}")
    .UseGrpcEndpoint($"http://localhost:{daprGrpcPort}"));

builder.Services.AddSingleton<NumberRegistrationService>(_ =>
    new NumberRegistrationService(DaprClient.CreateInvokeHttpClient(
        "numberregistrationservice", $"http://localhost:{daprHttpPort}")));

// Add services to the container.

builder.Services.AddControllers().AddDapr();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseCloudEvents();

app.MapControllers();

app.MapSubscribeHandler();

app.Run("http://localhost:6001");
