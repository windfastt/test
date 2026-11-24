using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UltraCompress.Engine;
using UltraCompress.Engine.Ipc;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "UltraCompress.Engine";
});

builder.Services.AddSingleton<EngineRuntimeState>();
builder.Services.AddHostedService<EnginePipeHostedService>();
builder.Services.AddHostedService<Worker>();

builder.Services.Configure<HostOptions>(options =>
{
    options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.StopHost;
});

var host = builder.Build();
await host.RunAsync().ConfigureAwait(false);