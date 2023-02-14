using Myth_SportEvent.Core.Data;
using Myth_SportEvent.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myth_SportEvents.UnitTests.Mocks
{
    public class MockEventRepository : IEventRepository
    {
        public List<Sport> Sport = new List<Sport>();
        public List<Venue> Venue = new List<Venue>();
        public List<State> State = new List<State>();
        public List<SportsEvent> Events = new List<SportsEvent>();

        public void Add<T>(T entity) where T : class
        {
            if(entity is Sport)
                Sport.Add(entity as Sport);

            if(entity is Venue)
                Venue.Add(entity as Venue);

            if (entity is State)
                State.Add(entity as State);

            if (entity is SportsEvent)
                Events.Add(entity as SportsEvent);
        }

        public void SaveChanges()
        {
        }
    }
}
