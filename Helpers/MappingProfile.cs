using AutoMapper;
using Educational_Medical_platform.DTO.Objective;
using Educational_Medical_platform.DTO.Requirement;
using Educational_Medical_platform.DTO.Video;
using Educational_Medical_platform.Models;

namespace Educational_Medical_platform.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Requirement, GetRequirementDTO>();
            CreateMap<GetRequirementDTO, Requirement>();
            CreateMap<Objective, GetObjectiveDTO>();
            CreateMap<GetObjectiveDTO, Objective>();
            CreateMap<List<Requirement>, List<GetRequirementDTO>>();
            CreateMap<List<GetRequirementDTO>, List<Requirement>>();
            CreateMap<List<GetObjectiveDTO>, List<Objective>>();
            CreateMap<List<Objective>, List<GetObjectiveDTO>>();
            CreateMap<List<Video>, List<GetVideoDTO>>();
            CreateMap<List<GetVideoDTO>, List<Video>>();
            CreateMap<Video , GetVideoDTO>();
            CreateMap<GetVideoDTO , Video>();
        }
    }
}
