using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using Riok.Mapperly.Abstractions;

namespace JobBoardWebApi.Mapper
{
    [Mapper]   
    
    public static partial class ApplicationMapper
    {      
        public static partial ApplicationsDto ApplicationsMapToDto(Application application);

    }
}
