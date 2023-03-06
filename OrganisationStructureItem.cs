
namespace ElmaSQLServise
{
    public class OrganisationStructureItem
    {
        public Guid AdId { get; private set; }
        public List<Guid>? ChieldsId { get; private set; }
        public Guid? ParentAdId { get; private set; }
        public OrganisationStructureItem? HeaderPosition { get; private set; }
        public List<OrganisationStructureItem>? Chields { get; private set; }
        public List<User>? Users { get; private set; }
        public string? Name { get; private set; }
        public OrganisationStructureItemType Type { get; private set; }

        public static OrganisationStructureItem Create(Guid AdId, string CompanyName)
        {
            return new OrganisationStructureItem
            {
                Type = OrganisationStructureItemType.Company,
                Name = CompanyName,
                AdId = AdId
            };
        }

        public OrganisationStructureItem AddDepartment(Guid AdId, string DepartmentName) {
            return CreateChield(OrganisationStructureItemType.Departament,AdId,DepartmentName);
        }
        public OrganisationStructureItem AddGroup(Guid AdId, string GroupName)
        {
            return CreateChield(OrganisationStructureItemType.Group, AdId, GroupName);
        }
        public OrganisationStructureItem AddPosition(Guid AdId, string PositionName)
        {
            return CreateChield(OrganisationStructureItemType.Position, AdId, PositionName);
        }
        public OrganisationStructureItem AddHeaderPosition(Guid AdId, string PositionName)
        {
            var Header =  CreateChield(OrganisationStructureItemType.Position, AdId, PositionName);
            this.HeaderPosition = Header;
            return Header;
        }
        private OrganisationStructureItem CreateChield(OrganisationStructureItemType Type, Guid AdId, string Name)
        {
            if (this.Type == OrganisationStructureItemType.Position) { throw new Exception("Для элементов оргструктуры типа 'позиций' нельзя создать вложенный элемент"); }
            var result = new OrganisationStructureItem
            {
                Type = Type,
                Name = Name,
                AdId = AdId,
                HeaderPosition = HeaderPosition,
                ParentAdId = this.AdId  
            };
            this.ChieldsId ??= new List<Guid>();
            this.ChieldsId.Add(AdId);
            this.Chields ??= new List<OrganisationStructureItem>();
            this.Chields.Add(result);
            return result;
        }
        public void AddUser(User user)
        {
            this.Users ??= new List<User>();
            this.Users.Add(user);
        }
    }

    public enum OrganisationStructureItemType
    { 
        Departament, Group, Position, Company
    }
}