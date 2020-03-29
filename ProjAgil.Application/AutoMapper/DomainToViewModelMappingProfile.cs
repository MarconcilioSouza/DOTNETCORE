using AutoMapper;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Identity;
using ProjAgil.Dominio.ViewModels;
using System.Linq;

namespace Equinox.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Evento, EventoViewModel>()
                .ForMember(dest => dest.Palestrantes, opt => { opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList()); });
            CreateMap<Lote, LoteViewModel>();
            CreateMap<Palestrante, PalestranteViewModel>()
                .ForMember(dest => dest.Eventos, opt => { opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList()); });
            CreateMap<RedeSocial, RedeSocialViewModel>();

            CreateMap<User, UserViewModel>();
            CreateMap<User, UserLoginViewMode>();
        }
    }
}
