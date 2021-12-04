namespace CarRentingSystem.Infrastructure.Extentions
{
    using System.Security.Claims;

    using static CarRentingSystem.Areas.Admin.AdminConstants;

    public static class ClaimsPrincipleExtentions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(AdministratorRoleName);
    }
}
