using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myth_SportEvent.Core.Data
{
    public interface IEventRepository
    {
        public void Add<T>(T entity) where T : class;

        public void SaveChanges();
    }
}
