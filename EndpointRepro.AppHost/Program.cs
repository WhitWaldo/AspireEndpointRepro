var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.MyApi>("myapi");
var apiEndpoint = api.GetEndpoint("https");
api.WithEnvironment("ApiEndpoint", apiEndpoint);

var web = builder.AddProject<Projects.MyWeb>("myweb")
    .WithHttpsEndpoint()
    .WithReference(api)
    .WithEnvironment("ApiEndpoint", apiEndpoint);
var webEndpoint = web.GetEndpoint("https");
web.WithEnvironment("WebEndpoint", webEndpoint);

builder.Build().Run();
