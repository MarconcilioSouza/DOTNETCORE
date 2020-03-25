using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjAgil.Dominio.ViewModels
{
    public class EventoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Local deve ser Preenchido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Local deve ter entre 3 e 100 caracteres")]
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required(ErrorMessage = "O Tema deve ser Preenchido")]
        public string Tema { get; set; }
        [Range(2, 120000, ErrorMessage = "Quantidade de Pessoas é entre 2 e 120000")]
        public int QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        [Phone(ErrorMessage = "Informe um Telefone válido")]
        public string Telefone { get; set; }
        [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
        public string Email { get; set; }
        public List<LoteViewModel> Lotes { get; set; }
        public List<RedeSocialViewModel> RedesSociais { get; set; }
        public List<PalestranteViewModel> Palestrantes { get; set; }
    }
}
