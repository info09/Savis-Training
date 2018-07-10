using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCMS.Data
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly StudentDBEntities dataContext;
        public string Id { get; set; }
        public DatabaseFactory()
        {
            dataContext = new StudentDBEntities();

            // Get randomize Id
            var random = new Random(DateTime.Now.Millisecond);
            Id = random.Next(1000000).ToString();
        }

        public StudentDBEntities GetDbContext()
        {
            return dataContext;
        }
    }
}
