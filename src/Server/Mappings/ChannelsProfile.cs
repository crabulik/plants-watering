using AutoMapper;
using PlantsWatering.Shared.Dtos.Channels;

namespace PlantsWatering.Server.Mappings
{
    public class ChannelsProfile : Profile
	{
		public ChannelsProfile()
		{
			CreateMap<CommunicationChannel, CommunicationChannelDto>();
		}
	}
}
