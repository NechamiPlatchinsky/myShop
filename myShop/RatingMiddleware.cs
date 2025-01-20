using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Services;
using System;
using System.Threading.Tasks;

namespace myShop
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;

        public RatingMiddleware(RequestDelegate next, IRatingService _IRatingService)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext, IRatingService ratingService)
        {
            Rating rating = new()
            {
                Host = httpContext.Request.Host.ToString(),
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path, 
                Referer = httpContext.Request.Headers.Referer,
                UserAgent = httpContext.Request.Headers.UserAgent,
                RecordDate = DateTime.Now };
            ratingService.addRating(rating);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
