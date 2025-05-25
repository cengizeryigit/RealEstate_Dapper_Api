namespace RealEstate_Dapper_UI.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
