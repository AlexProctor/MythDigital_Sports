using Microsoft.AspNetCore.Mvc;
using Myth_SportEvent.API.DTO;
using Myth_SportEvent.API.Services;
using Myth_SportEvent.Core.Data;

namespace Myth_SportEvent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly SportEventsContext _context;
        private readonly EventsService _service;

        public EventsController(SportEventsContext context)
        {
            _context = context;
            _service = new EventsService(context);
        }

        [HttpGet]
        [Route("AllEvents")]
        public async Task<ActionResult<EventsResponse>> GetSportsEvents()
        {
            try
            {
                var events = await _service.GetAllSportsEvents();

                return Ok(new EventsResponse
                {
                    Events = events,
                });
            }
            catch (Exception ex)
            {
                //Log error
                Console.WriteLine(ex.Message);

                return new EventsResponse
                {
                    Error = new Error
                    {
                        Description = "Failed to retrieve all Sports Events",
                    }
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventsResponse>> GetSportsEvent(string id)
        {
            var sportsEvents = await _service.GetSportsEventById(id);

            //Return error with message
            if (sportsEvents.Count == 0)
            {
                return NotFound(new EventsResponse
                {
                    Error = new Error
                    {
                        Description = $"Failed to retrieve sports event {id}",
                    }
                });
            }

            //Return Events
            return Ok(new EventsResponse
            {
                Events =  sportsEvents,
            });
        }

        [HttpGet]
        public async Task<ActionResult<EventsResponse>> SearchSportsEvents([FromQuery] SearchCriteria searchCriteria)
        {
            if (searchCriteria.Type == null && searchCriteria.Description == null)
            {
                return BadRequest("Invalid search options");
            }

            var sportsEvents = await _service.SearchSportsEvents(searchCriteria);

            //Return Events
            return Ok(new EventsResponse
            {
                Events = sportsEvents,
            });
        }
    }
}
