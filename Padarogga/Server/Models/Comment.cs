using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class Comment : BaseEntity
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }       
    }
}
