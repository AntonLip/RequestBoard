using System.ComponentModel.DataAnnotations.Schema;
using RequestBoard.Models.Interfaces;

namespace RequestBoard.Models.DbModels
{
    public class RequestToRestore : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        [ForeignKey("RequestType")]
        public Guid RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }
    }
}
