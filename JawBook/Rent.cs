using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JawBook
{
    public class Rent
    {
        public Guid RentId { get; set; }

        public User User { get; set; }
        public Jaw Jaw { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
