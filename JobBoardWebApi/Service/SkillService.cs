using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepo _skillRepo;

        public SkillService(ISkillRepo skillRepo)
        {
            _skillRepo = skillRepo;
        }

        public async Task AddSkill(SkillAction category)
        {
            var skills = _skillRepo.GetSkills();

            if(await _skillRepo.GetSkills().AnyAsync(s => s.Name.ToLower() == category.Name.ToLower()))
            {
                throw new Exception("Skill already exists");
            }

            var newSkill = new Skill
            {
                Name = category.Name,
            };

            await _skillRepo.AddSkill(newSkill);
            await _skillRepo.Save();
        }

        public async Task DeleteSkill(Guid id)
        {
            var isExist = await _skillRepo.GetById(id) ?? throw new KeyNotFoundException("Id not found!");

            _skillRepo.DeleteSkill(isExist);

            await _skillRepo.Save();
        }

        public async Task<IEnumerable<SkillDto>> GetSkill()
        {
            var skills = _skillRepo.GetSkills();

            return await skills.Select(x => new SkillDto
            {   
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }

        public async Task UpdateSkill(Guid id, SkillAction skill)
        {
            var isExist = await _skillRepo.GetById(id) ?? throw new KeyNotFoundException("Id not found!");

            var skills = _skillRepo.GetSkills();

            if (await skills.AnyAsync(s => s.Name.ToLower() == skill.Name.ToLower() && s.Id != id)) {
                throw new Exception("Skill already exists");
            }

            isExist.Name = skill.Name;

            _skillRepo.UpdateSkill(isExist);
            await _skillRepo.Save();
        }
    }
}
