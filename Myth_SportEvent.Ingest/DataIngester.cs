using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Myth_SportEvent.Core.Data;
using Myth_SportEvent.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Myth_SportEvent.Ingest
{
    public class DataIngester
    {
        private string _url;
        private HttpClient _client;
        private IEventRepository _eventRepository;

        /// <summary>
        /// Ingests data from provided endpoint into database
        /// </summary>
        /// <param name="url"></param>
        /// <param name="client"></param>
        /// <param name="repository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DataIngester(string url, HttpClient client, IEventRepository repository)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            if (client == null)
                throw new ArgumentNullException("client");

            if (repository == null)
                throw new ArgumentNullException("repository");

            _url = url;
            _client = client;
            _eventRepository = repository;
        }

        /// <summary>
        /// Calls to url end point and ingests data in string format.
        /// </summary>
        /// <returns>Ingested Data in String Format</returns>
        public async Task IngestData()
        {
            string data = await GetDataFromEndpoint();
            var events = JsonConvert.DeserializeObject<List<SportsEvent>>(data);

            if(events != null)
            {
                try
                {
                    SaveDependencyRecords(events);
                    SaveEvents(events);
                    _eventRepository.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw new DbUpdateException("Error while saving events to database", ex);
                }
            }
            else
            {
                Console.WriteLine("No Records to save");
            }
        }

        private void SaveDependencyRecords(List<SportsEvent> events)
        {
            SaveSportsDiscipline(events);
            SaveSportsGender(events);
            SaveSportsOrganisation(events);
            SaveParentSportEvents(events);
            SaveSports(events);
            SaveParticipants(events);
            SaveVenues(events);
        }

        /// <summary>
        /// Retrieves json data as string from endpoint
        /// </summary>
        private async Task<string> GetDataFromEndpoint()
        {
            string data = "";

            try
            {
                using (HttpResponseMessage response = await _client.GetAsync(_url))
                {
                    using (HttpContent content = response.Content)
                    {
                        data = await content.ReadAsStringAsync();
                    }
                }  

            } catch (Exception e)
            {
                Console.WriteLine($"Failed to retrieve data from endpoint - {_url} - {e.Message}");
            }

            return data;
        }

        /// <summary>
        /// Pulls out sport Discipline data from event collection and commits to context
        /// </summary>
        /// <param name="events"></param>
        private void SaveSportsDiscipline(List<SportsEvent> events)
        {
            List<SportsDiscipline> addedSportsDiscipline = new List<SportsDiscipline>();

            foreach (var sportsEvent in events)
            {
                if(sportsEvent.SportsDisciplineId != null)
                {
                    //Only add to context where the sport Id does not exist
                    if (addedSportsDiscipline.FirstOrDefault(e => e.SportsDisciplineId == sportsEvent.SportsDisciplineId) == null)
                    {
                        var sportDiscipline = new SportsDiscipline()
                        {
                            SportsDisciplineId = sportsEvent.SportsDisciplineId,
                        };

                        addedSportsDiscipline.Add(sportDiscipline);
                        _eventRepository.Add(sportDiscipline);
                    }
                }
            }
        }

        /// <summary>
        /// Pulls out sport Gender data from event collection and commits to context
        /// </summary>
        /// <param name="events"></param>
        private void SaveSportsGender(List<SportsEvent> events)
        {
            List<SportsGender> addedSportsGender = new List<SportsGender>();

            foreach(var sportsEvent in events)
            {
                if(sportsEvent.SportsGenderId != null)
                {
                    //Only add to context where the sport Id does not exist
                    if (addedSportsGender.FirstOrDefault(e => e.SportsGenderId == sportsEvent.SportsGenderId) == null)
                    {
                        var sportsGender = new SportsGender()
                        {
                            SportsGenderId = sportsEvent.SportsGenderId,
                        };

                        addedSportsGender.Add(sportsGender);
                        _eventRepository.Add(sportsGender);
                    }
                }
            }
        }

        /// <summary>
        /// Pulls out sport organisations data from event collection and commits to context
        /// </summary>
        /// <param name="events"></param>
        private void SaveSportsOrganisation(List<SportsEvent> events)
        {
            List<SportsOrganisation> addedSportsOrgs = new List<SportsOrganisation>();

            foreach (var sportsEvent in events)
            {
                if (sportsEvent.SportsOrganisationIds != null)
                {
                    foreach(string orgId in sportsEvent.SportsOrganisationIds)
                    {
                        var sportsOrg = addedSportsOrgs.FirstOrDefault(e => e.SportsOrganisationId == orgId);

                        //Only add to context where the sport Id does not exist
                        if (sportsOrg == null)
                        {
                            sportsOrg = new SportsOrganisation()
                            {
                                SportsOrganisationId = orgId,
                            };

                            addedSportsOrgs.Add(sportsOrg);
                            _eventRepository.Add(sportsOrg);
                            sportsEvent.SportsOrganisations.Add(sportsOrg);
                        }
                        else
                        {
                            sportsEvent.SportsOrganisations.Add(sportsOrg);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Pulls out sport organisations data from event collection and commits to context
        /// </summary>
        /// <param name="events"></param>
        private void SaveParentSportEvents(List<SportsEvent> events)
        {
            List<ParentSportEvent> addedParentEvents = new List<ParentSportEvent>();

            foreach (var sportsEvent in events)
            {
                if (sportsEvent.ParentSportsEventIds != null)
                {
                    foreach (string parentId in sportsEvent.ParentSportsEventIds)
                    {
                        var parentEvent = addedParentEvents.FirstOrDefault(e => e.ParentSportEventId == parentId);

                        //Only add to context where the sport Id does not exist
                        if (parentEvent == null)
                        {
                            parentEvent = new ParentSportEvent()
                            {
                                ParentSportEventId = parentId,
                            };

                            addedParentEvents.Add(parentEvent);
                            _eventRepository.Add(parentEvent);
                            sportsEvent.ParentSportsEvents.Add(parentEvent);
                        }
                        else
                        {
                            sportsEvent.ParentSportsEvents.Add(parentEvent);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Pulls out sport data from event collection and commits to context
        /// </summary>
        /// <param name="events"></param>
        private void SaveSports(List<SportsEvent> events)
        {
            List<Sport> addedSports = new List<Sport>();

            for (int i = 0; i < events.Count; i++)
            {
                var sportsEvent = events[i];


                //Only add to context where the sport Id does not exist
                if (addedSports.FirstOrDefault(e => e.SportId == sportsEvent.SportId) == null)
                {
                    var sport = new Sport()
                    {
                        SportId = sportsEvent.SportId,
                        Name = $"Sport{i}",
                        SportsDisciplineId = sportsEvent.SportsDisciplineId,
                        SportsGenderId = sportsEvent.SportsGenderId,
                    };

                    addedSports.Add(sport);
                    _eventRepository.Add(sport);
                }
            }
        }

        /// <summary>
        /// Pulls out sport data from event collection and commits to context
        /// </summary>
        /// <param name="events"></param>
        private void SaveParticipants(List<SportsEvent> events)
        {
            List<Participant> addedParticipant = new List<Participant>();

            for (int i = 0; i < events.Count; i++)
            {
                var sportsEvent = events[i];

                var homeParticipant = addedParticipant.FirstOrDefault(e => e.ParticipantId == sportsEvent.HomeParticipantId);

                //add Home Participant
                if (homeParticipant == null && sportsEvent.HomeParticipantId != null)
                {
                    var participant = new Participant()
                    {
                        ParticipantId = sportsEvent.HomeParticipantId
                    };

                    addedParticipant.Add(participant);
                    _eventRepository.Add(participant);
                }

                var awayParticipant = addedParticipant.FirstOrDefault(e => e.ParticipantId == sportsEvent.AwayParticipantId);

                //add Away Participant
                if (awayParticipant == null && sportsEvent.AwayParticipantId != null)
                {
                    var participant = new Participant()
                    {
                        ParticipantId = sportsEvent.AwayParticipantId
                    };

                    addedParticipant.Add(participant);
                    _eventRepository.Add(participant);
                }
            }
        }

        /// <summary>
        /// Pulls out events data from event collection and commits to context
        /// </summary>
        /// <param name="events"></param>
        private void SaveVenues(List<SportsEvent> events)
        {
            List<Venue> addedVenues = new List<Venue>();

            for (int i = 0; i < events.Count; i++)
            {
                var sportsEvent = events[i];

                if (sportsEvent.VenueId == null)
                    continue;

                //Only add to context where the sport Id does not exist
                if (addedVenues.FirstOrDefault(e => e.VenueId == sportsEvent.VenueId) == null)
                {
                    var venue = new Venue()
                    {
                        VenueId = sportsEvent.VenueId,
                        Name = $"Venue{i}",
                    };

                    addedVenues.Add(venue);
                    _eventRepository.Add(venue);
                }
            }
        }

        /// <summary>
        /// Pulls out events data from event collection and commits to context
        /// </summary>
        /// <param name="events"></param>
        private void SaveEvents(List<SportsEvent> events)
        {
            List<SportsEvent> addedEvents = new List<SportsEvent>();

            foreach (SportsEvent sportsEvent in events)
            {
                if (addedEvents.FirstOrDefault(e => e.Id == sportsEvent.Id) == null)
                {
                    addedEvents.Add(sportsEvent);
                    _eventRepository.Add(sportsEvent);
                }
            }
        }

    }
}
