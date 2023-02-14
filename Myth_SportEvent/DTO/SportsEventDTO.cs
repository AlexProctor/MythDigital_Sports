using Myth_SportEvent.Core.Models;

namespace Myth_SportEvent.API.DTO
{
    public class SportsEventDTO
    {
        public string Id { get; set; } = null!;
        public string? Description { get; set; }
        public int Type { get; set; }
        public DateTime? StartDateLocal { get; set; }
        public DateTime? ScheduledStartTimeUTC { get; set; }
        public DateTime? EndTime { get; set; }
        public List<State> State { get; set; } = null!;
        public int? Attendance { get; set; }
        public SportDTO Sport { get; set; } = null!;
        public Venue? Venue { get; set; }
        public Venue? StartVenue { get; set; }
        public Venue? FinishVenue { get; set; }
        public string? PhaseId { get; set; }
        public List<SportsOrganisation> SportsOrganisations { get; set; } = null!;
        public List<ParentSportEvent> ParentSportsEvents { get; set; } = null!;
        public WeatherConditionsDTO? WeatherConditions { get; set; }
        public int? SiblingOrder { get; set; }
        public int? ScheduledStatus { get; set; }
        public int? ResultStatus { get; set; }
        public int? Status { get; set; }
        public int? EventTypeDetail { get; set; }
        public string? DirectParentSportEventId { get; set; }
        public Participant? HomeParticipant { get; set; }
        public Participant? AwayParticipant { get; set; }
        public int? ParticipantType { get; set; }
        public DateAndTimeInfo? DateAndTimeInfo { get; set; }
        public Meta Meta { get; set; } = null!;



    }
}
