namespace pw_videogames.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }

        public VideogameModel Videogame { get; set; }

        public TransactionModel() { }

        public TransactionModel(int id, DateTime date, int quantity)
        {
            Id = id;
            Date = date;
            Quantity = quantity;
            Videogame = new VideogameModel();
        }
    }
}
