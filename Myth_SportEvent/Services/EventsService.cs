using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Myth_SportEvent.API.DTO;
using Myth_SportEvent.API.Mappers;
using Myth_SportEvent.Core.Data;
using Myth_SportEvent.Core.Models;
using System.ComponentModel;

namespace Myth_SportEvent.API.Services
{
    public class EventsService
    {
        private readonly SportEventsContext _context;

        public EventsService(SportEventsContext context)
        {
            if(context == null)
                throw new ArgumentNullException("context");

            _context = context;
        }

        public async Task<List<SportsEventDTO>> GetAllSportsEvents()
        {
            var allEvents = await _context.SportsEvents.ToListAsync();
            var mappedEvents = new List<SportsEventDTO>();

            foreach (var sportEvent in allEvents)
            {
                mappedEvents.Add(EventMapper.Map(sportEvent));
            }

            return mappedEvents;

        }

        public async Task<List<SportsEventDTO>> GetSportsEventById(string id)
        {
            var sportsEvent = await _context.SportsEvents.FindAsync(id);

            if (sportsEvent == null)
                return new List<SportsEventDTO>();

            await LoadRelatedEntities(sportsEvent);

            SportsEventDTO mappedEvent = EventMapper.Map(sportsEvent);


            return new List<SportsEventDTO> { mappedEvent };
        }

        public async Task<List<SportsEventDTO>> SearchSportsEvents(SearchCriteria searchCriteria)
        {
            var sportsEvents = await _context.SportsEvents.Where(e => e.Type == searchCriteria.Type && e.Description == searchCriteria.Description).ToListAsync<SportsEvent>();

            if(sportsEvents == null)
                return new List<SportsEventDTO>();

            List<SportsEventDTO> mappedEvents = new List<SportsEventDTO>();

            foreach (SportsEvent sportsEvent in sportsEvents)
            {
                await LoadRelatedEntities(sportsEvent);
                mappedEvents.Add(EventMapper.Map(sportsEvent));
            }

            return mappedEvents;

        }

        private async Task LoadRelatedEntities(SportsEvent sportsEvent)
        {
            await _context.Entry(sportsEvent).Collection(i => i.State).LoadAsync();
            await _context.Entry(sportsEvent).Collection(i => i.SportsOrganisations).LoadAsync();
            await _context.Entry(sportsEvent).Collection(i => i.ParentSportsEvents).LoadAsync();

            await _context.Entry(sportsEvent).Reference(i => i.Sport).LoadAsync();
            await _context.Entry(sportsEvent.Sport).Reference(i => i.Discipline).LoadAsync();
            await _context.Entry(sportsEvent.Sport).Reference(i => i.Gender).LoadAsync();
            await _context.Entry(sportsEvent).Reference(i => i.Venue).LoadAsync();
            await _context.Entry(sportsEvent).Reference(i => i.StartVenue).LoadAsync();
            await _context.Entry(sportsEvent).Reference(i => i.FinishVenue).LoadAsync();
            await _context.Entry(sportsEvent).Reference(i => i.HomeParticipant).LoadAsync();
            await _context.Entry(sportsEvent).Reference(i => i.AwayParticipant).LoadAsync();
            await _context.Entry(sportsEvent).Reference(i => i.DateAndTimeInfo).LoadAsync();
            await _context.Entry(sportsEvent).Reference(i => i.Meta).LoadAsync();
            await _context.Entry(sportsEvent).Reference(i => i.WeatherConditions).LoadAsync();
        }


    }
}
