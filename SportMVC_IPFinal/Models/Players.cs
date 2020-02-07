using System;
using System.Collections.Generic;

namespace SportMVC_IPFinal
{
    public partial class Players
    {
        public int PlayerId { get; set; }
        public string FullName { get; set; }
        public int? FkSportId { get; set; }
        public int? Age { get; set; }
        public string Country { get; set; }

        public Sport FkSport { get; set; }
    }
}
