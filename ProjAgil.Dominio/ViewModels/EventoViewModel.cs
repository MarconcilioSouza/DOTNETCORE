using System;
using System.Collections.Generic;
using System.Text;

namespace ProjAgil.Dominio.ViewModels
{
    public class EventoViewModel
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<LoteViewModel> Lotes { get; set; }
        public List<RedeSocialViewModel> RedesSociais { get; set; }
        public List<PalestranteViewModel> Palestrantes { get; set; }
    }
}
