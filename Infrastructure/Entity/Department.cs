using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class Department:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string DepartmenName { get; set; }
    }
}
