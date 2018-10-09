using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Restaurante.UI.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}