using System;
using System.Collections.Generic;
using System.Text;
using FireOps.Domain.Enums;

namespace FireOps.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
