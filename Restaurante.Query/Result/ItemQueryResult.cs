namespace Restaurante.Query.Result
{
    public class ItemQueryResult
    {
        private int MenuNumber { get; }
        private string Description { get; }
        private bool IsDrink { get; }
        private decimal Price { get; }

        public ItemQueryResult(int menuNumber, string description, bool isDrink, decimal price)
        {
            MenuNumber = menuNumber;
            Description = description;
            IsDrink = isDrink;
            Price = price;
        }
    }
}
