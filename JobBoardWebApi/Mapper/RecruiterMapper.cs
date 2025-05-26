using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using Riok.Mapperly.Abstractions;

namespace JobBoardWebApi.Mapper
{
    [Mapper]   
    
    public static partial class RecruiterMapper
    {
        [MapProperty(nameof(Recruiter.User.Email), nameof(RecruiterDto.Email))]
        [MapProperty(nameof(Recruiter.User.UserName), nameof(RecruiterDto.UserName))]
        public static partial RecruiterDto MapRecruiterToDto(Recruiter recruiter);
    }
}
