using RequestBoard.Models.Interfaces;

namespace RequestBoard.Models.DbModels
{
    public class RequestType : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}