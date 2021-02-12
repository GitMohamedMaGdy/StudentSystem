using StudentSystem.Core.Models;
using System;
using System.Collections.Generic;
using WWebAPI_Project.Core.Models;

#nullable disable

namespace WebAPI_Project.Core.Models
{
    public partial class Gender : BaseEntity
    {
        public Gender()
        {
            Students = new HashSet<Student>();
        }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
