public static class MiddlewaresExtension 
{
    public static IApplicationBuilder UseForwardPath(this IApplicationBuilder builder){
        return builder.UseMiddleware<ForwardPathMiddleware>();
    }
}