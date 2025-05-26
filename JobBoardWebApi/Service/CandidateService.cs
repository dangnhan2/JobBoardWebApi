using JobBoardWebApi.Dtos;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepo _candidateRepo;
        private readonly UserManager<User> _userManager;

        public CandidateService(ICandidateRepo candidateRepo, UserManager<User> userManager)
        {
            _candidateRepo = candidateRepo;
            _userManager = userManager;
        }

        public async Task DeleteCandidate(Guid id)
        {
            var isExist = await _candidateRepo.GetById(id) ?? throw new KeyNotFoundException("Candidate not found!");

            _candidateRepo.Delete(isExist);
            await _userManager.DeleteAsync(isExist.User);

            await _candidateRepo.SaveChanges();
        }

        public async Task<IEnumerable<CandidateDto>> GetAllCandidates()
        {
            var candidates = _candidateRepo.GetAll();

            return await candidates.Include(x => x.User).Select(x => CandidateMapper.MapCandidateToDto(x)).ToListAsync();
        }

        public async Task<CandidateForIdDto> GetCandidateById(Guid id)
        {
            var isExist = await _candidateRepo.GetById(id) ?? throw new KeyNotFoundException("Candidate not found!");

            Console.WriteLine(isExist);

            var candidateForId = new CandidateForIdDto
            {
                Id = isExist.Id,
                FullName = isExist.User.FullName,
                UserName = isExist.User.UserName,
                Email = isExist.User.Email,
                Gender = isExist.Gender,
                IsStudent = isExist.IsStudent,
                Skills =  isExist.candidateSkillMappings.Select(s => new SkillDto
                {
                    Name = s.Skill.Name,
                }).ToList(),
                Applications = isExist.Applications.Select(s => new ApplicationDto
                {
                    Status = s.Status,
                    FileUrl = s.FileUrl,
                    CoverLetter = s.CoverLetter,
                }).ToList(),

            };

            return candidateForId;

        }

        public async Task UpdateCandidate(Guid id, CandidateAction candidate)
        {
            var isExist = await _candidateRepo.GetById(id) ?? throw new KeyNotFoundException("Candidate not found!");

            isExist.User.UserName = candidate.UserName;
            isExist.User.Email = candidate.Email;
            isExist.User.NormalizedEmail = candidate.Email;
            isExist.User.PhoneNumber = candidate.PhoneNumber;
            isExist.User.FullName = candidate.FullName;
            isExist.Gender = candidate.Gender;
            isExist.candidateSkillMappings = new List<CandidateSkillMapping>();

            foreach(var skillId in candidate.Skills)
            {
                isExist.candidateSkillMappings.Add(new CandidateSkillMapping
                { 
                    CandidateId = isExist.Id,
                    SkillId = skillId
                });
            }

            _candidateRepo.Update(isExist);
            await _candidateRepo.SaveChanges();
        }
    }
}


