using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using Riok.Mapperly.Abstractions;

namespace JobBoardWebApi.Mapper
{
    [Mapper]   
    
    public static partial class CandidateMapper
    {
        [MapProperty(nameof(Candidate.User.FullName), nameof(CandidatesDto.FullName))]
        [MapProperty(nameof(Candidate.User.UserName), nameof(CandidatesDto.UserName))]
        [MapProperty(nameof(Candidate.User.Email), nameof(CandidatesDto.Email))]
        public static partial CandidatesDto MapCandidateToDto(Candidate candidate);
    }
}

