using AutoMapper;
using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Robo.AutoMapper
{
    public class AutoMapperManager : Profile
    {

        public AutoMapperManager()
        {
            CreateMap<HomeComportamentoDTO, HomeComportamento>();

            CreateMap<LandingComportamentoDTO, LandingComportamento>()
                .ForMember(dest => dest.CodigoDestino, opt => opt.MapFrom(src => src.CodigoCidadeDestino))
                .ForMember(dest => dest.CodigoOrigem, opt => opt.MapFrom(src => src.CodigoCidadeOrigem));
            CreateMap<LandingComportamentoDTO, Usuario>();

            CreateMap<CheckoutPedidoComportamentoDTO, CheckoutPedidoComportamento>();
            CreateMap<ConfirmacaoPedidoComportamentoDTO, ConfirmacaoPedidoComportamento>();
        }

    }
}
