using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Moq.Protected;
using Myth_SportEvent.Core.Data;
using Myth_SportEvent.Core.Models;
using Myth_SportEvent.Ingest;
using Myth_SportEvents.UnitTests.Mocks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace Myth_SportEvents.UnitTests
{
    [TestClass]
    public class IngestTests
    {
        [TestMethod]
        public void DataIngester_IngestData_Null_Url_Throws()
        {
            HttpClient httpClient = new HttpClient();
            SportEventsContext context = new SportEventsContext();
            EventRepository repository = new EventRepository(context);

            var ex = Assert.ThrowsException<ArgumentNullException>(() => new DataIngester(url: null, httpClient, repository));
            Assert.AreEqual(ex.Message, "Value cannot be null. (Parameter 'url')");
        }

        [TestMethod]
        public void DataIngester_IngestData_Null_HttpClient_Throws()
        {
            SportEventsContext context = new SportEventsContext();
            EventRepository repository = new EventRepository(context);

            var ex = Assert.ThrowsException<ArgumentNullException>(() => new DataIngester(url: "http://testurl.com", null, repository));
            Assert.AreEqual(ex.Message, "Value cannot be null. (Parameter 'client')");
        }

        [TestMethod]
        public void DataIngester_IngestData_Null_DbContext_Throws()
        {
            HttpClient httpClient = new HttpClient();

            var ex = Assert.ThrowsException<ArgumentNullException>(() => new DataIngester(url: "http://testurl.com", httpClient, null));
            Assert.AreEqual(ex.Message, "Value cannot be null. (Parameter 'repository')");
        }

        [TestMethod]
        public async Task DataIngester_Ingests_Sports()
        {
            MockEventRepository repository = new MockEventRepository();
            HttpClient httpClient = HttpClientHelper.GetMockHttpClient();

            var dataIngester = new DataIngester(url: "http://testurl.com", httpClient, repository);
            await dataIngester.IngestData();

            var sport = repository.Sport.Single();

            Assert.AreEqual("GN7XZG4918F8AT5", sport.SportId);
            Assert.AreEqual("Sport0", sport.Name);
        }

        [TestMethod]
        public async Task DataIngester_Ingests_Venues()
        {
            MockEventRepository repository = new MockEventRepository();
            HttpClient httpClient = HttpClientHelper.GetMockHttpClient();

            var dataIngester = new DataIngester(url: "http://testurl.com", httpClient, repository);
            await dataIngester.IngestData();

            var venue = repository.Venue.Single();

            Assert.AreEqual("GNFRJESZ1MFBDQY", venue.VenueId);
            Assert.AreEqual("Venue0", venue.Name);
        }

        [TestMethod]
        public async Task DataIngester_Ingests_Events()
        {
            MockEventRepository repository = new MockEventRepository();
            HttpClient httpClient = HttpClientHelper.GetMockHttpClient();

            var dataIngester = new DataIngester(url: "http://testurl.com", httpClient, repository);
            await dataIngester.IngestData();

            var sportEvent = repository.Events.Single();

            Assert.AreEqual("GN909DM9N0EKBTJ", sportEvent.Id);
            Assert.AreEqual("Seattle-Colorado", sportEvent.Description);
            Assert.AreEqual(6, sportEvent.Type);
            Assert.AreEqual(DateTime.Parse("2022-10-21T00:00:00"), sportEvent.StartDateLocal);
            Assert.AreEqual(DateTime.Parse("2022-10-22T01:00:00"), sportEvent.ScheduledStartTimeUTC);
            Assert.AreEqual(DateTime.Parse("0001-01-01T00:00:00"), sportEvent.EndTime);
            Assert.AreEqual(2, sportEvent.Status);
            Assert.AreEqual(18131, sportEvent.Attendance);
        }

        [TestMethod]
        public async Task DataIngester_Ingests_Events_States()
        {
            MockEventRepository repository = new MockEventRepository();
            HttpClient httpClient = HttpClientHelper.GetMockHttpClient();

            var dataIngester = new DataIngester(url: "http://testurl.com", httpClient, repository);
            await dataIngester.IngestData();

            var sportEvent = repository.Events.Single();
            var states = sportEvent.State;

            Assert.AreEqual(16, states.Count);
            Assert.AreEqual("period", states[0].Key);
            Assert.AreEqual("3", states[0].Value);

        }
    }
}