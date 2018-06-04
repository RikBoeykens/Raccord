using System.Collections.Generic;

namespace Raccord.Application.Core.Common.Location
{
    public class AddressDto
    {
        // Address 1
        public string Address1 { get; set; }
        // Address 2
        public string Address2 { get; set; }
        // Address 3
        public string Address3 { get; set; }
        // Address 4
        public string Address4 { get; set; }

        public string GetAddressString
        {
            get
            {
                return $"{Address1}, {Address2}, {Address3}, {Address4}";
            }
        }
    }
}