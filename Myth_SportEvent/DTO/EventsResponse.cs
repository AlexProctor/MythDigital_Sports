using Myth_SportEvent.Core.Models;

namespace Myth_SportEvent.API.DTO
{
    public class EventsResponse
    {
        public List<SportsEventDTO>? Events { get; set; }
        public Error? Error { get; set; } = null;
    }
}
