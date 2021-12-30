// Patch path base with forwarded path. Used for Nginx integration for sub-path applications.
public class ForwardPathMiddleware
{
    private readonly RequestDelegate _next;

    public ForwardPathMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var forwardedPath = context.Request.Headers["X-Forwarded-Path"].FirstOrDefault();
        if (!string.IsNullOrEmpty(forwardedPath))
        {
            context.Request.PathBase = forwardedPath;
        }

        await _next(context);
    }
}