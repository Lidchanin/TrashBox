using TrashBox.Abstractions;

namespace TrashBox.Models
{
    public class MKCharacter : BaseParallaxCarouselItem
    {
        public string Name { get; }

        public string Info { get; }

        public string Image { get; }

        public MKCharacter(string name, string info, string image)
        {
            Name = name;
            Info = info;
            Image = image;
        }
    }
}