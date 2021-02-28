namespace MoneyTracking.API.Models.Request
{
    public class AddRoleToUserQuery
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}