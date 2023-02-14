using Myth_SportEvent.Core.Models;

namespace Myth_SportEvent.API.DTO
{
    public class SportDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public SportsGender? Gender { get; set; }
        public SportsDiscipline? Discipline { get; set; }
    }
}
