using MinimalAPI.Presentation;
using MinimalAPI.Presentation.Plugins.Application;
using MinimalAPI.Presentation.Plugins.Bootstrap;
using MinimalAPI.Presentation.Routes;

Bootstrap content = Bootstrap.Make();

var app = content.GetApplication();

app.UseDevelopmentSwagger();
app.HealthRoute();
app.TodoRoute();

app.Run();