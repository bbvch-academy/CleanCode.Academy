// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    using System;

    public class Pen : Item, ICanBeDeserializedFromJson
    {
        public string TypeName => "pen";

        /// <remarks>
        /// This constructor was added to support the <see cref="ICanBeDeserializedFromJson"/> implementation.
        /// </remarks>
        public Pen() : base(-1, string.Empty, Price.FromChf(0))
        {
            this.Color = PenColor.Blue;
        }

        public Pen(int id, string title, Price price, PenColor color)
            : base(id, title, price)
        {
            this.Color = color;
        }

        public PenColor Color { get; }

        public override string GetString()
        {
            return $"Pen: {this.Title} in {this.Color}\t> {this.Price}";
        }

        public Item DeserializeFrom(ItemJsonDefinition json)
        {
            var price = Price.FromChf(json.Price);
            var penColor = (PenColor)Enum.Parse(typeof(PenColor), json.Color);

            return new Pen(json.Id, json.Title, price, penColor);
        }
    }
}