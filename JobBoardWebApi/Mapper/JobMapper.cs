using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using Riok.Mapperly.Abstractions;

namespace JobBoardWebApi.Mapper
{
    [Mapper]   
    
    public static partial class JobMapper
    {
        [MapProperty(nameof(Job.Skill.Name), nameof(JobDto.Skill))]
        [MapProperty(nameof(Job.Level.Name), nameof(JobDto.Level))]
        [MapProperty(nameof(Job.Company.Name), nameof(JobDto.Company))]

        public static partial JobDto MapJobToDto(Job job);
    }
}
