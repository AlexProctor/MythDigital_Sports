using Moq.Protected;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Myth_SportEvents.UnitTests.Mocks
{
    public static class HttpClientHelper
    {

        public static HttpClient GetMockHttpClient()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent("[{\"description\":\"Seattle-Colorado\",\"type\":6,\"start_date_local\":\"2022-10-21T00:00:00\",\"start_date_localSpecified\":true,\"scheduled_start_time_utc\":\"2022-10-22T01:00:00Z\",\"scheduled_start_time_utcSpecified\":true,\"end_time\":\"0001-01-01T00:00:00\",\"end_timeSpecified\":false,\"status\":2,\"statusSpecified\":true,\"names\":null,\"state\":[{\"key\":\"period\",\"value\":\"3\"},{\"key\":\"home_score\",\"value\":\"2\"},{\"key\":\"away_score\",\"value\":\"3\"},{\"key\":\"home_score_period_1\",\"value\":\"0\"},{\"key\":\"home_score_period_2\",\"value\":\"1\"},{\"key\":\"home_score_period_3\",\"value\":\"1\"},{\"key\":\"away_score_period_1\",\"value\":\"0\"},{\"key\":\"home_shots_period_1\",\"value\":\"8\"},{\"key\":\"away_score_period_3\",\"value\":\"1\"},{\"key\":\"home_shots_period_3\",\"value\":\"5\"},{\"key\":\"away_shots_period_3\",\"value\":\"14\"},{\"key\":\"away_score_period_2\",\"value\":\"2\"},{\"key\":\"home_shots_period_2\",\"value\":\"7\"},{\"key\":\"away_shots_period_1\",\"value\":\"11\"},{\"key\":\"away_shots_period_2\",\"value\":\"13\"},{\"key\":\"winner_participant_group\",\"value\":\"AWAY\"}],\"current_state\":null,\"attendance\":18131,\"attendanceSpecified\":true,\"sport_id\":\"GN7XZG4918F8AT5\",\"venue_id\":\"GNFRJESZ1MFBDQY\",\"start_venue_id\":null,\"finish_venue_id\":null,\"phase_id\":null,\"sports_organization_ids\":[\"GN5RQVPC61QWT4F\"],\"parent_sports_event_ids\":[\"GN94120PRQKPHZ6\",\"GN0G509DZ55BXAD\",\"GN8TEEED8XESM21\",\"GN92N5D0PF678V2\"],\"weather_conditions\":null,\"event_attributes\":null,\"sports_discipline_id\":\"GN3E5XEWWXJ92MA\",\"sports_gender_id\":null,\"sibling_order\":0,\"sibling_orderSpecified\":false,\"schedule_status\":0,\"schedule_statusSpecified\":false,\"result_status\":0,\"result_statusSpecified\":false,\"properties\":null,\"navigation_info\":null,\"event_type_detail\":0,\"event_type_detailSpecified\":false,\"direct_parent_sports_event_id\":\"GN92N5D0PF678V2\",\"home_participant_id\":\"GNCBY7FXEYCKJ3Z\",\"away_participant_id\":\"GNCEF0NSCYBX3VN\",\"participant_type\":1,\"participant_typeSpecified\":true,\"date_and_time_info\":null,\"translation_reference_id\":null,\"sports\":null,\"sports_organizations\":null,\"venues\":null,\"child_sports_events\":null,\"related_sports_events\":[{\"id\":\"GN94120PRQKPHZ6\",\"type\":\"LEAGUE\",\"type_detail\":null,\"depth\":null,\"navigation_info\":null},{\"id\":\"GN0G509DZ55BXAD\",\"type\":\"LEAGUE_SEASON\",\"type_detail\":null,\"depth\":null,\"navigation_info\":null},{\"id\":\"GN8TEEED8XESM21\",\"type\":\"PHASE\",\"type_detail\":\"PHASE_ROUND\",\"depth\":\"1\",\"navigation_info\":{\"has_standings\":true,\"is_knockout\":false}},{\"id\":\"GN92N5D0PF678V2\",\"type\":\"PHASE\",\"type_detail\":\"PHASE_ROUND\",\"depth\":\"2\",\"navigation_info\":null}],\"id\":\"GN909DM9N0EKBTJ\",\"meta\":{\"update_id\":2571888873,\"update_idSpecified\":true,\"update_action\":\"UPDATE\",\"update_date\":\"2022-10-22T04:13:58Z\",\"language\":\"en-GB\"},\"xids\":null}]"),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            return httpClient;
        }

    }
}
