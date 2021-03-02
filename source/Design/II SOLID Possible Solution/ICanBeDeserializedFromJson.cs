// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    public interface ICanBeDeserializedFromJson
    {
        string TypeName { get; }

        Item DeserializeFrom(ItemJsonDefinition json);
    }
}