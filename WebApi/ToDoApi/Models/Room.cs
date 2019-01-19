using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Room
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long Capacity { get; set; }

        public string IsAvalible { get; set; }
    }
}
