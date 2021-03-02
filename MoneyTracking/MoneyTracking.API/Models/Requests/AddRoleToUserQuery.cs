namespace MoneyTracking.API.Models.Requests
{
    public class AddRoleToUserQuery
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}