namespace SoftJail
{
    using AutoMapper;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ExportDto;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {

            this.CreateMap<Prisoner, ExportPrisonerDto>()
                 .ForMember(x => x.Mails, y => y.MapFrom(ep => ep.Mails))
                 //.ForMember(x => x.Mails, y => y.MapFrom(ep => ep.Mails))
                 ;

            this.CreateMap<Mail, ExportPrisonerMailDto>();
        }
    }
}
