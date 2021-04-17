using System;

namespace Landy.Services.Offer.Core.Dtos
{
    public class ImageDto
    {
        public Guid ImageId { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Format { get; set; }
    }


}