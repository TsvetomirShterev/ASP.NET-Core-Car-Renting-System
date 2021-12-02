namespace CarRentingSystem.Infrastructure
{
    using System.Security.Claims;

    public static class ClaimsPrincipleExtentions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
