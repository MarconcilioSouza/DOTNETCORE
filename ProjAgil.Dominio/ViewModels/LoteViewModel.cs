using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjAgil.Dominio.ViewModels
{
    public class LoteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        [Range(2, 120000 , ErrorMessage ="A quantidade deve ser entre 2 e 120000 caracteres")]
        public int Quantidade { get; set; }
    }
}
