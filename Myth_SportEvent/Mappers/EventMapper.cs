using Myth_SportEvent.API.DTO;
using Myth_SportEvent.Core.Models;

namespace Myth_SportEvent.API.Mappers
{
    public static class EventMapper
    {
        public static SportsEventDTO Map(SportsEvent sportsEvent)
        {
            SportsEventDTO sportsEventDTO = new SportsEventDTO();

            sportsEventDTO.Id = sportsEvent.Id;
            sportsEventDTO.Description = sportsEvent.Description;
            sportsEventDTO.Type = sportsEvent.Type;
            sportsEventDTO.StartDateLocal = sportsEvent.StartDateLocalSpecified ? sportsEvent.StartDateLocal : null;
            sportsEventDTO.ScheduledStartTimeUTC = sportsEvent.ScheduledStartTimeUTCSpecified ? sportsEvent.ScheduledStartTimeUTC : null;
            sportsEventDTO.EndTime = sportsEvent.EndTimeSpecified ? sportsEvent.EndTime : null;
            sportsEventDTO.State = sportsEvent.State;
            sportsEventDTO.Attendance = sportsEvent.AttendanceSpecified ? sportsEvent.Attendance : null;
            sportsEventDTO.Sport = MapSport(sportsEvent.Sport);
            sportsEventDTO.Venue = sportsEvent.Venue;
            sportsEventDTO.StartVenue = sportsEvent.StartVenue;
            sportsEventDTO.FinishVenue = sportsEvent.FinishVenue;
            sportsEventDTO.PhaseId = sportsEvent.PhaseId;
            sportsEventDTO.SportsOrganisations = sportsEvent.SportsOrganisations;
            sportsEventDTO.ParentSportsEvents = sportsEvent.ParentSportsEvents;
            sportsEventDTO.WeatherConditions = MapWeatherConditions(sportsEvent.WeatherConditions);
            sportsEventDTO.SiblingOrder = sportsEvent.SiblingOrderSpecified ? sportsEvent.SiblingOrder : null;
            sportsEventDTO.ScheduledStatus = sportsEvent.ScheduleStatusSpecified ? sportsEvent.ScheduleStatus : null;
            sportsEventDTO.ResultStatus = sportsEvent.ResultStatusSpecified ? sportsEvent.ResultStatus : null;
            sportsEventDTO.Status = sportsEvent.StatusSpecified ? sportsEvent.Status : null;
            sportsEventDTO.EventTypeDetail = sportsEvent.EventTypeDetailSpecified ? sportsEvent.EventTypeDetail : null;
            sportsEventDTO.DirectParentSportEventId = sportsEvent.DirectParentSportEventId;
            sportsEventDTO.HomeParticipant = sportsEvent.HomeParticipant;
            sportsEventDTO.AwayParticipant = sportsEvent.AwayParticipant;
            sportsEventDTO.ParticipantType = sportsEvent.ParticipantTypeSpecified ? sportsEvent.ParticipantType : null;
            sportsEventDTO.DateAndTimeInfo = sportsEvent.DateAndTimeInfo;
            sportsEventDTO.Meta = sportsEvent.Meta;

            return sportsEventDTO;
        }

        private static SportDTO MapSport(Sport sport)
        {
            SportDTO sportDTO = new SportDTO();

            sportDTO.Id = sport.SportId;
            sportDTO.Name = sport.Name;
            sportDTO.Gender = sport.Gender;
            sportDTO.Discipline = sport.Discipline;

            return sportDTO;
        }

        private static WeatherConditionsDTO MapWeatherConditions(WeatherConditions weatherConditions)
        {
            if (weatherConditions == null)
                return null;

            WeatherConditionsDTO weatherConditionsDTO = new WeatherConditionsDTO();

            weatherConditionsDTO.Id = weatherConditions.WeatherConditionsId;
            weatherConditionsDTO.TemperatureFahrenheit = weatherConditions.TemperatureFahrenheitSpecified ? weatherConditions.TemperatureFahrenheit : null;
            weatherConditionsDTO.TemperatureCelsius = weatherConditions.TemperatureCelsiusSpecified ? weatherConditions.TemperatureCelsius : null;
            weatherConditionsDTO.WindSpeedMiles = weatherConditions.WindSpeedMilesSpecified ? weatherConditions.WindSpeedMiles : null;
            weatherConditionsDTO.WindSpeedKilometers = weatherConditions.WindSpeedKilometersSpecified ? weatherConditions.WindSpeedKilometers : null;
            weatherConditionsDTO.WindDirection = weatherConditions.WindDirectionSpecified ? weatherConditions.WindDirection : null;
            weatherConditionsDTO.WeatherType = weatherConditions.WeatherTypeSpecified ? weatherConditions.WeatherType : null;
            weatherConditionsDTO.TailWindSpeed = weatherConditions.TailWindSpeed;
            weatherConditionsDTO.BaseballHomePlateWindDirection = weatherConditions.BaseballHomePlateWindDirectionSpecified ? weatherConditions.BaseballHomePlateWindDirection : null;

            return weatherConditionsDTO;
        }
    }
}
