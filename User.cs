namespace ElmaSQLServise
{
    public class User
    {
        public Guid AdId { get; set; }
        public string? Name { get; set; }
        public Guid[]? AdOsIds { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
        public string? MobilePhone { get; set; }

        public static User Create(
            Guid AdId,
            string? Name,
            Guid[]? AdOsIds,
            string? Email,
            string? Login,
            string? MobilePhone ) 
        { 
            return new User() { 
                AdId = AdId,
                Name = Name,
                AdOsIds = AdOsIds,
                Email = Email,
                Login = Login,
                MobilePhone = MobilePhone
            }; 
        }
    }
}
