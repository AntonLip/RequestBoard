using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequestBoard.Models.Interfaces;

namespace RequestBoard.Models.DbModels
{
    public class RequestToRestore : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Обязательное поле")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Обязательное поле")]

        public string Description { get; set; }
        public string UserId { get; set; }
        public Stages Stage {get;set;}

        [ForeignKey("RequestType")]
        public Guid RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }
    }
}
