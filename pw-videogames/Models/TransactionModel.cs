namespace pw_videogames.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }

        public VideogameModel Videogame { get; set; }

        public TransactionModel() { }
    }
}
