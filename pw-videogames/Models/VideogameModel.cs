namespace pw_videogames.Models
{
    public class VideogameModel
    {
        public int Id {  get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        public float Price { get; set; }

        public VideogameModel() { }

        public VideogameModel(int id, string name, string description, string imgUrl, float price)
        {
            Id = id;
            Name = name;
            Description = description;
            ImgUrl = imgUrl;
            Price = price;
        }
    }
}
