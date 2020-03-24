using AutoMapper;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.ViewModels;

namespace Equinox.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EventoViewModel, Evento>();
            CreateMap<EventoViewModel, Evento>();
            CreateMap<LoteViewModel, Lote>();
            CreateMap<PalestranteViewModel, Palestrante>();
            CreateMap<RedeSocialViewModel, RedeSocial>();
        }
    }
}
