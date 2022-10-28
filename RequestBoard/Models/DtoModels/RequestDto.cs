namespace RequestBoard.Models.DtoModels
{
    public class RequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }      
        public Stages Stage {get;set;}
        public string RequestTypeName { get; set; }
    }
}