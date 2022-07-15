namespace ReferenceApi.Models
{
    public class UserInfo : IHasId
    {
        public Guid Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}
