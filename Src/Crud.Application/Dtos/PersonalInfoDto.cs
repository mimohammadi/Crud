namespace Crud.Application.Dtos
{
    public class PersonalInfoDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
