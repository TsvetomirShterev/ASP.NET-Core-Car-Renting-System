﻿namespace CarRentingSystem.Infrastructure
{
    using System.Security.Claims;

    public static class ClaimsPrincipleExtentions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}