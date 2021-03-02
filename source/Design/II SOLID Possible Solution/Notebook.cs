// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    using System;

    public class Notebook : Item, ICanBeDeserializedFromJson
    {
        public string TypeName => "notebook";

        /// <remarks>
        /// This constructor was added to support the <see cref="ICanBeDeserializedFromJson"/> implementation.
        /// </remarks>
        public Notebook() : base(-1, string.Empty, Price.FromChf(0))
        {
            this.Color = NotebookColor.Blue;
        }

        public Notebook(int id, string title, Price price, NotebookColor color)
            : base(id, title, price)
        {
            this.Color = color;
        }

        public NotebookColor Color { get; }

        public override string GetString()
        {
            return $"Notebook: {this.Title} in {this.Color}\t> {this.Price}";
        }

        public Item DeserializeFrom(ItemJsonDefinition json)
        {
            var price = Price.FromChf(json.Price);
            var penColor = (NotebookColor)Enum.Parse(typeof(NotebookColor), json.Color);

            return new Notebook(json.Id, json.Title, price, penColor);
        }
    }
}