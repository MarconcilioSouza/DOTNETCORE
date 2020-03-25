using System.ComponentModel.DataAnnotations;

namespace ProjAgil.Dominio.ViewModels
{
    public class RedeSocialViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Url { get; set; }
    }
}
