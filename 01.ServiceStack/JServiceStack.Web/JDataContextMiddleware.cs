// using System.Threading.Tasks;
// using eXtensionSharp;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Http;
//
// namespace JServiceStack.Web
// {
//     public static class JDataContextMiddlewareExtension
//     {
//         public static IApplicationBuilder UseJDataContext(this IApplicationBuilder app)
//         {
//             return app.UseMiddleware<JDataContextMiddleware>();
//         }
//     }
//     
//     public class JDataContextMiddleware
//     {
//         private readonly RequestDelegate _next;
//         private readonly JDataContext _dataContext;
//         public JDataContextMiddleware(RequestDelegate next) {
//             _next = next;
//             _dataContext = new JDataContext();
//         }
//
//         public async Task Invoke(HttpContext context)
//         {
//             // _dataContext.ControllerName = "t";
//             // await context.Response.WriteAsync(_dataContext.xToJson());
//             await _next(context);
//         }
//     }
// }