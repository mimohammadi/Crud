using Crud.Common.Interfaces;

namespace Crud.Domain.Models.PersonalInfo
{
    public class PersonalInfo : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string NationalId { get; private set; }
        public DateTime BirthDate { get; private set; }

        protected PersonalInfo()
        {
        }

        public PersonalInfo(string name, string lastName, string nationalId, DateTime birthDate)
        {
            Name = name;
            LastName = lastName;
            NationalId = nationalId;
            BirthDate = birthDate;
        }

        public void Update(string name, string lastName, string nationalId, DateTime birthDate)
        {
            Name = name;
            LastName = lastName;
            NationalId = nationalId;
            BirthDate = birthDate;
        }
    }
}
