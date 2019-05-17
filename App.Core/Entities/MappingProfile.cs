using App.Core.Entities;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<App.Core.DbEntities.Question, Question>();
        CreateMap<App.Core.DbEntities.QuestionAnswer, QuestionAnswer>();
        CreateMap<App.Core.DbEntities.QuestionTag, QuestionTag>();
    }
}