# HealthChecksRepro
Reproduces a problem I'm seeing using health checks in a .NET Console app.

Summary: I have a `IHealthCheckPublisher` that gets called when I call `.AddHealthChecks` wihtout adding any checks via `.AddCheck`. As soon as I add any checks, `IHealthCheckPublisher.PublishAsync` is no longer called.