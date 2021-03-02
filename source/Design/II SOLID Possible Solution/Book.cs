// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    public class Book : Item, ICanBeDeserializedFromJson
    {
        public string TypeName => "book";

        /// <remarks>
        /// This constructor was added to support the <see cref="ICanBeDeserializedFromJson"/> implementation.
        /// </remarks>
        public Book() : base(-1, string.Empty, Price.FromChf(0))
        {
            this.Author = string.Empty;
        }

        public Book(int id, string title, Price price, string author)
            : base(id, title, price)
        {
            this.Author = author;
        }

        public string Author { get; }

        public override string GetString()
        {
            return $"Book: {this.Title} by {this.Author}\t> {this.Price}";
        }

        public Item DeserializeFrom(ItemJsonDefinition json)
        {
            var price = Price.FromChf(json.Price);

            return new Book(json.Id, json.Title, price, json.Author);
        }
    }
}