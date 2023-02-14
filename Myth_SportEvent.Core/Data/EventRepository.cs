using Microsoft.EntityFrameworkCore;
using Myth_SportEvent.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myth_SportEvent.Core.Data
{
    public class EventRepository : IEventRepository
    {
        SportEventsContext _context;

        public EventRepository(SportEventsContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
