using System.ComponentModel.DataAnnotations;

namespace RequestBoard.Models.ViewModels.Admin
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Обязательное поле")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Обязательное поле")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Обязательное поле")]
        public string LastName { get; set; }
        public string UserRoleId { get; set; }
    }
}
