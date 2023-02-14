using Microsoft.EntityFrameworkCore;
using Myth_SportEvent.Core.Data;
using Myth_SportEvent.Core.Models;
using Myth_SportEvent.Ingest;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console apps close themselves when main thread finishes - wait for the async functions
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                using SportEventsContext context = new SportEventsContext();
                EventRepository eventRepository = new EventRepository(context);

                DataIngester dataIngester = new DataIngester(url: "https://myth.fra1.digitaloceanspaces.com/misc/528%20%281%29.json", client: client, repository: eventRepository);
                await dataIngester.IngestData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}