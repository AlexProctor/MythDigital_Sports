using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myth_SportEvent.Core.Models
{

    public class SportsEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = null!;
        public string? Description { get; set; }
        public int Type { get; set; }

        [JsonProperty("start_date_local")]
        public DateTime StartDateLocal { get; set; }
        [JsonProperty("start_date_localSpecified")]
        public bool StartDateLocalSpecified { get; set; }

        [JsonProperty("scheduled_start_time_utc")]
        public DateTime ScheduledStartTimeUTC { get; set; }
        [JsonProperty("scheduled_start_time_utcSpecified")]
        public bool ScheduledStartTimeUTCSpecified { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("end_timeSpecified")]
        public bool EndTimeSpecified { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("statusSpecified")]
        public bool StatusSpecified { get; set; }

        public virtual List<State> State { get; set; } = new List<State>();
        public State? CurrentState { get; set; }
        [JsonProperty("attendance")]
        public int Attendance { get; set; }
        [JsonProperty("attendanceSpecified")]
        public bool  AttendanceSpecified { get; set; }
        [JsonProperty("sport_id")]
        public string SportId { get; set; } = null!;

        [ForeignKey("SportId")]
        public virtual Sport Sport { get; set; } = null!;

        [JsonProperty("venue_id")]
        public string? VenueId { get; set; }

        [ForeignKey("VenueId")]
        public virtual Venue? Venue { get; set; }

        [JsonProperty("start_venue_id")]
        public string? StartVenueId { get; set; }

        [ForeignKey("StartVenueId")]
        public virtual Venue? StartVenue { get; set; }

        [JsonProperty("finish_venue_id")]
        public string? FinishVenueId { get; set; }

        [ForeignKey("FinishVenueId")]
        public virtual Venue? FinishVenue { get; set; }

        [JsonProperty("phase_id")]
        public string? PhaseId { get; set; }

        [JsonProperty("sports_organization_ids")]
        [NotMapped]
        public List<string>? SportsOrganisationIds { get; set; }
        public List<SportsOrganisation> SportsOrganisations { get; set; } = new List<SportsOrganisation>();

        [JsonProperty("parent_sports_event_ids")]
        [NotMapped]
        public List<string>? ParentSportsEventIds { get; set; }
        public List<ParentSportEvent> ParentSportsEvents { get; set; } = new List<ParentSportEvent>();

        [JsonProperty("weather_conditions")]
        public WeatherConditions? WeatherConditions { get; set; }

        [JsonProperty("sports_discipline_id")]
        [NotMapped]
        public string? SportsDisciplineId { get; set; }

        [JsonProperty("sports_gender_id")]
        [NotMapped]
        public string? SportsGenderId { get; set; }

        [JsonProperty("sibling_order")]
        public int SiblingOrder { get; set; }

        [JsonProperty("sibling_orderSpecified")]
        public bool SiblingOrderSpecified { get; set; }

        [JsonProperty("schedule_status")]
        public int ScheduleStatus { get; set; }

        [JsonProperty("schedule_statusSpecified")]
        public bool ScheduleStatusSpecified { get; set; }

        [JsonProperty("result_status")]
        public int ResultStatus { get; set; }

        [JsonProperty("result_statusSpecified")]
        public bool ResultStatusSpecified { get; set; }

        [JsonProperty("event_type_detail")]
        public int EventTypeDetail { get; set; }

        [JsonProperty("event_type_detailSpecified")]
        public bool EventTypeDetailSpecified { get; set; }

        [JsonProperty("direct_parent_sports_event_id")]
        public string? DirectParentSportEventId { get; set; }

        [JsonProperty("home_participant_id")]
        public string? HomeParticipantId { get; set; }

        [ForeignKey("HomeParticipantId")]
        public Participant? HomeParticipant { get; set; }

        [JsonProperty("away_participant_id")]
        public string? AwayParticipantId { get; set; }

        [ForeignKey("AwayParticipantId")]
        public Participant? AwayParticipant { get; set; }

        [JsonProperty("participant_type")]
        public int ParticipantType { get; set; }
        [JsonProperty("participant_typeSpecified")]
        public bool ParticipantTypeSpecified { get; set; }
        [JsonProperty("date_and_time_info")]
        public DateAndTimeInfo? DateAndTimeInfo { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; } = null!;


    }
}


