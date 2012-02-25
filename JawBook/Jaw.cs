using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JawBook
{
    public class Jaw
    {
        public Guid JawId { get; set; }

        public string Name { get; set; }
        public Race Race { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Price { get; set; }

        public byte[] Picture { get; set; }
    }
}
