using System;
using System.Collections.Generic;

namespace SportMVC_IPFinal
{
    public partial class Sport
    {
        public Sport()
        {
            Players = new HashSet<Players>();
        }

        public int SportId { get; set; }
        public string SportName { get; set; }
        public string Description { get; set; }

        public ICollection<Players> Players { get; set; }
    }
}
