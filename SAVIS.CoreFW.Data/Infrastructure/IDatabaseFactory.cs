using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCMS.Data
{
    public interface IDatabaseFactory 
    {
        StudentDBEntities GetDbContext();
    }
}
