using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public bool ActiveStatus { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
