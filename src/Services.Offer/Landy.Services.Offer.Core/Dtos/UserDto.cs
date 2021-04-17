using System;

namespace Landy.Services.Offer.Core.Dtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}