namespace MoneyTracking.API.Models.Requests
{
    public class UpdateRoleQuery
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
    }
}