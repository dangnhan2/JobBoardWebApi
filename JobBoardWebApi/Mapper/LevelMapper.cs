using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using Riok.Mapperly.Abstractions;

namespace JobBoardWebApi.Mapper
{
    [Mapper]   
    public static partial class LevelMapper
    {        
        public static partial LevelsDto MapLevelToDto(Level level);
    }
}
