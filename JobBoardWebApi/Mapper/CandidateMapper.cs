using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using Riok.Mapperly.Abstractions;

namespace JobBoardWebApi.Mapper
{
    [Mapper]   
    
    public static partial class CandidateMapper
    {
        [MapProperty(nameof(Candidate.User.FullName), nameof(CandidateDto.FullName))]
        [MapProperty(nameof(Candidate.User.UserName), nameof(CandidateDto.UserName))]
        [MapProperty(nameof(Candidate.User.Email), nameof(CandidateDto.Email))]
        public static partial CandidateDto MapCandidateToDto(Candidate candidate);
    }
}

