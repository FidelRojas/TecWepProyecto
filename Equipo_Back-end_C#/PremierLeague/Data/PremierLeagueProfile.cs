using AutoMapper;
using PremierLeague.Data.Entities;
using PremierLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Data
{
    public class PremierLeagueProfile : Profile
    {
        public PremierLeagueProfile()
        {
            this.CreateMap<EquipoEntity, Equipo>()
                .ReverseMap();

            this.CreateMap<JugadorEntity, Jugador>()
                .ReverseMap();


            //this.CreateMap<Camp, CampModel>()
            //  .ForMember(c => c.Venue, o => o.MapFrom(m => m.Location.VenueName))
            //  .ReverseMap();

            //this.CreateMap<Talk, TalkModel>()
            //  .ReverseMap()
            //  .ForMember(t => t.Camp, opt => opt.Ignore())
            //  .ForMember(t => t.Speaker, opt => opt.Ignore());
        }
    }
}
