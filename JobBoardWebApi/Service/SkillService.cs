using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{
    public class SkillService : ISkillRepo
    {
        private readonly ApplicationDbContext _context;

        public SkillService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSkill(SkillRequest category)
        {
            var skills = _context.Skills.AsQueryable();

            if(await skills.AnyAsync(s => s.Name.ToLower() == category.Name.ToLower()))
            {
                throw new Exception("Skill already exists");
            }

            var newSkill = new Skill
            {
                Name = category.Name,
            };

            await _context.Skills.AddAsync(newSkill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSkill(Guid id)
        {
            var isExist = await _context.Skills.FindAsync(id) ?? throw new KeyNotFoundException("Id not found!");

            _context.Skills.Remove(isExist);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SkillDto>> GetSkill()
        {
            var skills = _context.Skills.AsQueryable();

            return await skills.Select(x => new SkillDto
            {   
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }

        public async Task UpdateSkill(Guid id, SkillRequest skill)
        {
            var isExist = await _context.Skills.FindAsync(id) ?? throw new KeyNotFoundException("Id not found!");

            var skills = _context.Skills.AsQueryable();

            if (await skills.AnyAsync(s => s.Name.ToLower() == skill.Name.ToLower() && s.Id != id)) {
                throw new Exception("Skill already exists");
            }

            isExist.Name = skill.Name;

            _context.Skills.Update(isExist);
            await _context.SaveChangesAsync();
        }
    }
}
