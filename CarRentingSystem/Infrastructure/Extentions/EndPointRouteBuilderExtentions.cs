﻿namespace CarRentingSystem.Infrastructure.Extentions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Routing;

    public static class EndPointRouteBuilderExtentions
    {
        public static void  MapDefaultAreaRoute(this IEndpointRouteBuilder endpoints)
            => endpoints.MapControllerRoute(
                       name: "Areas",
                       pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}");
    }
}
