using System.Collections.Generic;

namespace MobileSubscription.Website.Models
{
    public class CountryOperators
    {
        public Country Country { get; set; }
        public List<Operator> Operators { get; set; }
    }
}